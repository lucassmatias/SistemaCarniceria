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

namespace GUI
{
    public partial class CartForm : Form
    {
        List<belCarne> ListCarne;
        belCarrito Carrito;
        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dataGridView1.DataSource = ListCarne;
        }
        private void CargarDatos()
        {
            ListCarne = new List<belCarne>() { new belAve("Pollo", 261), new belVacuna("Bife", 300), new belPorcina("Nalga", 410) };
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bllCarrito.AgregarProducto(Carrito, dataGridView1.SelectedRows[0].DataBoundItem as belCarne, decimal.Parse(tbPesoBruto.Text), decimal.Parse(tbPesoNeto.Text));
            dataGridView2.DataSource = null;
            foreach (belCarneCarrito x in Carrito.Productos)
            {
                dataGridView2.Rows.Add(new object[] { x.Carne.Id, x.Carne.Nombre, x.Carne.PrecioKG, x.PesoNeto, x.PrecioNeto });
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count > 0)
            {
                bllCarrito.QuitarProducto(Carrito, dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            }         
        }
    }
}
