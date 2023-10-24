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
        public ChangesForm()
        {
            InitializeComponent();
        }
        List<belCarne> listCarne;
        bllCarne bllcarne;
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
                VerificatorManager.AltaDVH(belCarne);
                VerificatorManager.ModificarTotalDVH(listCarne.ToList<IEntity>());
                LogManager.AgregarLogEvento($"LOG - Prev state changed ({belCarne.Nombre})", 2, SessionManager.GetInstance.user);
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
    }
}
