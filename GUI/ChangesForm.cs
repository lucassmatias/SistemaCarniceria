using BLL;
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
using BEL;
using Interfaces;

namespace GUI
{
    public partial class ChangesForm : Form
    {
        List<belCarne> listCarne;
        bllCarne bllcarne;
        public ChangesForm()
        {
            InitializeComponent();
        }
        private void btnRollback_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                string carneId = dr.Cells[1].Value.ToString();
                belCarne belCarne = listCarne.Find(x => x.Id == carneId);
                belCarne.Nombre = dr.Cells[2].Value.ToString();
                belCarne.PrecioKG = decimal.Parse(dr.Cells[3].Value.ToString());
                belCarne.StockKG = decimal.Parse(dr.Cells[5].Value.ToString());
                bllcarne.Modificacion(belCarne);
                foreach(DataGridViewRow dgvr in dataGridView1.Rows)
                {
                    if (dgvr.Cells[1].Value.ToString() == carneId)
                    {
                        LogManager.CambiarEstado(dgvr.Cells[0].Value.ToString(), false);
                    }
                }
                LogManager.CambiarEstado(dr.Cells[0].Value.ToString(), true);
                VerificatorManager.AltaDVH(new List<IEntity>() { belCarne }, "Carne");
                LogManager.AgregarLogEvento($"BITACORA CAMBIO - Cambio a estado previo ({belCarne.Nombre})", 2, SessionManager.GetInstance.user);
                listCarne = null; listCarne = bllcarne.Consulta();
                CargarLogCambio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }
        private void Habilitarbtn()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                btnRollback.Enabled = bool.Parse(dataGridView1.SelectedRows[0].Cells[7].Value.ToString()) == true ? false : true;
            }
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
        private void CargarLogCambio()
        {
            dataGridView1.Rows.Clear();
            List<object[]> list = LogManager.RetornaBitacoraCambio();
            foreach (object[] ob in list)
            {
                dataGridView1.Rows.Add(ob);
            }
        }
        private void EventForm_Load(object sender, EventArgs e)
        {
            CargarLogCambio();
            bllcarne = new bllCarne();
            listCarne = bllcarne.Consulta();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            List<Object[]> Filtered = new List<Object[]>();
            List<Object[]> list = LogManager.RetornaBitacoraCambio();
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                DateTime fechai = DateTime.Parse(textBox1.Text);
                DateTime fechaf = DateTime.Parse(textBox2.Text);
                Filtered.AddRange(list.Where(x => DateTime.Parse(x.GetValue(6).ToString()) >= fechai && DateTime.Parse(x.GetValue(6).ToString()) <= fechaf.AddDays(1)).ToList());
            }
            else
            {
                if (textBox1.Text != string.Empty)
                {
                    DateTime fechai = DateTime.Parse(textBox1.Text);
                    Filtered.AddRange(list.Where(x => DateTime.Parse(x.GetValue(6).ToString()) >= fechai).ToList());
                }
                else if (textBox2.Text != string.Empty)
                {
                    DateTime fechaf = DateTime.Parse(textBox2.Text);
                    Filtered.AddRange(list.Where(x => DateTime.Parse(x.GetValue(6).ToString()) <= fechaf).ToList());
                }
                else
                {
                    Filtered = list;
                }
            }
            if (textBox3.Text != string.Empty)
            {
                int usuario = int.Parse(textBox3.Text);
                Filtered = Filtered.Where(x => int.Parse(x.GetValue(7).ToString()) == usuario).ToList();
            }
            if (textBox4.Text != string.Empty)
            {
                string carne = textBox4.Text;
                Filtered = Filtered.Where(x => x.GetValue(2).ToString().Trim() == carne).ToList();
            }
            dataGridView1.Rows.Clear();
            if (Filtered.Count != 0)
            {
                foreach (object[] ar in Filtered)
                {
                    dataGridView1.Rows.Add(ar);
                }
            }
        }
    }
}
