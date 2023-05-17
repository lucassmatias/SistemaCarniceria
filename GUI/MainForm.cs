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
            listBox1.Items.Add(SessionManager.user.Name);
            listBox1.Items.Add(SessionManager.user.Password);
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
        }
    }
}
