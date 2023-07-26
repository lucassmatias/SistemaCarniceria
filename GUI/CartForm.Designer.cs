namespace GUI
{
    partial class CartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbFiltro = new System.Windows.Forms.TextBox();
            this.CbBeef = new System.Windows.Forms.CheckBox();
            this.CbPork = new System.Windows.Forms.CheckBox();
            this.CbBird = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKGPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNetWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGrossWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBuy = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbPesoBruto = new System.Windows.Forms.TextBox();
            this.tbPesoNeto = new System.Windows.Forms.TextBox();
            this.lblGrossWeight = new System.Windows.Forms.Label();
            this.lblNetWeight = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.btnConsult = new System.Windows.Forms.Button();
            this.clmId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKGPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId2,
            this.clmName2,
            this.clmKGPrice2,
            this.clmStock});
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(319, 471);
            this.dataGridView1.TabIndex = 0;
            // 
            // tbFiltro
            // 
            this.tbFiltro.Location = new System.Drawing.Point(337, 83);
            this.tbFiltro.Name = "tbFiltro";
            this.tbFiltro.Size = new System.Drawing.Size(97, 20);
            this.tbFiltro.TabIndex = 1;
            // 
            // CbBeef
            // 
            this.CbBeef.AutoSize = true;
            this.CbBeef.Checked = true;
            this.CbBeef.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbBeef.Location = new System.Drawing.Point(342, 109);
            this.CbBeef.Name = "CbBeef";
            this.CbBeef.Size = new System.Drawing.Size(63, 17);
            this.CbBeef.TabIndex = 2;
            this.CbBeef.Text = "Vacuna";
            this.CbBeef.UseVisualStyleBackColor = true;
            // 
            // CbPork
            // 
            this.CbPork.AutoSize = true;
            this.CbPork.Checked = true;
            this.CbPork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbPork.Location = new System.Drawing.Point(342, 132);
            this.CbPork.Name = "CbPork";
            this.CbPork.Size = new System.Drawing.Size(62, 17);
            this.CbPork.TabIndex = 3;
            this.CbPork.Text = "Porcina";
            this.CbPork.UseVisualStyleBackColor = true;
            // 
            // CbBird
            // 
            this.CbBird.AutoSize = true;
            this.CbBird.Checked = true;
            this.CbBird.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbBird.Location = new System.Drawing.Point(342, 155);
            this.CbBird.Name = "CbBird";
            this.CbBird.Size = new System.Drawing.Size(45, 17);
            this.CbBird.TabIndex = 4;
            this.CbBird.Text = "Ave";
            this.CbBird.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(343, 67);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Nombre";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmName,
            this.clmKGPrice,
            this.clmNetWeight,
            this.clmGrossWeight});
            this.dataGridView2.Location = new System.Drawing.Point(501, 67);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(552, 469);
            this.dataGridView2.TabIndex = 6;
            // 
            // clmId
            // 
            this.clmId.HeaderText = "Id";
            this.clmId.MinimumWidth = 8;
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            // 
            // clmName
            // 
            this.clmName.HeaderText = "Nombre";
            this.clmName.MinimumWidth = 8;
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            // 
            // clmKGPrice
            // 
            this.clmKGPrice.HeaderText = "PrecioKG";
            this.clmKGPrice.MinimumWidth = 8;
            this.clmKGPrice.Name = "clmKGPrice";
            this.clmKGPrice.ReadOnly = true;
            // 
            // clmNetWeight
            // 
            this.clmNetWeight.HeaderText = "PesoNeto";
            this.clmNetWeight.MinimumWidth = 8;
            this.clmNetWeight.Name = "clmNetWeight";
            this.clmNetWeight.ReadOnly = true;
            // 
            // clmGrossWeight
            // 
            this.clmGrossWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmGrossWeight.HeaderText = "PrecioNeto";
            this.clmGrossWeight.MinimumWidth = 8;
            this.clmGrossWeight.Name = "clmGrossWeight";
            this.clmGrossWeight.ReadOnly = true;
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuy.Location = new System.Drawing.Point(906, 25);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(147, 39);
            this.lblBuy.TabIndex = 7;
            this.lblBuy.Text = "Compra";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(334, 293);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 41);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(501, 542);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(114, 41);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Quitar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(1065, 293);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(114, 41);
            this.btnFinish.TabIndex = 11;
            this.btnFinish.Text = "Finalizar";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 544);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 41);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbPesoBruto
            // 
            this.tbPesoBruto.Location = new System.Drawing.Point(334, 216);
            this.tbPesoBruto.Name = "tbPesoBruto";
            this.tbPesoBruto.Size = new System.Drawing.Size(141, 20);
            this.tbPesoBruto.TabIndex = 14;
            // 
            // tbPesoNeto
            // 
            this.tbPesoNeto.Location = new System.Drawing.Point(334, 267);
            this.tbPesoNeto.Name = "tbPesoNeto";
            this.tbPesoNeto.Size = new System.Drawing.Size(141, 20);
            this.tbPesoNeto.TabIndex = 15;
            // 
            // lblGrossWeight
            // 
            this.lblGrossWeight.AutoSize = true;
            this.lblGrossWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrossWeight.Location = new System.Drawing.Point(332, 189);
            this.lblGrossWeight.Name = "lblGrossWeight";
            this.lblGrossWeight.Size = new System.Drawing.Size(133, 25);
            this.lblGrossWeight.TabIndex = 16;
            this.lblGrossWeight.Text = "Peso bruto:";
            // 
            // lblNetWeight
            // 
            this.lblNetWeight.AutoSize = true;
            this.lblNetWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetWeight.Location = new System.Drawing.Point(332, 239);
            this.lblNetWeight.Name = "lblNetWeight";
            this.lblNetWeight.Size = new System.Drawing.Size(125, 25);
            this.lblNetWeight.TabIndex = 17;
            this.lblNetWeight.Text = "Peso neto:";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.Location = new System.Drawing.Point(5, 25);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(183, 39);
            this.lblProducts.TabIndex = 18;
            this.lblProducts.Text = "Productos";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(1062, 155);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(138, 20);
            this.tbDNI.TabIndex = 28;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(1062, 202);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(138, 20);
            this.tbNombre.TabIndex = 29;
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(1062, 253);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(138, 20);
            this.tbApellido.TabIndex = 30;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(1062, 133);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(33, 16);
            this.lblId.TabIndex = 31;
            this.lblId.Text = "DNI";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName2.Location = new System.Drawing.Point(1062, 183);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(62, 16);
            this.lblName2.TabIndex = 32;
            this.lblName2.Text = "Nombre";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurname.Location = new System.Drawing.Point(1062, 234);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(65, 16);
            this.lblSurname.TabIndex = 33;
            this.lblSurname.Text = "Apellido";
            // 
            // btnConsult
            // 
            this.btnConsult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsult.Location = new System.Drawing.Point(203, 542);
            this.btnConsult.Name = "btnConsult";
            this.btnConsult.Size = new System.Drawing.Size(128, 41);
            this.btnConsult.TabIndex = 34;
            this.btnConsult.Text = "Consulta";
            this.btnConsult.UseVisualStyleBackColor = true;
            this.btnConsult.Click += new System.EventHandler(this.btnConsult_Click);
            // 
            // clmId2
            // 
            this.clmId2.FillWeight = 59.04607F;
            this.clmId2.HeaderText = "Id";
            this.clmId2.MinimumWidth = 8;
            this.clmId2.Name = "clmId2";
            this.clmId2.ReadOnly = true;
            // 
            // clmName2
            // 
            this.clmName2.FillWeight = 109.5632F;
            this.clmName2.HeaderText = "Nombre";
            this.clmName2.MinimumWidth = 8;
            this.clmName2.Name = "clmName2";
            this.clmName2.ReadOnly = true;
            // 
            // clmKGPrice2
            // 
            this.clmKGPrice2.FillWeight = 121.8274F;
            this.clmKGPrice2.HeaderText = "PrecioKG";
            this.clmKGPrice2.MinimumWidth = 8;
            this.clmKGPrice2.Name = "clmKGPrice2";
            this.clmKGPrice2.ReadOnly = true;
            // 
            // clmStock
            // 
            this.clmStock.FillWeight = 109.5632F;
            this.clmStock.HeaderText = "Stock";
            this.clmStock.Name = "clmStock";
            this.clmStock.ReadOnly = true;
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 649);
            this.Controls.Add(this.btnConsult);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lblNetWeight);
            this.Controls.Add(this.lblGrossWeight);
            this.Controls.Add(this.tbPesoNeto);
            this.Controls.Add(this.tbPesoBruto);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblBuy);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.CbBird);
            this.Controls.Add(this.CbPork);
            this.Controls.Add(this.CbBeef);
            this.Controls.Add(this.tbFiltro);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CartForm";
            this.Load += new System.EventHandler(this.CartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbFiltro;
        private System.Windows.Forms.CheckBox CbBeef;
        private System.Windows.Forms.CheckBox CbPork;
        private System.Windows.Forms.CheckBox CbBird;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblBuy;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbPesoBruto;
        private System.Windows.Forms.TextBox tbPesoNeto;
        private System.Windows.Forms.Label lblGrossWeight;
        private System.Windows.Forms.Label lblNetWeight;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKGPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNetWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGrossWeight;
        private System.Windows.Forms.Button btnConsult;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKGPrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStock;
    }
}