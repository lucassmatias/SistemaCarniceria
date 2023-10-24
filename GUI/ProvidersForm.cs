﻿using BEL;
using BLL;
using Microsoft.VisualBasic;
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
    public partial class ProvidersForm : Form
    {
        List<belProveedor> listProveedor;
        bllProveedor bllProveedor;
        bllCotizacion bllCotizacion;
        public ProvidersForm()
        {
            InitializeComponent();
        }
        private void RefrescarListbox()
        {
            listBox1.Items.Clear();
            foreach(belProveedor pro in listProveedor)
            {
                listBox1.Items.Add($"{pro.Id}- {pro.Nombre}");
            }
        }

        private void ProvidersForm_Load(object sender, EventArgs e)
        {
            bllProveedor = new bllProveedor();
            bllCotizacion = new bllCotizacion();
            listProveedor = bllProveedor.Consulta();
            RefrescarListbox();
            RefrescarDataGrid(null, null);
            listBox1.SelectedIndexChanged += RefrescarDataGrid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                belProveedor aux = new belProveedor();
                string nombre = Interaction.InputBox("Nombre:");
                aux.Nombre = nombre;
                bllProveedor.Alta(aux);
                listProveedor = bllProveedor.Consulta();
                RefrescarListbox();
                RefrescarDataGrid(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string codigo = listBox1.Items[listBox1.SelectedIndex].ToString();
                codigo = codigo.Split('-')[0];
                codigo.TrimEnd();
                belProveedor aux = listProveedor.Find(x => x.Id == codigo);
                bllProveedor.Baja(codigo);
                if(aux.ListaCotización.Count != 0)
                {
                    bllCotizacion.Baja(codigo);
                }
                listProveedor = bllProveedor.Consulta();
                RefrescarListbox();
                RefrescarDataGrid(null, null);
            }
        }
        private void RefrescarDataGrid(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (listBox1.SelectedIndex != -1)
            {
                string codigo = listBox1.Items[listBox1.SelectedIndex].ToString();
                codigo = codigo.Split('-')[0];
                codigo.TrimEnd();
                belProveedor aux = listProveedor.Find(x => x.Id == codigo.ToString());
                foreach(PropertyInfo a in aux.GetType().GetProperties())
                {
                    if(a.Name != "ListaCotización")
                    {
                        DataGridViewRow dgvRow = new DataGridViewRow();
                        dgvRow.CreateCells(dataGridView1);
                        dgvRow.Cells[0].Value = a.Name;
                        dgvRow.Cells[0].ReadOnly = true;
                        dgvRow.Cells[1].Value = a.GetValue(aux);
                        dgvRow.Cells[1].ReadOnly = false;
                        if(a.Name == "Id")
                        {
                            dgvRow.ReadOnly = true;
                        }
                        DataGridViewRow dgvRowClear = new DataGridViewRow();
                        dgvRowClear.ReadOnly = true;
                        dataGridView1.Rows.Add(dgvRow);
                        dataGridView1.Rows.Add(dgvRowClear);
                    }           
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex != -1)
                {
                    string codigo = listBox1.Items[listBox1.SelectedIndex].ToString();
                    codigo = codigo.Split('-')[0];
                    codigo.TrimEnd();
                    belProveedor proveedor = listProveedor.Find(x => x.Id == codigo);
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            PropertyInfo campo = proveedor.GetType().GetProperty(row.Cells[0].Value.ToString());
                            if(campo.PropertyType == typeof(decimal))
                            {
                                decimal valor = 0;
                                decimal.TryParse(row.Cells[1].Value.ToString(), out valor);
                                campo.SetValue(proveedor, valor);
                            }
                            else
                            {
                                campo.SetValue(proveedor, row.Cells[1].Value.ToString());
                            }                      
                        }
                    }
                    bllProveedor.Modificacion(proveedor);
                    listProveedor = bllProveedor.Consulta();
                    RefrescarListbox();
                    RefrescarDataGrid(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            string codigo = listBox1.Items[listBox1.SelectedIndex].ToString();
            codigo = codigo.Split('-')[0];
            codigo.TrimEnd();
            belProveedor proveedor = listProveedor.Find(x => x.Id == codigo);
            QuoteForm Quoteform = new QuoteForm(proveedor);
            this.Hide();
            Quoteform.ShowDialog();
            this.Show();
        }

        private void btnSolQuote_Click(object sender, EventArgs e)
        {
            QuoteRequestForm form = new QuoteRequestForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}