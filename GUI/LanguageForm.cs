using Interfaces;
using Microsoft.VisualBasic;
using ServiceClasses;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class LanguageForm : Form, ITraducible
    {
        public LanguageForm()
        {
            InitializeComponent();
        }
        string msgInsertLanguageName;
        string msgSelectALanguage;
        string msgInsertText;
        Idioma IdiomaActual = null;
        private void LanguageForm_Load(object sender, EventArgs e)
        {
            comboBoxImageNotEvent1.RetornaComboBox().SelectedIndexChanged += SeleccionarIdioma;
            RefrescarListBox();
            textBox2.Text = "";
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1 && comboBoxImageNotEvent1.RetornaComboBox().SelectedIndex != -1) 
            {
                string name = listBox1.Text;           
                if(IdiomaActual.ListaEtiquetas.Exists(x => x.Tag == name) == false)
                {
                    textBox1.Text = msgInsertText;
                }
                else
                {
                    textBox1.Text = IdiomaActual.ListaEtiquetas.Find(x => x.Tag == name).Texto;
                }                        
            }
        }
        private void SeleccionarIdioma(object sender, EventArgs e)
        {
            int index = comboBoxImageNotEvent1.RetornaComboBox().SelectedIndex + 1;
            IdiomaActual = LanguageManager.ListaIdioma.Find(x => x.Id == index.ToString());
        }
        private void RefrescarListBox()
        {
            foreach (Etiqueta eti in LanguageManager.ListaIdioma[0].ListaEtiquetas)
            {
                listBox1.Items.Add(eti.Tag);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdiomaActual != null)
                {
                    string nombre = Interaction.InputBox(msgInsertLanguageName);
                    foreach(Idioma idi in LanguageManager.ListaIdioma)
                    {
                        LanguageManager.AltaEtiqueta(idi.Id, nombre);
                    }
                    LanguageManager.ListaIdioma[int.Parse(IdiomaActual.Id) - 1] = LanguageManager.ConsultaIdiomaCodigo(int.Parse(IdiomaActual.Id));
                    RefrescaComboBox();
                    RefrescarListBox();
                    LogManager.AgregarLogEvento($"IDIOMA - Tag creado ({nombre}))", 3, SessionManager.GetInstance.user);
                }
                else
                {
                    throw new Exception(msgSelectALanguage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RefrescaComboBox()
        {
            int i = comboBoxImageNotEvent1.RetornaComboBox().SelectedIndex;
            comboBoxImageNotEvent1.RetornaComboBox().SelectedIndex = 0;
            comboBoxImageNotEvent1.RetornaComboBox().SelectedIndex = i;
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdiomaActual != null && listBox1.SelectedIndex != -1)
                {
                    string index = IdiomaActual.Id;
                    string tag = listBox1.Text;
                    string txt = textBox1.Text;
                    LanguageManager.ModificarEtiqueta(index, tag, txt);
                    RefrescaComboBox();
                    RefrescarListBox();
                    LanguageManager.CambiarIdioma(SessionManager.GetInstance.user.Idioma.Id);
                    LogManager.AgregarLogEvento($"IDIOMA - Texto modificado ({txt}))", 3, SessionManager.GetInstance.user);
                }
                else
                {
                    throw new Exception(msgSelectALanguage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(IdiomaActual != null)
            {
                listBox1.Items.Clear();
                foreach (Etiqueta eti in IdiomaActual.ListaEtiquetas)
                {
                    if (eti.Tag.Contains(textBox2.Text))
                    {
                        listBox1.Items.Add(eti.Tag);
                    }
                }
            }
        }
        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Update(string pCodigoIdioma)
        {
            Idioma pIdioma = LanguageManager.ListaIdioma.Find(x => x.Id == pCodigoIdioma);
            lblLanguage.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblLanguage").Texto;
            lblSelectALanguage.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblSelectALanguage").Texto;
            lblFilter.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblFilter").Texto;
            btnAdd.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnAdd").Texto;
            btnModify.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnModify").Texto;
            btnClose.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnClose").Texto;
            msgInsertLanguageName = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgInsertLanguageName").Texto;
            msgSelectALanguage = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgSelectALanguage").Texto;
            msgInsertText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgInsertText").Texto;
            this.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "frmLanguage").Texto;
        }
    }
}
