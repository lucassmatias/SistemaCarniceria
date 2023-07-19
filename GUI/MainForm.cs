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
namespace GUI
{
    public partial class MainForm : Form
    {
        public SessionManager SessionManager;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm formUsuarioInstance = new UsersForm();
            this.Hide();
            formUsuarioInstance.ShowDialog();
            this.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            this.Close();
            LoginForm LoginFormInstance = new LoginForm();
            LoginFormInstance.ShowDialog();
        }

        private void carritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CartForm cartFormInstance = new CartForm();
            this.Hide();
            cartFormInstance.ShowDialog();
            this.Show();
        }
    }
}
