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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dbCarniceria.tTicket' Puede moverla o quitarla según sea necesario.
            this.tTicketTableAdapter.Fill(this.dbCarniceria.tTicket);

            this.reportViewer1.RefreshReport();
        }
    }
}
