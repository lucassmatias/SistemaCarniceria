using Services;
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
using BEL;
using BLL;

namespace GUI
{
    public partial class LogForm : Form, ITraducible
    {
        List<belCarne> listCarne;
        bllCarne bllcarne;
        public LogForm()
        {
            InitializeComponent();
        }

        public void Update(string pCodigoIdioma)
        {
            
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            CargarLogEvento();
            CargarLogCambio();
            bllcarne = new bllCarne();
            listCarne = bllcarne.Consulta();
        }
        private void CargarLogEvento()
        {
            dataGridView1.Rows.Clear();
            List<Array> array = LogManager.RetornaBitacoraEvento();
            foreach (Array ar in array)
            {
                dataGridView1.Rows.Add(new object[] { ar.GetValue(0), ar.GetValue(1), ar.GetValue(2), ar.GetValue(3) });
                if (ar.GetValue(3).ToString() == "1")
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                if (ar.GetValue(3).ToString() == "2")
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightYellow;
                }
                if (ar.GetValue(3).ToString() == "3")
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                }
            }
        }
        private void CargarLogCambio()
        {
            dataGridView2.Rows.Clear();
            List<object[]> list = LogManager.RetornaBitacoraCambio();
            foreach (object[] ob in list)
            {
                dataGridView2.Rows.Add(ob);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRollback_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            decimal diff = decimal.Parse(dr.Cells[4].Value.ToString());
            string operacion = dr.Cells[6].Value.ToString();
            string carne = dr.Cells[1].Value.ToString();
            if (operacion == "Venta" || operacion == "Reposicion")
            {
                belCarne belCarne = listCarne.Find(x => x.Id == carne);
                belCarne.ReponerStock(diff);
                bllcarne.Modificacion(belCarne);
                LogManager.BajaLogica(dr.Cells[0].Value.ToString());
            }
            CargarLogCambio();
            LogManager.AgregarLogEvento("LOG - Operation Cancelled", 2, SessionManager.GetInstance.user);
            CargarLogEvento();
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Habilitarbtn();
            }
            catch 
            {

            }
        }
        private void Habilitarbtn()
        {
            if(dataGridView2.Rows.Count != 0)
            {
                btnRollback.Enabled = bool.Parse(dataGridView2.SelectedRows[0].Cells[7].Value.ToString()) == true ? false : true;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            List<Array> Filtered = new List<Array>();           
            List<Array> list = LogManager.RetornaBitacoraEvento();
            if(textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                DateTime fechai = DateTime.Parse(textBox1.Text);
                DateTime fechaf = DateTime.Parse(textBox2.Text);
                Filtered.AddRange(list.Where(x => DateTime.Parse(x.GetValue(0).ToString()) >= fechai && DateTime.Parse(x.GetValue(0).ToString()) <= fechaf.AddDays(1)).ToList());
            }
            else
            {
                if (textBox1.Text != string.Empty)
                {
                    DateTime fechai = DateTime.Parse(textBox1.Text);
                    Filtered.AddRange(list.Where(x => DateTime.Parse(x.GetValue(0).ToString()) >= fechai).ToList());
                }
                else if (textBox2.Text != string.Empty)
                {
                    DateTime fechaf = DateTime.Parse(textBox2.Text);
                    Filtered.AddRange(list.Where(x => DateTime.Parse(x.GetValue(0).ToString()) <= fechaf).ToList());
                }
                else
                {
                    Filtered = list;
                }
            }          
            if(textBox3.Text != string.Empty)
            {
                int crit = int.Parse(textBox3.Text);
                Filtered = Filtered.Where(x => int.Parse(x.GetValue(3).ToString()) == crit).ToList();
            }
            if(textBox4.Text != string.Empty)
            {
                string area = textBox4.Text.ToUpper();
                Filtered = Filtered.Where(x => x.GetValue(1).ToString().Split('-')[0].Trim() == area).ToList();
            }
            dataGridView1.Rows.Clear();
            if(Filtered.Count != 0)
            {
                foreach (Array ar in Filtered)
                {
                    dataGridView1.Rows.Add(new object[] { ar.GetValue(0), ar.GetValue(1), ar.GetValue(2), ar.GetValue(3) });
                    if (ar.GetValue(3).ToString() == "1")
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    if (ar.GetValue(3).ToString() == "2")
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    if (ar.GetValue(3).ToString() == "3")
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                }
            }           
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            CargarLogEvento();
        }
    }
}
