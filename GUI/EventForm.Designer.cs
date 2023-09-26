namespace GUI
{
    partial class EventForm
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
            this.lblChanges = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPreEstate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPostEstate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDifference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOperation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUser2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCasualty = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnRollback = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChanges
            // 
            this.lblChanges.AutoSize = true;
            this.lblChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChanges.Location = new System.Drawing.Point(5, 10);
            this.lblChanges.Name = "lblChanges";
            this.lblChanges.Size = new System.Drawing.Size(162, 39);
            this.lblChanges.TabIndex = 36;
            this.lblChanges.Text = "Cambios";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmMeat,
            this.clmPreEstate,
            this.clmPostEstate,
            this.clmDifference,
            this.clmDate2,
            this.clmOperation,
            this.clmUser2,
            this.clmCasualty});
            this.dataGridView1.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(915, 343);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_RowEnter);
            // 
            // clmId
            // 
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            // 
            // clmMeat
            // 
            this.clmMeat.HeaderText = "Carne";
            this.clmMeat.Name = "clmMeat";
            this.clmMeat.ReadOnly = true;
            // 
            // clmPreEstate
            // 
            this.clmPreEstate.HeaderText = "Estado previo";
            this.clmPreEstate.Name = "clmPreEstate";
            this.clmPreEstate.ReadOnly = true;
            // 
            // clmPostEstate
            // 
            this.clmPostEstate.HeaderText = "Estado posterior";
            this.clmPostEstate.Name = "clmPostEstate";
            this.clmPostEstate.ReadOnly = true;
            // 
            // clmDifference
            // 
            this.clmDifference.HeaderText = "Diferencia";
            this.clmDifference.Name = "clmDifference";
            this.clmDifference.ReadOnly = true;
            // 
            // clmDate2
            // 
            this.clmDate2.HeaderText = "Fecha";
            this.clmDate2.Name = "clmDate2";
            this.clmDate2.ReadOnly = true;
            // 
            // clmOperation
            // 
            this.clmOperation.HeaderText = "Operacion";
            this.clmOperation.Name = "clmOperation";
            this.clmOperation.ReadOnly = true;
            // 
            // clmUser2
            // 
            this.clmUser2.HeaderText = "Usuario";
            this.clmUser2.Name = "clmUser2";
            this.clmUser2.ReadOnly = true;
            // 
            // clmCasualty
            // 
            this.clmCasualty.HeaderText = "Baja";
            this.clmCasualty.Name = "clmCasualty";
            this.clmCasualty.ReadOnly = true;
            // 
            // btnRollback
            // 
            this.btnRollback.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollback.Location = new System.Drawing.Point(12, 401);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(130, 37);
            this.btnRollback.TabIndex = 42;
            this.btnRollback.Text = "Deshacer";
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(824, 401);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 37);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRollback);
            this.Controls.Add(this.lblChanges);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventForm";
            this.Load += new System.EventHandler(this.EventForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChanges;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPreEstate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPostEstate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDifference;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUser2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCasualty;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.Button btnClose;
    }
}