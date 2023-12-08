namespace SistemaCarniceria
{
    partial class BuyReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dbCarniceria = new SistemaCarniceria.dbCarniceria();
            this.tPedidoCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tPedidoCompraTableAdapter = new SistemaCarniceria.dbCarniceriaTableAdapters.tPedidoCompraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dbCarniceria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPedidoCompraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "dsPedidoCompra";
            reportDataSource3.Value = this.tPedidoCompraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaCarniceria.Reports.ReporteCompras.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dbCarniceria
            // 
            this.dbCarniceria.DataSetName = "dbCarniceria";
            this.dbCarniceria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tPedidoCompraBindingSource
            // 
            this.tPedidoCompraBindingSource.DataMember = "tPedidoCompra";
            this.tPedidoCompraBindingSource.DataSource = this.dbCarniceria;
            // 
            // tPedidoCompraTableAdapter
            // 
            this.tPedidoCompraTableAdapter.ClearBeforeFill = true;
            // 
            // BuyReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BuyReportsForm";
            this.Text = "BuyReportsForm";
            this.Load += new System.EventHandler(this.BuyReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbCarniceria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPedidoCompraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dbCarniceria dbCarniceria;
        private System.Windows.Forms.BindingSource tPedidoCompraBindingSource;
        private dbCarniceriaTableAdapters.tPedidoCompraTableAdapter tPedidoCompraTableAdapter;
    }
}