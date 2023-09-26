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
using Services;
using ServiceClasses;
namespace GUI
{
    public partial class CartForm : Form, ITraducible
    {
        List<belCarne> ListCarne;
        belCarrito belCarrito;
        bllCarrito bllCarrito;
        bllCarneCarrito bllCarneCarrito;
        bllCarne bllCarne;
        string msgWeightAlert;
        string msgWeightAlert2;
        string msgValidateError;
        string msgSuccesfulCart;
        string msgCartNoProducts;
        Dictionary<string, decimal> RegistroStock;
        public CartForm()
        {
            InitializeComponent();
        }
        private void CartForm_Load(object sender, EventArgs e)
        {
            belCarrito = new belCarrito();
            bllCarrito = new bllCarrito();
            bllCarne = new bllCarne();
            bllCarneCarrito = new bllCarneCarrito();
            ListCarne = bllCarne.Consulta();
            CargarDGV1(ListCarne);
            CargarEvento();
            btnRemove.Enabled = false;
            RegistroStock = new Dictionary<string, decimal>();
            CacheStock();
        }
        private void CacheStock()
        {
            RegistroStock.Clear();
            foreach (belCarne carne in ListCarne)
            {
                RegistroStock.Add(carne.Id, carne.StockKG);
            }
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
                    if(!(string.IsNullOrEmpty(tbPesoBruto.Text) || string.IsNullOrEmpty(tbPesoNeto.Text)))
                    {
                        if (decimal.Parse(tbPesoBruto.Text) <= SeleccionarCarne().StockKG && decimal.Parse(tbPesoNeto.Text) <= SeleccionarCarne().StockKG)
                        {
                            if (decimal.Parse(tbPesoBruto.Text) >= decimal.Parse(tbPesoNeto.Text))
                            {
                                bllCarrito.AgregarProducto(belCarrito, SeleccionarCarne(), decimal.Parse(tbPesoBruto.Text), decimal.Parse(tbPesoNeto.Text));
                                SeleccionarCarne().QuitarStock(decimal.Parse(tbPesoBruto.Text));
                                CargarDGV2();
                                CargarDGV1(ListCarne);
                                btnRemove.Enabled = true;
                                VerificatorManager.AltaDVH(SeleccionarCarne());
                                VerificatorManager.ModificarTotalDVH(ListCarne.ToList<IEntity>());
                            }
                            else
                            {
                                throw new Exception(msgWeightAlert2);
                            }
                        }
                        else
                        {
                            throw new Exception(msgWeightAlert);
                        }
                    }
                    else
                    {
                        throw new Exception(msgValidateError);
                    }
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
                belAve orden = new belAve("", 0, 0);
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
                    ListCarne.Find(x => x.Id == SeleccionarCarneCarrito().Carne.Id).ReponerStock(SeleccionarCarneCarrito().PesoNeto);
                    bllCarrito.QuitarProducto(belCarrito, SeleccionarCarneCarrito().Carne.Id);
                    CargarDGV2();
                    CargarDGV1(ListCarne);
                    VerificatorManager.AltaDVH(SeleccionarCarne());
                    VerificatorManager.ModificarTotalDVH(ListCarne.ToList<IEntity>());
                }
                else
                {
                    btnRemove.Enabled = false;
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
                        throw new Exception(msgValidateError);
                    }
                    else
                    {
                        bllCarrito.AgregarDatos(belCarrito, tbDNI.Text, tbNombre.Text, tbApellido.Text);
                        bllCarrito.AgregarImporte(belCarrito);
                        bllCarrito.AgregarID(belCarrito);
                        bllCarrito.Alta(belCarrito);
                        foreach (belCarneCarrito x in belCarrito.Productos)
                        {
                            bllCarneCarrito.Alta(x);
                            belCarne aux = ListCarne.Find(y => y.Id == x.Carne.Id);
                            bllCarne.Modificacion(aux);
                            RegistroStock.TryGetValue(aux.Id, out decimal stockAnterior);
                            LogManager.AgregarLogCambio(aux, stockAnterior, aux.StockKG, 1, SessionManager.GetInstance.user);
                            VerificatorManager.AltaDVH(SeleccionarCarne());
                            VerificatorManager.ModificarTotalDVH(ListCarne.ToList<IEntity>());
                        }
                        bllCarrito.ClearProductos(belCarrito);
                        CargarDGV2();
                        MessageBox.Show(msgSuccesfulCart);
                        LogManager.AgregarLogEvento($"CART - Cart Saved ({belCarrito.Id})", 2,SessionManager.GetInstance.user);
                        CacheStock();
                    }
                }
                else
                {
                    throw new Exception(msgCartNoProducts);
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
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            tbPesoBruto.Text = "";
            tbPesoNeto.Text = "";
            tbDNI.Text = "";
            tbNombre.Text = "";
            tbApellido.Text = "";
            this.Close();
        }

        public void Update(string pCodigoIdioma)
        {
            Idioma pIdioma = LanguageManager.ListaIdioma.Find(x => x.Id == pCodigoIdioma);
            clmId.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmId").Texto;
            clmId2.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmId").Texto;
            clmName.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmName").Texto;
            clmName2.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmName").Texto;
            clmKGPrice.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmKGPrice").Texto;
            clmKGPrice2.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmKGPrice").Texto;
            clmNetWeight.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmNetWeight").Texto;
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
            btnClose.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnClose").Texto;
            btnRemove.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnRemove").Texto;
            btnFinish.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnFinish").Texto;
            btnConsult.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnConsult").Texto;
            msgWeightAlert = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgWeightAlert1").Texto;
            msgWeightAlert2 = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgWeightAlert2").Texto;
            msgValidateError = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgValidateError").Texto;
            msgSuccesfulCart = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgSuccesfulCart").Texto;
            msgCartNoProducts = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgCartNoProducts").Texto;
            this.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "frmCart").Texto;
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            ConsultForm ConsultFormInstance = new ConsultForm(SeleccionarCarne());
            LanguageManager.Suscribir(ConsultFormInstance);
            LanguageManager.CambiarIdioma(SessionManager.GetInstance.user.Idioma.Id);
            ConsultFormInstance.ShowDialog();
        }
    }
}
