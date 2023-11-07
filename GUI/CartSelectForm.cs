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
using System.Text.RegularExpressions;
using BLL;

namespace GUI
{
    public partial class CartSelectForm : Form
    {
        public belProveedor proveedor { get; set; }
        List<belCotizacion> cotizaciones;
        Regex ex;
        List<belPedidoCompraCarne> listcarne;
        bllPedidoCompra bllped;
        bllPedidoCompraCarne bllcar;
        public CartSelectForm(belProveedor pProveedor)
        {
            InitializeComponent();
            proveedor = pProveedor;
            cotizaciones = pProveedor.ListaCotización;
            ex = new Regex("[0-9]");
            listcarne = new List<belPedidoCompraCarne>();
            bllped = new bllPedidoCompra();
            bllcar = new bllPedidoCompraCarne();
        }
        private void CartSelectForm_Load(object sender, EventArgs e)
        {
            foreach(belCotizacion cot in cotizaciones)
            {
                dataGridView1.Rows.Add(new object[] {cot.Id, cot.Carne, cot.Cantidad, cot.Precio});
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0 && Validation()) 
            { 
                string codigo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string carneNombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                decimal cantidad = decimal.Parse(textBox1.Text);
                decimal precio = decimal.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                belPedidoCompraCarne ped = new belPedidoCompraCarne(carneNombre, cantidad, precio);
                listcarne.Add(ped);
                RefrescarDGV();
            }
        }
        private bool Validation()
        {
            bool s = false;
            string text = textBox1.Text;
            if(ex.IsMatch(text))
            {
                s = true;
            }
            return s;
        }
        private void RefrescarDGV()
        {
            dataGridView2.Rows.Clear();
            if(listcarne.Count > 0)
            {
                foreach(belPedidoCompraCarne p in listcarne)
                {
                    dataGridView2.Rows.Add(new object[] {p.Id, p.CarneNombre, p.Cantidad, p.PrecioUnitario, (p.Cantidad * p.PrecioUnitario)});
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count > 0)
            {
                string carneNombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                decimal cantidad = decimal.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                decimal precio = decimal.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                listcarne.Remove(listcarne.FindAll(x => x.CarneNombre == carneNombre && x.PrecioUnitario == precio && x.Cantidad == cantidad)[0]);
                RefrescarDGV();
            }
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count > 0)
            {
                decimal precio = 0;
                foreach(DataGridViewRow row in dataGridView2.Rows)
                {
                    precio += decimal.Parse(row.Cells[4].Value.ToString());
                }
                belPedidoCompra ped = new belPedidoCompra(proveedor, precio, DateTime.Now, false, false);
                bllped.Alta(ped);
                belPedidoCompra aux = bllped.Consulta().Last();
                foreach (belPedidoCompraCarne car in listcarne)
                {
                    car.Id = aux.Id;
                    bllcar.Alta(car);
                }
                this.Close();
            }
        }
    }
}
