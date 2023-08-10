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
        bllPerfil BllPerfil;
        string msgValidateError;
        string txtdni;
        string txtusername;
        string contraseña;
        string txtnombre;
        string txtapellido;
        string modificacion;
        public UsersForm()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            bllUsuario = new bllUsuario();
            BllPerfil = new bllPerfil();
            ListaUsuario = bllUsuario.Consulta();
            RefreshDataGrid();
            HabilitarControles();
        }
        private void RefreshDataGrid()
        {
            UserFilterByName(null, null);
        }
        public void HabilitarControles()
        {
            List<belPermiso> lPermiso = new List<belPermiso>();
            (SessionManager.GetInstance.user.Perfil.Permiso as belPermisoCompuesto).RetornaArrayPermisos(SessionManager.GetInstance.user.Perfil.Permiso as belPermisoCompuesto, lPermiso);
            foreach (Control control in this.Controls)
            {
                if (control is Button && control.Tag != null)
                {
                    (control as Button).Enabled = false;
                    foreach (belPermiso per in lPermiso)
                    {
                        if (control.Tag.ToString() == per.Nombre)
                        {
                            (control as Button).Enabled = true;
                        }
                    }
                }
            }
        }
        private bool tbValidation()
        {
            bool tbValidation = false;
            if(tbDNI.Text == string.Empty ||
                tbUsername.Text == string.Empty ||
                tbContraseña.Text == string.Empty ||
                tbNombre.Text == string.Empty ||
                tbApellido.Text == string.Empty ||
                tbEmail.Text == string.Empty)
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
                    throw new Exception(msgValidateError);
                }
                else
                {
                    belPerfil perfil = BllPerfil.Consulta().Find(x => x.Nombre == "Basico");
                    bllUsuario.Alta(new belUsuario(tbDNI.Text, tbUsername.Text, CryptoManager.Encrypt(tbContraseña.Text), tbNombre.Text, tbApellido.Text, tbEmail.Text, perfil, LanguageManager.ConsultaIdiomaCodigo(comboBoxImageNotEvent1.RetornaComboBox().SelectedIndex + 1)));
                    ListaUsuario = bllUsuario.Consulta();
                    RefreshDataGrid();
                    LogManager.Add($"USERS - User created ({tbUsername.Text})", SessionManager.GetInstance.user);
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
                LogManager.Add($"USERS - User deleted ({(dataGridView1.SelectedRows[0].DataBoundItem as belUsuario).Id})", SessionManager.GetInstance.user);
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
                string dni = Interaction.InputBox(txtdni, modificacion, aux.DNI);
                string username = Interaction.InputBox(txtusername, modificacion, aux.Username);
                string pw = CryptoManager.Encrypt(Interaction.InputBox(contraseña, modificacion));
                string nombre = Interaction.InputBox(txtnombre, modificacion, aux.Nombre);
                string apellido = Interaction.InputBox(txtapellido, modificacion, aux.Apellido);
                string email = Interaction.InputBox("email", modificacion, aux.Email);
                aux.DNI = dni;
                aux.Username = username;
                aux.Password = pw;
                aux.Nombre = nombre;
                aux.Apellido = apellido;
                aux.Email = email;
                bllUsuario.Modificacion(aux);
                ListaUsuario = bllUsuario.Consulta();
                RefreshDataGrid();
                LogManager.Add($"USERS - User Modified ({aux.Id})", SessionManager.GetInstance.user);
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
            LogManager.Add($"USERS - Changed block status from an user ({aux.Id})", SessionManager.GetInstance.user);
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
                dataGridView1.Rows.Add(new object[] { x.Id, x.DNI, x.Username, x.Password, x.Blocked, x.Nombre, x.Apellido, x.Email, x.Perfil.Nombre, x.Activo, x.Intentos, x.Idioma.Nombre });
                if (x.Blocked)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                }
                else if (x.Activo == false)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                }
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
            try
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
                LogManager.Add($"USERS - Changed active status from an user ({aux.Id})", SessionManager.GetInstance.user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
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
            lblLanguage.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblLanguage").Texto;
            btnAdd.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnAdd").Texto;
            btnModify.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnModify").Texto;
            btnRemove.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnRemove").Texto;
            btnUnlock.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnUnlock").Texto;
            btnActive.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnActive").Texto;
            btnClose.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnClose").Texto;
            btnProfile.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnProfile").Texto;
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
            msgValidateError = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgValidateError").Texto;
            txtdni = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmId").Texto;
            txtusername = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmUsername").Texto;
            contraseña = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmPassword").Texto;
            txtnombre = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmName").Texto;
            txtapellido = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmSurname").Texto;
            modificacion = pIdioma.ListaEtiquetas.Find(x => x.Tag == "txtModification").Texto;
            this.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "frmUser").Texto;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfileForm Profilef = new ProfileForm(SeleccionarUsuario());
            LanguageManager.Suscribir(Profilef);
            LanguageManager.CambiarIdioma(SessionManager.GetInstance.user.Idioma);
            Profilef.ShowDialog();
            CargarDGV(bllUsuario.Consulta());
            this.Show();
        }
    }
}
