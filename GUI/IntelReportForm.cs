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
    public partial class IntelReportForm : Form
    {
        public IntelReportForm()
        {
            InitializeComponent();
        }
        private void IntelReportForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime a = DateTime.Parse(textBox1.Text);
                DateTime b = DateTime.Parse(textBox2.Text);
                this.tTicketTableAdapter.Fill(this.intelDs.tTicket, a, b);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
