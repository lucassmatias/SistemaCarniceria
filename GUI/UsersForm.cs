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
using BLL;
using Microsoft.VisualBasic.ApplicationServices;

namespace GUI
{
    public partial class UsersForm : Form
    {
        List<belUsuario> ListaUsuario;
        bllUsuario bllUsuario;
        public UsersForm()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            bllUsuario = new bllUsuario();
            ListaUsuario = bllUsuario.Consulta();
            RefreshDataGrid();
        }
        private void RefreshDataGrid()
        {
            UserFilterByName(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == string.Empty && textBox2.Text == string.Empty)
                {
                    throw new Exception("No puede dejar campos vacios");
                }
                else
                {
                    bllUsuario.Alta(new belUsuario(textBox1.Text, CryptoManager.Encrypt(textBox2.Text)));
                    ListaUsuario = bllUsuario.Consulta();
                    RefreshDataGrid();
                    LogManager.Add($"USUARIO - Se creó un nuevo usuario ({textBox1.Text})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                bllUsuario.Baja((dataGridView1.SelectedRows[0].DataBoundItem as belUsuario).Id);
                LogManager.Add($"USUARIO - Se eliminó un usuario ({(dataGridView1.SelectedRows[0].DataBoundItem as belUsuario).Id})");
                ListaUsuario = bllUsuario.Consulta();
                RefreshDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                belUsuario aux = dataGridView1.SelectedRows[0].DataBoundItem as belUsuario;
                string name = Interaction.InputBox("Nombre", "Modificación", aux.Name);
                string pw = CryptoManager.Encrypt(Interaction.InputBox("Contraseña", "Modificación"));
                if(name == string.Empty || pw == string.Empty)
                {
                    throw new Exception("No puede dejar campos vacios");
                }
                else
                {
                    aux.Name = name;
                    aux.Password = pw;
                    bllUsuario.Modificacion(aux);
                    ListaUsuario = bllUsuario.Consulta();
                    RefreshDataGrid();
                    LogManager.Add($"USUARIO - Se modificó un usuario ({aux.Id})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            belUsuario aux = dataGridView1.SelectedRows[0].DataBoundItem as belUsuario;
            aux.Blocked = false;
            bllUsuario.Modificacion(aux);
            ListaUsuario = bllUsuario.Consulta();
            RefreshDataGrid();
            LogManager.Add($"USUARIO - Se desbloqueó un usuario ({aux.Id})");
        }
        private void EnableBtnUnlockFunction()
        {
            if(dataGridView1.SelectedRows.Count != 0)
            {
                btnUnlock.Enabled = (dataGridView1.SelectedRows[0].DataBoundItem as belUsuario).Blocked == true ? true : false;
            }       
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
