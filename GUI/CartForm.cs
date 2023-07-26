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
using Interfaces;
using System.Text.RegularExpressions;
namespace GUI
{
    public partial class CartForm : Form, ITraducible
    {
        List<belCarne> ListCarne;
        belCarrito belCarrito;
        bllCarrito bllCarrito;
        bllCarneCarrito bllCarneCarrito;
        public CartForm()
        {
            InitializeComponent();
        }
        private void CartForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarDGV1(ListCarne);
            belCarrito = new belCarrito();
            bllCarrito = new bllCarrito();
            bllCarneCarrito = new bllCarneCarrito();
            CargarEvento();
        }
        private void CargarDatos()
        {
            ListCarne = new List<belCarne>() { new belAve("1","Pollo", 261, 10), new belVacuna("2", "Bife", 300, 17), new belPorcina("3", "Nalga", 410, 4) };
        }
        private void CargarDGV1(List<belCarne> pList)
        {
            dataGridView1.Rows.Clear();
            foreach (belCarne bel in pList)
            {
                dataGridView1.Rows.Add(new object[] { bel.Id, bel.Nombre, bel.PrecioKG, bel.StockKG });
            }
        }
        private void CargarDGV2()
        {
            dataGridView2.Rows.Clear();
            foreach (belCarneCarrito x in belCarrito.Productos)
            {
                dataGridView2.Rows.Add(new object[] { x.Carne.Id, x.Carne.Nombre, x.Carne.PrecioKG, x.PesoNeto, x.PrecioNeto });
            }
            if(belCarrito.Productos.Count > 0)
            {
                decimal total = 0;
                foreach (DataGridViewRow dr in dataGridView2.Rows)
                {
                    total += decimal.Parse(dr.Cells[4].Value.ToString());
                }
                belCarrito.ImporteBruto = total;
                dataGridView2.Rows.Add(new string[] { "", "", "", "Precio Total =>", $"{total}" });
            }      
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.Rows.Count != 0)
                {
                    bllCarrito.AgregarProducto(belCarrito, SeleccionarCarne(), decimal.Parse(tbPesoBruto.Text), decimal.Parse(tbPesoNeto.Text));
                    CargarDGV2();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Filtro(object sender, EventArgs e)
        {
            if(CbBird.Checked == false && CbPork.Checked == false && CbBeef.Checked == false)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                belAve orden = new belAve("", "", 0, 0);
                List<belCarne> aux = new List<belCarne>();
                if (CbBird.Checked)
                {
                    aux.AddRange(ListCarne.Where(x => x.GetType() == typeof(belAve)).ToList());
                }
                if(CbPork.Checked)
                {
                    aux.AddRange(ListCarne.Where(x => x.GetType() == typeof(belPorcina)).ToList());
                }
                if(CbBeef.Checked)
                {
                    aux.AddRange(ListCarne.Where(x => x.GetType() == typeof(belVacuna)).ToList());
                }
                aux = aux.Where(x => x.Nombre.StartsWith(tbFiltro.Text)).ToList();
                aux.Sort(orden.OrdenPorNombre);
                CargarDGV1(aux);
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
        private belCarne SeleccionarCarne()
        {
            return ListCarne.Find(x => x.Id == dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }
        private belCarneCarrito SeleccionarCarneCarrito()
        {
            return belCarrito.Productos.Find(x => x.Carne.Id == dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count != 0)
                {
                    bllCarrito.QuitarProducto(belCarrito, SeleccionarCarneCarrito().Id);
                    CargarDGV2();
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
                if(belCarrito.Productos.Count != 0)
                {
                    if (tbValidation())
                    {
                        throw new Exception("No puede dejar campos vacios");
                    }
                    else
                    {
                        bllCarrito.AgregarDatos(belCarrito, tbDNI.Text, tbNombre.Text, tbApellido.Text);
                        bllCarrito.AgregarImporte(belCarrito);
                        bllCarrito.Alta(belCarrito);
                        foreach (belCarneCarrito x in belCarrito.Productos)
                        {
                            bllCarneCarrito.Alta(x);
                        }
                        bllCarrito.ClearProductos(belCarrito);
                        CargarDGV2();
                    }
                }
                else
                {
                    throw new Exception("El carrito no tiene productos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool tbValidation()
        {
            bool tbValidation = false;
            if (tbDNI.Text == string.Empty ||
                tbNombre.Text == string.Empty ||
                tbApellido.Text == string.Empty)        
            {
                tbValidation = true;
            }
            return tbValidation;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Update(Idioma pIdioma)
        {
            clmId.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmId").Texto;
            clmId2.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmId").Texto;
            clmName.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmName").Texto;
            clmName2.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmName").Texto;
            clmKGPrice.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmKGPrice").Texto;
            clmKGPrice2.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmKGPrice").Texto;
            clmNetWeight.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmNetWeight").Texto;
            clmGrossWeight.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmGrossWeight").Texto;
            lblProducts.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblProducts").Texto;
            lblName.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblName").Texto;
            lblName2.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblName").Texto;
            lblNetWeight.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblNetWeight").Texto;
            lblGrossWeight.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblGrossWeight").Texto;          
            lblBuy.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblBuy").Texto;                    
            lblId.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblId").Texto;
            lblSurname.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblSurname").Texto;
            CbBeef.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "cbBeef").Texto;
            CbPork.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "cbPork").Texto;
            CbBird.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "cbBird").Texto;
            btnAdd.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnAdd").Texto;
            btnCancel.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnCancel").Texto;
            btnRemove.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnRemove").Texto;
            btnFinish.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnFinish").Texto;
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            ConsultForm ConsultFormInstance = new ConsultForm(SeleccionarCarne());
            ConsultFormInstance.ShowDialog();
        }
    }
}
