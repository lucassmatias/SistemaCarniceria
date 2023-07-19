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
        belCarrito belCarrito;
        bllCarrito bllCarrito;
        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dataGridView1.DataSource = ListCarne;
            belCarrito = new belCarrito();
            bllCarrito = new bllCarrito();
            CargarEvento();
        }
        private void CargarDatos()
        {
            ListCarne = new List<belCarne>() { new belAve("1","Pollo", 261), new belVacuna("2", "Bife", 300), new belPorcina("3", "Nalga", 410) };
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.Rows.Count != 0)
                {
                    bllCarrito.AgregarProducto(belCarrito, dataGridView1.SelectedRows[0].DataBoundItem as belCarne, decimal.Parse(tbPesoBruto.Text), decimal.Parse(tbPesoNeto.Text));
                    dataGridView2.Rows.Clear();
                    foreach (belCarneCarrito x in belCarrito.Productos)
                    {
                        dataGridView2.Rows.Add(new object[] { x.Carne.Id, x.Carne.Nombre, x.Carne.PrecioKG, x.PesoNeto, x.PrecioNeto });
                    }
                }
                decimal total = 0;
                foreach (DataGridViewRow dr in dataGridView2.Rows)
                {
                    total += decimal.Parse(dr.Cells[4].Value.ToString());
                }
                belCarrito.ImporteBruto = total;
                dataGridView2.Rows.Add(new string[] { "", "", "", "Precio Total =>", $"{total}" });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Filtro(object sender, EventArgs e)
        {
            if(CbAve.Checked == false && CbPorcina.Checked == false && CbVacuna.Checked == false)
            {
                dataGridView1.DataSource = null;
            }
            else
            {
                belAve orden = new belAve("", "", 0);
                List<belCarne> aux = new List<belCarne>();
                if (CbAve.Checked)
                {
                    aux.AddRange(ListCarne.Where(x => x.GetType() == typeof(belAve)).ToList());
                }
                if(CbPorcina.Checked)
                {
                    aux.AddRange(ListCarne.Where(x => x.GetType() == typeof(belPorcina)).ToList());
                }
                if(CbVacuna.Checked)
                {
                    aux.AddRange(ListCarne.Where(x => x.GetType() == typeof(belVacuna)).ToList());
                }
                aux = aux.Where(x => x.Nombre.StartsWith(tbFiltro.Text)).ToList();
                aux.Sort(orden.OrdenPorNombre);
                dataGridView1.DataSource = aux;
            }
        }
        private void CargarEvento()
        {
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    (c as CheckBox).CheckedChanged += Filtro;
                }
            }
            tbFiltro.TextChanged += Filtro;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    textBox2.Text = (dataGridView1.SelectedRows[0].DataBoundItem as belCarne).PrecioKG.ToString();
                    decimal A;
                    decimal B;
                    decimal C;
                    decimal.TryParse(textBox1.Text, out A);
                    decimal.TryParse(textBox2.Text, out B);
                    C = A * B;
                    textBox3.Text = C.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count != 0)
                {
                    belCarneCarrito aux = dataGridView2.SelectedRows[0].DataBoundItem as belCarneCarrito;
                    belCarrito.Productos.Remove(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }     
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                belCarrito.DNI = tbDNI.Text;
                belCarrito.Nombre = tbNombre.Text;
                belCarrito.Apellido = tbApellido.Text;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
