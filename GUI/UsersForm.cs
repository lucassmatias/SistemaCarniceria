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

        private bool tbValidation()
        {
            bool tbValidation = false;
            if(tbDNI.Text == string.Empty ||
                tbUsername.Text == string.Empty ||
                tbContraseña.Text == string.Empty ||
                tbNombre.Text == string.Empty ||
                tbApellido.Text == string.Empty ||
                tbEmail.Text == string.Empty ||
                tbRol.Text == string.Empty)
            {
                tbValidation = true;
            }
            return tbValidation;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(tbValidation())
                {
                    throw new Exception("No puede dejar campos vacios");
                }
                else
                {
                    bllUsuario.Alta(new belUsuario(tbDNI.Text, tbUsername.Text, CryptoManager.Encrypt(tbContraseña.Text), tbNombre.Text, tbApellido.Text, tbEmail.Text, tbRol.Text));
                    ListaUsuario = bllUsuario.Consulta();
                    RefreshDataGrid();
                    LogManager.Add($"USUARIO - Se creó un nuevo usuario ({tbUsername.Text})");
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
                string dni = Interaction.InputBox("DNI", "Modificación", aux.DNI);
                string username = Interaction.InputBox("Nombre de usuario", "Modificación", aux.Username);
                string pw = CryptoManager.Encrypt(Interaction.InputBox("Contraseña", "Modificación"));
                string nombre = Interaction.InputBox("Nombre", "Modificación", aux.Nombre);
                string apellido = Interaction.InputBox("Apellido", "Modificación", aux.Apellido);
                string rol = Interaction.InputBox("Nombre", "Modificación", aux.Rol);
                string email = Interaction.InputBox("Nombre", "Modificación", aux.Email);
                if (tbValidation())
                {
                    throw new Exception("No puede dejar campos vacios");
                }
                else
                {
                    aux.DNI = dni;
                    aux.Username = username;
                    aux.Password = pw;
                    aux.Nombre = nombre;
                    aux.Apellido = apellido;
                    aux.Rol = rol;
                    aux.Email = email;
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
            if (aux.Blocked)
            {
                aux.Blocked = false;
            }
            else
            {
                aux.Blocked = true;
            }
            bllUsuario.Modificacion(aux);
            ListaUsuario = bllUsuario.Consulta();
            RefreshDataGrid();
            LogManager.Add($"USUARIO - Cambio el estado de bloqueo de un usuario ({aux.Id})");
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
            List<belUsuario> t = ListaUsuario.Where(x => x.Username.StartsWith(textBox3.Text)).ToList<belUsuario>();
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

        private void btnActive_Click(object sender, EventArgs e)
        {
            belUsuario aux = dataGridView1.SelectedRows[0].DataBoundItem as belUsuario;
            if (aux.Activo)
            {
                aux.Blocked = false;
            }
            else
            {
                aux.Blocked = true;
            }
            bllUsuario.Modificacion(aux);
            ListaUsuario = bllUsuario.Consulta();
            RefreshDataGrid();
            LogManager.Add($"USUARIO - Cambio el estado de activo de un usuario ({aux.Id})");
        }
    }
}
