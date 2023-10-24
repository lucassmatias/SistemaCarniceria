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

namespace GUI
{
    public partial class BuyRequestForm : Form
    {
        belProveedor proveedor;
        public BuyRequestForm(belProveedor pProveedor)
        {
            InitializeComponent();
            proveedor = pProveedor;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
