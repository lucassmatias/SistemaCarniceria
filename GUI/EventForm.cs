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
    public partial class EventForm : Form
    {
        public EventForm()
        {
            InitializeComponent();
        }
        List<belCarne> listCarne;
        bllCarne bllcarne;
        private void btnRollback_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            decimal diff = decimal.Parse(dr.Cells[4].Value.ToString());
            string operacion = dr.Cells[6].Value.ToString();
            string carne = dr.Cells[1].Value.ToString();
            if (operacion == "Venta" || operacion == "Reposicion")
            {
                belCarne belCarne = listCarne.Find(x => x.Nombre == carne);
                belCarne.ReponerStock(diff);
                bllcarne.Modificacion(belCarne);
                LogManager.BajaLogica(dr.Cells[0].Value.ToString());
                VerificatorManager.AltaDVH(belCarne);
                VerificatorManager.ModificarTotalDVH(listCarne.ToList<IEntity>());
            }
            CargarLogCambio();
            LogManager.AgregarLogEvento("LOG - Operation Cancelled", 2, SessionManager.GetInstance.user);
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
