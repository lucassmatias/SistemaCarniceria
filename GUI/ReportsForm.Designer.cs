namespace SistemaCarniceria
{
    partial class ReportsForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dbCarniceria = new SistemaCarniceria.dbCarniceria();
            this.tTicketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tTicketTableAdapter = new SistemaCarniceria.dbCarniceriaTableAdapters.tTicketTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dbCarniceria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTicketBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsTicket";
            reportDataSource1.Value = this.tTicketBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaCarniceria.InformeVentas.rdlc";
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
            // tTicketBindingSource
            // 
            this.tTicketBindingSource.DataMember = "tTicket";
            this.tTicketBindingSource.DataSource = this.dbCarniceria;
            // 
            // tTicketTableAdapter
            // 
            this.tTicketTableAdapter.ClearBeforeFill = true;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbCarniceria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTicketBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dbCarniceria dbCarniceria;
        private System.Windows.Forms.BindingSource tTicketBindingSource;
        private dbCarniceriaTableAdapters.tTicketTableAdapter tTicketTableAdapter;
    }
}