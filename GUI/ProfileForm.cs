using BEL;
using BLL;
using Interfaces;
using Microsoft.VisualBasic;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceClasses;
namespace GUI
{
    public partial class ProfileForm : Form, ITraducible
    {
        bllUsuario BllUsuario;
        string msgInsertPermissionName;
        string msgInsertProfileName;
        string msgNonSelectedPermission;
        string msgSelectAPermission;
        belUsuario usuario;
        public ProfileForm(belUsuario pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
            BllUsuario = new bllUsuario();
            lblProfileName.Text = pUsuario.Perfil.Nombre;
            ActualizarListBoxPermisos();
            ActualizarTreeView();
            ActualizarListBoxPerfiles();
            HabilitarControles();
        }
        public void Update(string pCodigoIdioma)
        {
            Idioma pIdioma = LanguageManager.ListaIdioma.Find(x => x.Id == pCodigoIdioma);
            lblActualProfile.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblActualProfile").Texto;
            lblProfiles.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblProfiles").Texto;
            lblPermissions.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblPermissions").Texto;
            btnAssignProfile.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnAssignProfile").Texto;
            btnRemoveProfile.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnRemoveProfile").Texto;
            btnCreateProfile.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnCreateProfile").Texto;
            btnCreatePermission.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnCreatePermission").Texto;
            btnClose.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnClose").Texto;
            rbLeaf.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "rbLeaf").Texto;
            rbComposite.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "rbComposite").Texto;
            msgInsertPermissionName = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgInsertPermissionName").Texto;
            msgInsertProfileName = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgInsertProfileName").Texto;
            msgNonSelectedPermission = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgNonSelectedPermission").Texto;
            msgSelectAPermission = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgSelectAPermission").Texto;
            this.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "frmProfile").Texto;
        }
        private void HabilitarControles()
        {
            List<Permiso> lPermiso = new List<Permiso>();
            (SessionManager.GetInstance.user.Perfil.Permiso as PermisoCompuesto).RellenaArrayPermisos(SessionManager.GetInstance.user.Perfil.Permiso as PermisoCompuesto, lPermiso);
            foreach(Control control in this.Controls)
            {
                if(control is Button && control.Tag != null)
                {
                    (control as Button).Enabled = false;
                    foreach (Permiso per in lPermiso)
                    {
                        if(control.Tag.ToString() == per.Nombre)
                        {
                            (control as Button).Enabled = true;
                        }
                    }
                }
            }
        }
        private void btnCreatePermission_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null) 
            {
                Permiso permiso;
                string nombre = Interaction.InputBox(msgInsertPermissionName);
                if (rbLeaf.Checked)
                {
                    permiso = new PermisoSimple(nombre);
                }
                else
                {
                    permiso = new PermisoCompuesto(nombre);
                }
                if (treeView1.SelectedNode.Name == "Permisos")
                {
                    PermisoCompuesto per = ProfileManager.PermisoRaiz;
                    per.AgregarPermiso(permiso);
                    ProfileManager.AltaPermisoConRelacion(permiso);
                }
                else
                {
                    PermisoCompuesto per = ProfileManager.PermisoRaiz.BuscarPermisoNombre(treeView1.SelectedNode.Text, ProfileManager.PermisoRaiz) as PermisoCompuesto;
                    per.AgregarPermiso(permiso);
                    ProfileManager.AltaPermisoConRelacion(permiso, per);
                }
                LogManager.AgregarLogEvento($"PERFILES - Permiso Creado ({permiso.Nombre})", 3,SessionManager.GetInstance.user);
                ActualizarTreeView();
                ActualizarListBoxPermisos();
            }
            else
            {
                MessageBox.Show(msgSelectAPermission);
            }
        }
        private void ActualizarTreeView()
        {
            treeView1.Nodes.Clear();
            TreeNode aux = new TreeNode("Permisos");
            aux.Name = "Permisos";
            treeView1.Nodes.Add(aux);
            ActualizarTreeViewRecursiva(ProfileManager.PermisoRaiz, aux);
        }
        private void ActualizarTreeViewRecursiva(PermisoCompuesto raiz, TreeNode nraiz)
        {
            foreach(Permiso per in raiz.ListaPermiso)
            {
                TreeNode aux = new TreeNode(per.Nombre);
                aux.Name = per.Nombre;
                nraiz.Nodes.Add(aux);
                if(per is PermisoCompuesto)
                {
                    nraiz = aux;
                    ActualizarTreeViewRecursiva(per as PermisoCompuesto, nraiz);
                    nraiz = aux.Parent;
                }
            }
        }
        private void ActualizarListBoxPermisos()
        {
            listBox2.Items.Clear();
            ActualizarListBoxPermisosRecursiva(ProfileManager.PermisoRaiz);
        }
        private void ActualizarListBoxPermisosRecursiva(PermisoCompuesto raiz)
        {         
            foreach (Permiso per in raiz.ListaPermiso)
            {
                if(listBox2.FindString(per.Nombre) >= 0)
                {

                }
                else
                {
                    listBox2.Items.Add(per.Nombre.ToString());
                    if (per is PermisoCompuesto)
                    {
                        ActualizarListBoxPermisosRecursiva((PermisoCompuesto)per);
                    }
                }
            }
        }
        private void ActualizarListBoxPerfiles()
        {
            listBox1.Items.Clear();
            foreach(Perfil per in ProfileManager.ListaPerfil)
            {
                listBox1.Items.Add(per.Nombre);
            }
        }
        private void btnCreateProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if(treeView1.SelectedNode == null && listBox1.SelectedItem == null)
                {
                    throw new Exception(msgNonSelectedPermission);
                }
                string nombre = Interaction.InputBox(msgInsertProfileName);
                Permiso permiso = ProfileManager.PermisoRaiz.BuscarPermisoNombre(listBox2.Text, ProfileManager.PermisoRaiz);
                Perfil perfil = new Perfil(nombre, permiso);
                ProfileManager.AltaPerfil(perfil);
                ActualizarListBoxPerfiles();
                LogManager.AgregarLogEvento($"PERFILES - Perfil creado ({perfil.Nombre})", 3, SessionManager.GetInstance.user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRemoveProfile_Click(object sender, EventArgs e)
        {
            Perfil aux = ProfileManager.ListaPerfil.Find(x => x.Nombre == listBox1.Text);
            ProfileManager.BajaPerfil(aux.Id);
            List<belUsuario> lUsuario = BllUsuario.Consulta();
            if(lUsuario.Exists(x => x.Perfil == aux))
            {
                belUsuario usuario = lUsuario.Find(x => x.Perfil == aux);
                usuario.Perfil = ProfileManager.ListaPerfil.Find(x => x.Nombre == "Basico");
                BllUsuario.Modificacion(usuario);
            }
            ActualizarListBoxPerfiles();
            HabilitarControles();
            LogManager.AgregarLogEvento($"PERFILES - Perfil eliminado ({aux.Nombre})", 3, SessionManager.GetInstance.user);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            LanguageManager.Desuscribir(this);
            this.Dispose();
            this.Close();
        }
        private void btnAssignProfile_Click(object sender, EventArgs e)
        {
            Perfil aux = ProfileManager.ListaPerfil.Find(x => x.Nombre == listBox1.Text);
            usuario.Perfil = aux;
            lblProfileName.Text = usuario.Perfil.Nombre;
            BllUsuario.Modificacion(usuario);
            HabilitarControles();
            LogManager.AgregarLogEvento($"PERFILES - Perfil asignado ({aux.Nombre} a {usuario.Username})", 3, SessionManager.GetInstance.user);
        }
        private void btnPermissionDelete_Click(object sender, EventArgs e)
        {
            string nombre = listBox2.Text;
            Permiso permiso = ProfileManager.PermisoRaiz.BuscarPermisoNombre(nombre, ProfileManager.PermisoRaiz);
            ProfileManager.BajaPermiso(permiso.Id);
            RecursivaEliminarPermiso(permiso as PermisoCompuesto);
            ActualizarListBoxPermisos();
            ActualizarTreeView();
            ActualizarListBoxPerfiles();
            HabilitarControles();
            LogManager.AgregarLogEvento($"PERFILES - Permiso eliminado ({nombre}))", 3, SessionManager.GetInstance.user);
        }
        private void RecursivaEliminarPermiso(PermisoCompuesto pPermisoActual)
        {
            if(pPermisoActual.ListaPermiso.Count > 0)
            {
                foreach (Permiso per in pPermisoActual.ListaPermiso)
                {
                    ProfileManager.BajaPermiso(per.Id);
                    if (per is PermisoCompuesto)
                    {
                        RecursivaEliminarPermiso(per as PermisoCompuesto);
                    }
                }
            }
        }
    }
}
