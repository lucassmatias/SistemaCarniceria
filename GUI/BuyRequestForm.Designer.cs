namespace GUI
{
    partial class BuyRequestForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cldId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmCancelled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnReceived = new System.Windows.Forms.Button();
            this.btnCartView = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cldId,
            this.clmTotalPrice,
            this.clmDate,
            this.clmPaid,
            this.clmCancelled});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 337);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // cldId
            // 
            this.cldId.HeaderText = "Codigo";
            this.cldId.Name = "cldId";
            this.cldId.ReadOnly = true;
            // 
            // clmTotalPrice
            // 
            this.clmTotalPrice.HeaderText = "Precio total";
            this.clmTotalPrice.Name = "clmTotalPrice";
            this.clmTotalPrice.ReadOnly = true;
            // 
            // clmDate
            // 
            this.clmDate.HeaderText = "Fecha";
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            // 
            // clmPaid
            // 
            this.clmPaid.HeaderText = "Pagado";
            this.clmPaid.Name = "clmPaid";
            this.clmPaid.ReadOnly = true;
            // 
            // clmCancelled
            // 
            this.clmCancelled.HeaderText = "Cancelado";
            this.clmCancelled.Name = "clmCancelled";
            this.clmCancelled.ReadOnly = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(12, 355);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(147, 37);
            this.btnCreate.TabIndex = 42;
            this.btnCreate.Text = "Crear";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReceived
            // 
            this.btnReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceived.Location = new System.Drawing.Point(471, 355);
            this.btnReceived.Name = "btnReceived";
            this.btnReceived.Size = new System.Drawing.Size(137, 37);
            this.btnReceived.TabIndex = 44;
            this.btnReceived.Text = "Recibido";
            this.btnReceived.UseVisualStyleBackColor = true;
            this.btnReceived.Click += new System.EventHandler(this.btnReceived_Click);
            // 
            // btnCartView
            // 
            this.btnCartView.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCartView.Location = new System.Drawing.Point(318, 355);
            this.btnCartView.Name = "btnCartView";
            this.btnCartView.Size = new System.Drawing.Size(147, 37);
            this.btnCartView.TabIndex = 45;
            this.btnCartView.Text = "Ver carro";
            this.btnCartView.UseVisualStyleBackColor = true;
            this.btnCartView.Click += new System.EventHandler(this.btnCartView_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(165, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 37);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(676, 355);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 37);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BuyRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 399);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCartView);
            this.Controls.Add(this.btnReceived);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BuyRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuyRequestForm";
            this.Load += new System.EventHandler(this.BuyRequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnReceived;
        private System.Windows.Forms.Button btnCartView;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn cldId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmPaid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCancelled;
    }
}