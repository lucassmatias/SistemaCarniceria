using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using Interfaces;
namespace GUI
{
    public partial class MainForm : Form, ITraducible
    {
        public SessionManager SessionManager;
        public MainForm()
        {
            InitializeComponent();
        }
        UsersForm formUsuarioInstance;
        CartForm cartFormInstance;
        private void Form1_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance.CambiarIdioma(SessionManager.GetInstance.user.Idioma);
            formUsuarioInstance = new UsersForm();
            cartFormInstance = new CartForm();
            LanguageManager.Suscribir(formUsuarioInstance);
            LanguageManager.Suscribir(cartFormInstance);
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            formUsuarioInstance.ShowDialog();
            this.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanguageManager.Desuscribir(this);
            LanguageManager.EliminarInstancia();
            SessionManager.Logout();
            LoginForm LoginFormInstance = new LoginForm();
            this.Hide();
            LoginFormInstance.ShowDialog();
            this.Close();     
        }

        private void carritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            cartFormInstance.ShowDialog();
            this.Show();
        }

        public void Update(Idioma pIdioma)
        {
            menuStripSystem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msSystem").Texto;
            userToolStripMenuItem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "tsUser").Texto;
            cartToolStripMenuItem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "tsCart").Texto;
            logOutToolStripMenuItem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "tsLogout").Texto;
        }
    }
}
