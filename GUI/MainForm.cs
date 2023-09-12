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
using BEL;
using ServiceClasses;
namespace GUI
{
    public partial class MainForm : Form, ITraducible
    {
        public SessionManager SessionManager;
        public MainForm()
        {
            InitializeComponent();
        }
        UsersForm userFormInstance;
        CartForm cartFormInstance;
        SaleForm saleFormInstance;
        LanguageForm languageFormInstance;
        LogForm logFormInstance;
        ProductForm productFormInstance;
        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarControles();
            userFormInstance = new UsersForm();
            cartFormInstance = new CartForm();
            saleFormInstance = new SaleForm();
            languageFormInstance = new LanguageForm();
            logFormInstance = new LogForm();
            productFormInstance = new ProductForm();
            LanguageManager.Suscribir(userFormInstance);
            LanguageManager.Suscribir(cartFormInstance);
            LanguageManager.Suscribir(saleFormInstance);
            LanguageManager.Suscribir(languageFormInstance);
            comboBoxImage1.RetornaComboBox().SelectedIndex = int.Parse(SessionManager.GetInstance.user.Idioma.Id) - 1;
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanguageManager.Desuscribir(this);
            LanguageManager.Desuscribir(userFormInstance);
            LanguageManager.Desuscribir(cartFormInstance);
            LanguageManager.Desuscribir(saleFormInstance);
            LanguageManager.Desuscribir(languageFormInstance);
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

        public void Update(string pCodigoIdioma)
        {
            Idioma pIdioma = LanguageManager.ListaIdioma.Find(x => x.Id == pCodigoIdioma);
            menuStripSystem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msSystem").Texto;
            userToolStripMenuItem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "tsUser").Texto;
            cartToolStripMenuItem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "tsCart").Texto;
            logOutToolStripMenuItem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "tsLogout").Texto;
            saleToolStripMenuItem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "tsSale").Texto;
            idiomaToolStripMenuItem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "tsLanguage").Texto;
            registroDeVentasToolStripMenuItem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "tsRegisters").Texto;
            productoToolStripMenuItem.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "tsInventory").Texto;
            lblTitle.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblTitle").Texto;
            this.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "frmMain").Texto;
        }

        private void usuarioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            userFormInstance.ShowDialog();
            this.Show();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            saleFormInstance.ShowDialog();
            this.Show();
        }
        private void MostrarControles()
        {           
            List<Permiso> lPermiso = new List<Permiso>();
            (SessionManager.GetInstance.user.Perfil.Permiso as PermisoCompuesto).RellenaArrayPermisos(SessionManager.GetInstance.user.Perfil.Permiso as PermisoCompuesto, lPermiso);
            foreach(ToolStripMenuItem menu in menuStripSystem.Items)
            {
                foreach(ToolStripMenuItem item in menu.DropDownItems)
                {
                    if(item.Tag != null)
                    {
                        item.Visible = false;
                        foreach(Permiso per in lPermiso)
                        {
                            if(item.Tag.ToString() == per.Nombre)
                            {
                                item.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        private void idiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            languageFormInstance.ShowDialog();
            this.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            logFormInstance.ShowDialog();
            this.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            productFormInstance.ShowDialog();
            this.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupForm bk = new BackupForm();
            this.Hide();
            bk.ShowDialog();
            this.Show();
        }
    }
}
