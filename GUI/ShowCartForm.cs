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
    public partial class ShowCartForm : Form
    {
        public string codigo { get; set; }
        public ShowCartForm(string pCodigo)
        {
            InitializeComponent();
            codigo = pCodigo;
        }
        bllPedidoCompraCarne bllcar;
        List<belPedidoCompraCarne> listcarne;
        private void ShowCartForm_Load(object sender, EventArgs e)
        {
            bllcar = new bllPedidoCompraCarne();
            listcarne = bllcar.ConsultaCondicional(codigo);
            decimal total = 0;
            foreach(belPedidoCompraCarne ped in listcarne)
            {
                dataGridView1.Rows.Add(new object[] { ped.CarneNombre, ped.Cantidad, ped.PrecioUnitario, (ped.Cantidad * ped.PrecioUnitario) });
                total += (ped.Cantidad * ped.PrecioUnitario);
            }
            dataGridView1.Rows.Add(new object[] { "", "", "Total:", total });
        }
    }
}
