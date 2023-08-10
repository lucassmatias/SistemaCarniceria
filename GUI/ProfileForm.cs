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

namespace GUI
{
    public partial class ProfileForm : Form, ITraducible
    {
        List<belPermiso> lPermisos;
        List<belPerfil> lPerfiles;
        bllUsuario BllUsuario;
        bllPermiso BllPermiso;
        bllPerfil BllPerfil;
        string msgInsertPermissionName;
        string msgInsertProfileName;
        string msgNonSelectedPermission;
        string msgSelectAPermission;
        belUsuario usuario;
        public ProfileForm(belUsuario pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
            BllPermiso = new bllPermiso();
            lPermisos = BllPermiso.Consulta();
            BllPerfil = new bllPerfil();
            lPerfiles = BllPerfil.Consulta();
            BllUsuario = new bllUsuario();
            lblProfileName.Text = pUsuario.Perfil.Nombre;
            ActualizarListBoxPermisos();
            ActualizarTreeView();
            ActualizarListBoxPerfiles();
            HabilitarControles();
        }

        public void Update(Idioma pIdioma)
        {
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

        public void HabilitarControles()
        {
            List<belPermiso> lPermiso = new List<belPermiso>();
            (SessionManager.GetInstance.user.Perfil.Permiso as belPermisoCompuesto).RetornaArrayPermisos(SessionManager.GetInstance.user.Perfil.Permiso as belPermisoCompuesto, lPermiso);
            foreach(Control control in this.Controls)
            {
                if(control is Button && control.Tag != null)
                {
                    (control as Button).Enabled = false;
                    foreach (belPermiso per in lPermiso)
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
                belPermiso permiso;
                string nombre = Interaction.InputBox(msgInsertPermissionName);
                if (rbLeaf.Checked)
                {
                    permiso = new belPermisoSimple(nombre);
                }
                else
                {
                    permiso = new belPermisoCompuesto(nombre);
                }
                if (treeView1.SelectedNode.Name == "Permisos")
                {
                    belPermisoCompuesto per = lPermisos[0] as belPermisoCompuesto;
                    per.AgregarPermiso(permiso);
                    BllPermiso.AltaConRelacion(permiso);
                }
                else
                {
                    belPermisoCompuesto per = (lPermisos[0] as belPermisoCompuesto).BuscarPermisoNombre(treeView1.SelectedNode.Text, lPermisos[0] as belPermisoCompuesto, null) as belPermisoCompuesto;
                    per.AgregarPermiso(permiso);
                    BllPermiso.AltaConRelacion(permiso, per);
                }
                LogManager.Add($"PROFILES - Permission Created ({permiso.Nombre})", SessionManager.GetInstance.user);
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
            ActualizarTreeViewRecursiva(lPermisos[0] as belPermisoCompuesto, aux);
        }
        private void ActualizarTreeViewRecursiva(belPermisoCompuesto raiz, TreeNode nraiz)
        {
            foreach(belPermiso per in raiz.ListaPermiso)
            {
                TreeNode aux = new TreeNode(per.Nombre);
                aux.Name = per.Nombre;
                nraiz.Nodes.Add(aux);
                if(per is belPermisoCompuesto)
                {
                    nraiz = aux;
                    ActualizarTreeViewRecursiva(per as belPermisoCompuesto, nraiz);
                    nraiz = aux.Parent;
                }
            }
        }
        private void ActualizarListBoxPermisos()
        {
            listBox2.Items.Clear();
            ActualizarListBoxPermisosRecursiva(lPermisos[0] as belPermisoCompuesto);
        }
        private void ActualizarListBoxPermisosRecursiva(belPermisoCompuesto raiz)
        {         
            foreach (belPermiso per in raiz.ListaPermiso)
            {
                if(listBox2.FindString(per.Nombre) >= 0)
                {

                }
                else
                {
                    listBox2.Items.Add(per.Nombre.ToString());
                    if (per is belPermisoCompuesto)
                    {
                        ActualizarListBoxPermisosRecursiva((belPermisoCompuesto)per);
                    }
                }
            }
        }
        private void ActualizarListBoxPerfiles()
        {
            listBox1.Items.Clear();
            foreach(belPerfil per in lPerfiles)
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
                belPermiso permiso = (lPermisos[0] as belPermisoCompuesto).BuscarPermisoNombre(listBox2.Text, lPermisos[0] as belPermisoCompuesto, null);
                belPerfil perfil = new belPerfil(nombre, permiso);
                BllPerfil.Alta(perfil);
                lPerfiles = BllPerfil.Consulta();
                ActualizarListBoxPerfiles();
                LogManager.Add($"PROFILES - Profile Created ({perfil.Nombre})", SessionManager.GetInstance.user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveProfile_Click(object sender, EventArgs e)
        {
            belPerfil aux = lPerfiles.Find(x => x.Nombre == listBox1.Text);
            BllPerfil.Baja(aux.Id);
            lPerfiles = BllPerfil.Consulta();
            ActualizarListBoxPerfiles();
            LogManager.Add($"PROFILES - Profile Removed ({aux.Nombre})", SessionManager.GetInstance.user);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            LanguageManager.Desuscribir(this);
            this.Dispose();
            this.Close();
        }

        private void btnAssignProfile_Click(object sender, EventArgs e)
        {
            belPerfil aux = lPerfiles.Find(x => x.Nombre == listBox1.Text);
            usuario.Perfil = aux;
            lblProfileName.Text = usuario.Perfil.Nombre;
            BllUsuario.Modificacion(usuario);
            LogManager.Add($"PROFILES - Profile Assigned ({aux.Nombre} to {usuario.Username})", SessionManager.GetInstance.user);
        }
    }
}
