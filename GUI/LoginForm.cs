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
using Interfaces;
namespace GUI
{
    public partial class LoginForm : Form, ITraducible
    {
        List<belUsuario> ListaUsuario;
        bllUsuario bllusuario;
        string msgBlockedAccount;
        string msgWrongPassword;
        string msgNoExistAccount;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ListaUsuario = bllusuario.Consulta();
            string inputUsername = textBox1.Text;
            string inputPassword = textBox2.Text;
            if (ListaUsuario.Exists(x => x.Username == inputUsername))
            {
                    belUsuario User = ListaUsuario.Find(x => x.Username == inputUsername);
                if (CryptoManager.Compare(inputPassword, User.Password) == 1 && User.Blocked == false)
                {
                    MainForm formPrincipalInstance = new MainForm();
                    SessionManager.Login(User);
                    formPrincipalInstance.SessionManager = SessionManager.GetInstance;
                    this.Hide();
                    LanguageManager.Suscribir(formPrincipalInstance);
                    LogManager.Add("LOGIN - Login", User);
                    formPrincipalInstance.ShowDialog();
                    this.Close();
                }
                else
                {
                    if(User.Blocked == false)
                    {
                        MessageBox.Show(msgWrongPassword, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        User.Intentos -= 1;
                        LogManager.Add("LOGIN - Incorrect password", User);
                        if (User.Intentos == 0)
                        {
                            User.Blocked = true;
                            bllusuario.Modificacion(User);
                            MessageBox.Show(msgBlockedAccount, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LogManager.Add("LOGIN - Account blocking for missed attempts", User);
                        }
                    }
                    else
                    {
                        MessageBox.Show(msgBlockedAccount, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LogManager.Add("LOGIN - Blocked account login attempt", User);
                    }
                }
            }
            else{MessageBox.Show(msgNoExistAccount, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        }
        private void FormLogIn_Load(object sender, EventArgs e)
        {
            bllusuario = new bllUsuario();
            LanguageManager.Suscribir(this);
            comboBoxImage1.RetornaComboBox().SelectedIndex = 0;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSee.Checked) { textBox2.UseSystemPasswordChar = false; }
            else { textBox2.UseSystemPasswordChar = true; }
        }

        public void Update(Idioma pIdioma)
        {
            lblUser.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblUser").Texto;
            lblPassword.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblPassword").Texto;
            cbSee.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "cbSee").Texto;
            btnLogin.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnLogin").Texto;
            msgBlockedAccount = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgBlockedAccount").Texto;
            msgWrongPassword = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgWrongPassword").Texto;
            msgNoExistAccount = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgNoExistAccount").Texto;
            this.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "frmLogin").Texto;
        }
    }
}
