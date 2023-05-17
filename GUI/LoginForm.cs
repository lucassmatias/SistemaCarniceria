﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BEL;
using BLL;
using Services;
using Controles;
namespace GUI
{
    public partial class LoginForm : Form
    {
        List<belUsuario> ListaUsuario;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string inputUsuario = textBox1.Text;
            string inputPassword = textBox2.Text;
            if (ListaUsuario.Exists(x => x.Name == inputUsuario))
            {
                belUsuario aux = ListaUsuario.Find(x => x.Name == inputUsuario);
                if (CryptoManager.Compare(inputPassword, aux.Password) == 1 && aux.Blocked == false)
                {
                    MainForm formPrincipalInstance = new MainForm();
                    SessionManager.Login(aux);
                    formPrincipalInstance.SessionManager = SessionManager.GetInstance;
                    this.Hide();
                    formPrincipalInstance.ShowDialog();
                    this.Close();
                }
                else
                {
                    if(aux.Blocked == false)
                    {
                        MessageBox.Show("Contraseña errónea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        aux.Intentos -= 1;
                        if (aux.Intentos == 0) aux.Blocked = true;
                    }
                    else
                    {
                        MessageBox.Show("Cuenta bloqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else{MessageBox.Show("No existe un usuario con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        }
        private void GenerarUsuarios()
        {
            ListaUsuario.Add(new belUsuario("Lucas", CryptoManager.Encrypt("123"), false, 3, "1"));
            ListaUsuario.Add(new belUsuario("Felipe", CryptoManager.Encrypt("147"), false, 3, "2"));
            ListaUsuario.Add(new belUsuario("Nicoll", CryptoManager.Encrypt("159"), true, 3, "3"));
            ListaUsuario.Add(new belUsuario("Franco", CryptoManager.Encrypt("951"), false, 1, "4"));
        }
        private void FormLogIn_Load(object sender, EventArgs e)
        {
            ListaUsuario = new List<belUsuario>();
            GenerarUsuarios();
            comboBoxImage1.RetornaComboBox().SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox2.UseSystemPasswordChar = false; }
            else { textBox2.UseSystemPasswordChar = true; }
        }
    }
}