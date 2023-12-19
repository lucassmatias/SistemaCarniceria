using BEL;
using BLL;
using Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceClasses;
namespace GUI
{
    public partial class SaleForm : Form, ITraducible
    {
        List<belCarrito> ListCarrito;
        bllCarrito BllCarrito;
        bllTicket BllTicket;
        bllCarneCarrito BllCarneCarrito;
        int MetodoPagoFlag = 0;
        string msgPriceError;
        string msgDeviceNoConnected;
        string msgSuccesfulSale;
        string msgCartRemoved;
        public SaleForm()
        {
            InitializeComponent();
            ListCarrito = new List<belCarrito>();
            BllCarrito = new bllCarrito();
            BllTicket = new bllTicket();
            BllCarneCarrito = new bllCarneCarrito();
            rbCash.Checked = true;
            btnCharge.Enabled = false;
        }
        private void SaleForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            dataGridView1.Rows.Clear();
            CargarListBox();
        }
        private void CargarListBox()
        {
            listBox1.Items.Clear();
            ListCarrito = BllCarrito.Consulta();
            foreach (belCarrito x in ListCarrito)
            {
                listBox1.Items.Add($"{x.Id}:{x.DNI}, {x.Nombre}");
            }
        }
        private belCarrito SeleccionarCarrito()
        {
            dataGridView1.Rows.Clear();
            if(listBox1.SelectedIndex != -1)
            {
                string dni = listBox1.Items[listBox1.SelectedIndex].ToString();
                dni = dni.Split(':')[0];
                return ListCarrito.Find(x => x.Id == dni);
            }
            else
            {
                string dni = listBox1.Items[0].ToString();
                dni = dni.Split(':')[0];
                return ListCarrito.Find(x => x.Id == dni);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.Items.Count > 0) 
            {
                belCarrito cart = SeleccionarCarrito();
                CargarDGV(cart);
                btnCharge.Enabled = true;
            }
        }
        private void CargarDGV(belCarrito cart)
        {

            foreach(belCarneCarrito x in cart.Productos)
            {
                dataGridView1.Rows.Add(new object[] { x.Carne.Id, x.Carne.Nombre, x.Carne.PrecioKG, x.PesoNeto, x.PrecioNeto });
            }
            dataGridView1.Rows.Add(new object[] { "", "", "", "", cart.ImporteBruto});
        }
        public void Update(string pCodigoIdioma)
        {
            Idioma pIdioma = LanguageManager.ListaIdioma.Find(x => x.Id == pCodigoIdioma);
            lblSale.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblSale").Texto;
            gbPayMethod.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "gbPayMethod").Texto;
            rbCash.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "rbCash").Texto;
            rbCard.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "rbCard").Texto;
            lblPaid.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblPaid").Texto;
            lblChange.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblChange").Texto;
            btnCharge.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnCharge").Texto;
            btnClose.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnClose").Texto;
            clmId.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmId").Texto;
            clmName.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmName").Texto;
            clmKGPrice.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmKGPrice").Texto;
            clmNetWeight.HeaderText = pIdioma.ListaEtiquetas.Find(x => x.Tag == "clmNetWeight").Texto;
            msgPriceError = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgPriceError").Texto; 
            msgDeviceNoConnected = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgDeviceNoConnected").Texto;
            msgSuccesfulSale = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgSuccesfulSale").Texto;
            this.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "frmSale").Texto;
            msgCartRemoved = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgCartRemoved").Texto;
            btnRemove.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnRemove").Texto;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCharge_Click(object sender, EventArgs e)
        {
            try
            {
                if (MetodoPagoFlag == 1)
                {
                    if (textBox1.Text == string.Empty || decimal.Parse(textBox1.Text) < SeleccionarCarrito().ImporteBruto)
                    {
                        throw new Exception(msgPriceError);
                    }
                    else
                    {
                        belTicket ticket = new belTicket(DateTime.Now, SeleccionarCarrito().ImporteBruto, decimal.Parse(textBox1.Text));
                        foreach (belCarneCarrito cc in SeleccionarCarrito().Productos)
                        {
                            ticket.ListaCarne.Add(cc);
                        }
                        BllTicket.AgregarCodigo(ticket);
                        BllTicket.Alta(ticket);
                        foreach (belCarneCarrito cc in ticket.ListaCarne)
                        {
                            string codigo = cc.Id;
                            cc.Id = ticket.Id;
                            BllCarneCarrito.ModificaciónCarneCarrito(cc, codigo);
                        }
                        BllCarrito.Baja(SeleccionarCarrito().Id);
                        ticket.ListaCarne = null;
                        CargarListBox();
                        MessageBox.Show(msgSuccesfulSale);
                        LogManager.AgregarLogEvento($"VENTA - Venta realizada ({ticket.Id})", 2, SessionManager.GetInstance.user);
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show(msgDeviceNoConnected);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }
        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCash.Checked) 
            { 
                MetodoPagoFlag = 1;
                textBox1.ReadOnly = false;
            }
            else { MetodoPagoFlag = 2; textBox1.ReadOnly = true; }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(listBox1.Items.Count != 0)
            {
                if (textBox1.Text != string.Empty)
                {
                    textBox2.Text = (SeleccionarCarrito().ImporteBruto - decimal.Parse(textBox1.Text)).ToString();
                }
                else
                {
                    textBox2.Text = SeleccionarCarrito().ImporteBruto.ToString();
                }
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Oemcomma) 
            {
                e.Handled = !char.IsDigit(e.KeyChar);
            }
            
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                belCarrito carrito = SeleccionarCarrito();
                BllCarrito.Baja(carrito.Id);
                BllCarneCarrito.Baja(carrito.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(msgCartRemoved);
            }
        }
    }
}
