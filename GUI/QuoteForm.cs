using BEL;
using BLL;
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
using Services;
using Interfaces;

namespace GUI
{
    public partial class QuoteForm : Form
    {
        belProveedor proveedor;
        List<belCotizacion> cotizaciones;
        bllCotizacion bllCotizacion;
        bllCarne bllCarne;
        List<belCarne> listCarne;
        public QuoteForm(belProveedor pProveedor)
        {
            InitializeComponent();
            proveedor = pProveedor;
            bllCarne = new bllCarne();
            bllCotizacion = new bllCotizacion();
        }
        private void QuoteForm_Load(object sender, EventArgs e)
        {
            cotizaciones = bllCotizacion.ConsultaCondicional(proveedor.Id);
            listCarne = bllCarne.Consulta();
            RefrescarDataGrid();
            CargarComboBox();
        }
        private void RefrescarDataGrid()
        {
            dataGridView1.Rows.Clear();
            if(cotizaciones.Count != 0)
            {
                foreach(belCotizacion cot in cotizaciones)
                {
                    dataGridView1.Rows.Add(cot.Carne, cot.Cantidad, cot.Precio);
                }
            }
        }
        private void CargarComboBox()
        {
            comboBox1.Items.Clear();
            foreach(belCarne car in listCarne)
            {
                comboBox1.Items.Add(car.Nombre);
            }
        }
        private bool Validation()
        {
            bool flag = true;
            if (comboBox1.SelectedIndex == -1) flag = false;
            if (!decimal.TryParse(textBox1.Text, out decimal cantidad)) flag = false;
            if (!decimal.TryParse(textBox2.Text, out decimal precio)) flag = false;
            return flag;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                string carne = comboBox1.SelectedItem.ToString();
                decimal cantidad = decimal.Parse(textBox1.Text);
                decimal precio = decimal.Parse(textBox2.Text);
                belCotizacion aux = new belCotizacion(proveedor, carne, cantidad, precio);
                bllCotizacion.Alta(aux);
                cotizaciones = bllCotizacion.ConsultaCondicional(proveedor.Id);
                RefrescarDataGrid();
                LogManager.AgregarLogEvento($"COTIZACION - Cotizacion añadida ({proveedor.Id})", 2, SessionManager.GetInstance.user);
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                belCotizacion aux = cotizaciones.Find(x => x.Carne == row.Cells[0].Value.ToString());
                decimal.TryParse(Interaction.InputBox("Cantidad", "", row.Cells[1].Value.ToString()), out decimal cantidad);
                decimal.TryParse(Interaction.InputBox("Precio", "", row.Cells[2].Value.ToString()), out decimal precio);
                aux.Cantidad = cantidad;
                aux.Precio = precio;
                bllCotizacion.Modificacion(aux);
                cotizaciones = bllCotizacion.ConsultaCondicional(proveedor.Id);
                RefrescarDataGrid();
                LogManager.AgregarLogEvento($"COTIZACION - Cotizacion Modificada ({proveedor.Id})", 2, SessionManager.GetInstance.user);
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
    }
}
