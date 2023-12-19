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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class QuoteRequestForm : Form
    {
        bllCarne bllCarne;
        List<belCarne> listCarne;
        public QuoteRequestForm()
        {
            InitializeComponent();
        }
        private void QuoteRequestForm_Load(object sender, EventArgs e)
        {
            bllCarne = new bllCarne();
            listCarne = bllCarne.Consulta();
            CargarComboBox();
        }
        private bool Validation()
        {
            bool flag = true;
            if (comboBox1.SelectedIndex == -1) flag = false;
            if (!decimal.TryParse(textBox1.Text, out decimal cantidad)) flag = false;
            return flag;
        }
        private void CargarComboBox()
        {
            comboBox1.Items.Clear();
            foreach (belCarne car in listCarne)
            {
                comboBox1.Items.Add(car.Nombre);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                dataGridView1.Rows.Add(comboBox1.SelectedItem.ToString(), textBox1.Text);
            }
        }
        private void btnRequest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Solicitud de cotización enviado correctamente");
            this.Close();
        }
    }
}
