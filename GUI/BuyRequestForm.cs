﻿using BEL;
using BLL;
using Interfaces;
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

namespace GUI
{
    public partial class BuyRequestForm : Form
    {
        belProveedor proveedor;
        bllPedidoCompra bllped;
        List<belPedidoCompra> pedidos;
        public BuyRequestForm(belProveedor pProveedor)
        {
            InitializeComponent();
            proveedor = pProveedor;
            bllped = new bllPedidoCompra();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CartSelectForm cartselectInstance = new CartSelectForm(proveedor);
                cartselectInstance.ShowDialog();
                pedidos = bllped.Consulta();
                pedidos = pedidos.FindAll(x => x.proveedor.Id == proveedor.Id);
                RefrescarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BuyRequestForm_Load(object sender, EventArgs e)
        {
            try
            {
                pedidos = bllped.Consulta();
                pedidos = pedidos.FindAll(x => x.proveedor.Id == proveedor.Id);
                RefrescarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RefrescarDGV()
        {
            dataGridView1.Rows.Clear();
            if(pedidos.Count > 0)
            {
                foreach(belPedidoCompra pe in pedidos)
                {
                    dataGridView1.Rows.Add(new object[] { pe.Id, pe.PrecioTotal, pe.Fecha, pe.Recibido, pe.Cancelado });
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    belPedidoCompra pc = pedidos.Find(x => x.Id == dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    bllped.Cancelar(pc.Id);
                    pedidos = bllped.Consulta();
                    pedidos = pedidos.FindAll(x => x.proveedor.Id == proveedor.Id);
                    RefrescarDGV();
                    LogManager.AgregarLogEvento($"COMPRA - Pedido cancelado ({pc.Id})", 2, SessionManager.GetInstance.user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    belPedidoCompra pc = pedidos.Find(x => x.Id == dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    bllped.Recibir(pc.Id);
                    pedidos = bllped.Consulta();
                    pedidos = pedidos.FindAll(x => x.proveedor.Id == proveedor.Id);
                    RefrescarDGV();
                    LogManager.AgregarLogEvento($"COMPRA - Pedido recibido ({pc.Id})", 2, SessionManager.GetInstance.user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EnableBtnCancelFunction()
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                btnCancel.Enabled = bool.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()) == false ? true : false;
            }
        }
        private void EnableBtnPayFunction()
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                btnReceived.Enabled = bool.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString()) == false ? true : false;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EnableBtnCancelFunction();
                EnableBtnPayFunction();
            }
            catch 
            {

            }
        }

        private void btnCartView_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count != 0)
            {
                ShowCartForm form = new ShowCartForm(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                form.ShowDialog();
                form = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
