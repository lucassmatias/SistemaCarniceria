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
        string path = @"C:\Users\lukit\OneDrive\Escritorio\Codigo"; 
        string conexion = "Data Source=zaskao\\SQLEXPRESS;Initial Catalog=dbCarniceria;Integrated Security=True";
        public BackupForm()
        {
            InitializeComponent();
        }

        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                path += $"\\Backup\\SistemaCarniceria={DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}={DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}.bak";
                SqlCommand Comando = new SqlCommand("backup database [dbCarniceria] to disk = @path", con);
                Comando.Parameters.AddWithValue("path", path);
                Comando.ExecuteNonQuery();
            }
        }

        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                int index = path.IndexOf("Backup");
                string cadena = path.Substring(index);
                SqlCommand command = new SqlCommand("alter database [dbCarniceria] set offline with rollback immediate", con);
                command.ExecuteNonQuery();

                command = new SqlCommand("restore database [dbCarniceria] from disk = @path", con);
                command.Parameters.AddWithValue("path", cadena);
                command.ExecuteNonQuery();

                command = new SqlCommand("alter database [dbCarniceria] set online", con);
                command.ExecuteNonQuery();
            }
        }
    }
}
