using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BEL;
using Interfaces;
using Services;
using ServiceClasses;
namespace GUI
{
    public partial class ConsultForm : Form, ITraducible
    {
        public belCarne Carne;
        public ConsultForm(belCarne pCarne)
        {
            InitializeComponent();
            Carne = pCarne;
            lblCarne.Text = pCarne.Nombre;
            lblId.Text = $"Id: {pCarne.Id}";
            lblStock.Text = $"Stock: {pCarne.StockKG} Kg";
        }

        public void Update(string pCodigoIdioma)
        {
            Idioma pIdioma = LanguageManager.ListaIdioma.Find(x => x.Id == pCodigoIdioma);
            lblCalculator.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblCalculator").Texto;
            lblQuantity.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblQuantity").Texto;
            lblPrice.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblPrice").Texto;
            btnCalculate.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnCalculate").Texto;
            btnClose.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnClose").Texto;
            this.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "frmConsult").Texto;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            textBox2.Text = Carne.PrecioKG.ToString();
            decimal A;
            decimal B;
            decimal C;
            decimal.TryParse(textBox1.Text, out A);
            decimal.TryParse(textBox2.Text, out B);
            C = A * B;
            textBox3.Text = C.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnCalculate_Click(null, null);
            }
        }
    }
}
