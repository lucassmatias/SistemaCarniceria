using System;
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
        bllUsuario bllusuario;
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
                belUsuario User = ListaUsuario.Find(x => x.Name == inputUsuario);
                if (CryptoManager.Compare(inputPassword, User.Password) == 1 && User.Blocked == false)
                {
                    MainForm formPrincipalInstance = new MainForm();
                    SessionManager.Login(User);
                    formPrincipalInstance.SessionManager = SessionManager.GetInstance;
                    this.Hide();
                    formPrincipalInstance.ShowDialog();
                    this.Close();
                }
                else
                {
                    if(User.Blocked == false)
                    {
                        MessageBox.Show("Contraseña errónea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        User.Intentos -= 1;
                        LogManager.Add($"LOGIN - Contraseña errónea ({User.Name})");
                        if (User.Intentos == 0)
                        {
                            User.Blocked = true;
                            bllusuario.Modificacion(User);
                            MessageBox.Show("Cuenta bloqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LogManager.Add($"LOGIN - Bloqueo de cuenta por intentos excedidos ({User.Name})");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cuenta bloqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LogManager.Add($"LOGIN - Intento de inicio de sesión de cuenta bloqueada ({User.Name})");
                    }
                }
            }
            else{MessageBox.Show("No existe un usuario con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        }

        private void FormLogIn_Load(object sender, EventArgs e)
        {
            bllusuario = new bllUsuario();
            ListaUsuario = bllusuario.Consulta();
            comboBoxImage1.RetornaComboBox().SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox2.UseSystemPasswordChar = false; }
            else { textBox2.UseSystemPasswordChar = true; }
        }
    }
}
