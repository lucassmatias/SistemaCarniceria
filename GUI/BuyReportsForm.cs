using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCarniceria
{
    public partial class BuyReportsForm : Form
    {
        public BuyReportsForm()
        {
            InitializeComponent();
        }

        private void BuyReportsForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dbCarniceria.tPedidoCompra' Puede moverla o quitarla según sea necesario.
            this.tPedidoCompraTableAdapter.Fill(this.dbCarniceria.tPedidoCompra);

            this.reportViewer1.RefreshReport();
        }
    }
}
