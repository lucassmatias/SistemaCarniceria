using BEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using Services;
namespace GUI
{
    public partial class UsersForm : Form
    {
        List<belUsuario> ListaUsuario;
        public UsersForm()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            ListaUsuario = new List<belUsuario>();
            GenerarUsuarios();
            RefreshDataGrid();
        }
        private void RefreshDataGrid()
        {
            UserFilterByName(null, null);
        }
        private void GenerarUsuarios()
        {
            ListaUsuario.Add(new belUsuario("Lucas", CryptoManager.Encrypt("123"), false, 3, "1"));
            ListaUsuario.Add(new belUsuario("Felipe", CryptoManager.Encrypt("147"), false, 3, "2"));
            ListaUsuario.Add(new belUsuario("Nicoll", CryptoManager.Encrypt("159"), true, 3, "3"));
            ListaUsuario.Add(new belUsuario("Franco", CryptoManager.Encrypt("951"), false, 1, "4"));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int idAux = 1;
            if(ListaUsuario.Count > 0) idAux = int.Parse(ListaUsuario.Last<belUsuario>().Id) + 1;
            ListaUsuario.Add(new belUsuario(textBox1.Text, CryptoManager.Encrypt(textBox2.Text), false, 3, $"{idAux}"));
            RefreshDataGrid();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListaUsuario.Remove(ListaUsuario.Find(x => x.Id == (dataGridView1.SelectedRows[0].DataBoundItem as belUsuario).Id));
            RefreshDataGrid();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            belUsuario aux = dataGridView1.SelectedRows[0].DataBoundItem as belUsuario;
            aux.Name = Interaction.InputBox("Nombre", "Modificación", aux.Name);
            aux.Password = CryptoManager.Encrypt((Interaction.InputBox("Contraseña", "Modificación")));
            RefreshDataGrid();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            (dataGridView1.SelectedRows[0].DataBoundItem as belUsuario).Blocked = false;
            RefreshDataGrid();
        }
        private void EnableBtnUnlockFunction()
        {
            btnUnlock.Enabled = (dataGridView1.SelectedRows[0].DataBoundItem as belUsuario).Blocked == true ? true : false; 
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EnableBtnUnlockFunction();
            }
            catch
            {

            }           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UserFilterByName(object sender, EventArgs e)
        {
            List<belUsuario> t = ListaUsuario.Where(x => x.Name.StartsWith(textBox3.Text)).ToList<belUsuario>();
            dataGridView1.DataSource = null; dataGridView1.DataSource = t;
        }
        private void UserFilterByState(object sender, EventArgs e)
        {
            List<belUsuario> t = ListaUsuario;
            if(checkBox1.Checked) t = ListaUsuario.Where(x => x.Blocked == checkBox1.Checked).ToList<belUsuario>();
            dataGridView1.DataSource = null; dataGridView1.DataSource = t;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            UserFilterByName(null, null);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UserFilterByState(null, null);
        }
    }
}
