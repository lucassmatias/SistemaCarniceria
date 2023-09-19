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
using BLL;
using Interfaces;
using Services;

namespace GUI
{
    public partial class ProductForm : Form, ITraducible
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        bllCarne BllCarne;
        List<belCarne> listCarne;
        private void ProductForm_Load(object sender, EventArgs e)
        {
            BllCarne = new bllCarne();
            listCarne = BllCarne.Consulta();
            RefrescarCarne();
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                List<TextBox> listtx = new List<TextBox>();
                listtx.AddRange(new TextBox[] { textBox1, textBox2, textBox3 });
                if (Validate(listtx))
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    if (!(textBox1.Text == row.Cells[1].Value.ToString() && textBox2.Text == row.Cells[2].Value.ToString() && textBox3.Text == row.Cells[3].Value.ToString()))
                    {
                        belVacuna carne = new belVacuna(textBox1.Text, decimal.Parse(textBox2.Text), decimal.Parse(textBox3.Text));
                        carne.Id = row.Cells[0].Value.ToString();
                        BllCarne.Modificacion(carne);
                        VerificatorManager.AltaDVH(carne);
                        LogManager.AgregarLogEvento($"PRODUCTS - Product Modified ({carne.Id})", 1, SessionManager.GetInstance.user);
                        listCarne = BllCarne.Consulta();
                        RefrescarCarne();
                    }
                    else
                    {
                        throw new Exception("Debe cambiar los valores");
                    }
                }
                else
                {
                    throw new Exception("msgValidateError");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool Validate(List<TextBox> tx)
        {
            bool t = true;
            foreach(TextBox x in tx)
            {
                if(x.Text == string.Empty)
                {
                    t = false;
                }
            }
            return t;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                BllCarne.Baja(row.Cells[0].Value.ToString());
                LogManager.AgregarLogEvento($"PRODUCTS - Product deleted ({row.Cells[0].Value.ToString()})", 1, SessionManager.GetInstance.user);
                listCarne = BllCarne.Consulta();
                VerificatorManager.BajaDVH(row.Cells[0].Value.ToString());
                RefrescarCarne();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RefrescarCarne()
        {
            dataGridView1.Rows.Clear();
            foreach(belCarne carne in listCarne)
            {
                dataGridView1.Rows.Add(new object[] {carne.Id, carne.Nombre, carne.PrecioKG, carne.StockKG});
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<TextBox> listtx = new List<TextBox>();
            listtx.AddRange(new TextBox[] { textBox4, textBox5, textBox6 });
            belCarne carne = new belAve("", 0, 0);
            try
            {
                if(Validate(listtx))
                {
                    if (rbBeef.Checked)
                    {
                        carne = new belVacuna(textBox6.Text, decimal.Parse(textBox5.Text), decimal.Parse(textBox4.Text));
                    }
                    if (rbBird.Checked)
                    {
                        carne = new belAve(textBox6.Text, decimal.Parse(textBox5.Text), decimal.Parse(textBox4.Text));
                    }
                    if (rbPork.Checked)
                    {
                        carne = new belPorcina(textBox6.Text, decimal.Parse(textBox5.Text), decimal.Parse(textBox4.Text));
                    }
                    BllCarne.Alta(carne);
                    VerificatorManager.AltaDVH(carne);
                    LogManager.AgregarLogEvento($"PRODUCTS - Product added ({carne.Nombre})", 1, SessionManager.GetInstance.user);
                    listCarne = BllCarne.Consulta();
                    RefrescarCarne();
                }
                else
                {
                    throw new Exception("msgValidateError");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Update(string pCodigoIdioma)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

            }
            finally
            {
                if(dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    textBox1.Text = row.Cells[1].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                    textBox3.Text = row.Cells[3].Value.ToString();
                }            
            }
        }
    }
}
