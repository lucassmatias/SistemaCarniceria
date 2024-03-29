﻿using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class BackupForm : Form
    {
        string path = string.Empty;
        string conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbCarniceria;Integrated Security=True";
        public BackupForm()
        {
            InitializeComponent();
        }
        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == string.Empty ) { throw new Exception("Ruta no especificada."); }
                else
                {
                    using (SqlConnection con = new SqlConnection(conexion))
                    {
                        con.Open();
                        path += $"\\SistemaCarniceria={DateTime.Now.Day}-" +
                            $"{DateTime.Now.Month}-{DateTime.Now.Year}=" +
                            $"{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}.bak";
                        SqlCommand Comando = new SqlCommand("backup database [dbCarniceria] to disk = @path", con);
                        Comando.Parameters.AddWithValue("path", path);
                        Comando.ExecuteNonQuery();
                        MessageBox.Show("Backup creado exitosamente!");
                        LogManager.AgregarLogEvento($"BACKUP - Backup creado ({DateTime.Now})", 3, SessionManager.GetInstance.user);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                string filePath = openFileDialog1.FileName;
                if (filePath.Split('.')[1] != "bak") { throw new Exception("Archivo no es formato backup"); }
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("alter database [dbCarniceria] set offline with rollback immediate", con);
                    command.ExecuteNonQuery();

                    command = new SqlCommand("restore database [dbCarniceria] from disk = @path", con);
                    command.Parameters.AddWithValue("path", filePath);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Backup restaurado exitosamente!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LogManager.AgregarLogEvento($"BACKUP - Intento fallido de Backup ({DateTime.Now})", 3, SessionManager.GetInstance.user);
            }
            finally
            {
                using(SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("alter database [dbCarniceria] set online", con);
                    command.ExecuteNonQuery();
                    LogManager.AgregarLogEvento($"BACKUP - Base de datos restaurado ({DateTime.Now})", 3, SessionManager.GetInstance.user);
                }              
            }
        }
        private void btnExamine_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            path = folderBrowserDialog1.SelectedPath.ToString();
            textBox1.Text = path;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
