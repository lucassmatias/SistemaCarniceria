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
using Interfaces;

namespace GUI
{
    public partial class UsersForm : Form, ITraducible
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
                    bllUsuario.Alta(new belUsuario(tbDNI.Text, tbUsername.Text, CryptoManager.Encrypt(tbContraseña.Text), tbNombre.Text, tbApellido.Text, tbEmail.Text, tbRol.Text, LanguageManager.GetInstance.ConsultaIdiomaCodigo(comboBoxImage1.RetornaComboBox().SelectedIndex + 1)));
                    ListaUsuario = bllUsuario.Consulta();
                    RefreshDataGrid();
                    //LogManager.Add($"USUARIO - Se creó un nuevo usuario ({tbUsername.Text})");
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
                bllUsuario.Baja(SeleccionarUsuario().Id);
                //LogManager.Add($"USUARIO - Se eliminó un usuario ({(dataGridView1.SelectedRows[0].DataBoundItem as belUsuario).Id})");
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
                belUsuario aux = SeleccionarUsuario();
                string dni = Interaction.InputBox("DNI", "Modificación", aux.DNI);
                string username = Interaction.InputBox("Nombre de usuario", "Modificación", aux.Username);
                string pw = CryptoManager.Encrypt(Interaction.InputBox("Contraseña", "Modificación"));
                string nombre = Interaction.InputBox("Nombre", "Modificación", aux.Nombre);
                string apellido = Interaction.InputBox("Apellido", "Modificación", aux.Apellido);
                string rol = Interaction.InputBox("Nombre", "Modificación", aux.Rol);
                string email = Interaction.InputBox("Nombre", "Modificación", aux.Email);
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
                //LogManager.Add($"USUARIO - Se modificó un usuario ({aux.Id})");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            belUsuario aux = SeleccionarUsuario();
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
            //LogManager.Add($"USUARIO - Cambio el estado de bloqueo de un usuario ({aux.Id})");
        }
        private void EnableBtnUnlockFunction()
        {
            if(dataGridView1.SelectedRows.Count != 0)
            {
                btnUnlock.Enabled = SeleccionarUsuario().Blocked == true ? true : false;
            }       
        }
        private belUsuario SeleccionarUsuario()
        {
            return ListaUsuario.Find(x => x.Id == dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
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
            CargarDGV(t);
        }
        private void CargarDGV(List<belUsuario> pLista)
        {
            dataGridView1.Rows.Clear();
            foreach (belUsuario x in pLista)
            {
                dataGridView1.Rows.Add(new object[] { x.Id, x.DNI, x.Username, x.Password, x.Blocked, x.Nombre, x.Apellido, x.Email, x.Rol, x.Activo, x.Intentos, x.Idioma.Nombre });
            }
        }
        private void UserFilterByState(object sender, EventArgs e)
        {
            List<belUsuario> t = ListaUsuario;
            if(cbBlocked.Checked) t = ListaUsuario.Where(x => x.Blocked == cbBlocked.Checked).ToList<belUsuario>();
            CargarDGV(t);
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
            belUsuario aux = SeleccionarUsuario();
            if (aux.Activo)
            {
                aux.Activo = false;
            }
            else
            {
                aux.Activo = true;
            }
            bllUsuario.Modificacion(aux);
            ListaUsuario = bllUsuario.Consulta();
            RefreshDataGrid();
            //LogManager.Add($"USUARIO - Cambio el estado de activo de un usuario ({aux.Id})");
        }

        public void Update(Idioma pIdioma)
        {
            lblUserM.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblUserM").Texto;
            rbActive.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "rbActive").Texto;
            rbAll.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "rbAll").Texto;
            cbBlocked.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "cbBlocked").Texto;
            lblFilter.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblFilter").Texto;
            lblId.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblId").Texto;
            lblUsername.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblUsername").Texto;
            lblPassword.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblPassword").Texto;
            lblName.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblName").Texto;
            lblSurname.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblSurname").Texto;
            lblEmail.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblEmail").Texto;
            lblRole.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblRole").Texto;
            lblLanguage.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblLanguage").Texto;
            btnAdd.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnAdd").Texto;
            btnRemove.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnRemove").Texto;
            btnUnlock.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnUnlock").Texto;
            btnActive.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnActive").Texto;
            btnClose.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnClose").Texto;
            clmId.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmId").Texto;
            clmUniqueId.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmUniqueId").Texto;
            clmUsername.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmUsername").Texto;
            clmPassword.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmPassword").Texto;
            clmName.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmName").Texto;
            clmSurname.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmSurname").Texto;
            clmBlocked.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmBlocked").Texto;
            clmEmail.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmEmail").Texto;
            clmRole.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmRole").Texto;
            clmActive.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmActive").Texto;
            clmTrys.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmTrys").Texto;
            clmLanguage.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmLanguage").Texto;
        }
    }
}
