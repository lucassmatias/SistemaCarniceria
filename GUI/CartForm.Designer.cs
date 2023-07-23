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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbFiltro = new System.Windows.Forms.TextBox();
            this.CbBeef = new System.Windows.Forms.CheckBox();
            this.CbPork = new System.Windows.Forms.CheckBox();
            this.CbBird = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
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
            this.lblCalculator = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKGPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNetWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGrossWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKGPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.clmKGPrice2});
            this.dataGridView1.Location = new System.Drawing.Point(18, 103);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(478, 725);
            this.dataGridView1.TabIndex = 0;
            // 
            // tbFiltro
            // 
            this.tbFiltro.Location = new System.Drawing.Point(506, 128);
            this.tbFiltro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFiltro.Name = "tbFiltro";
            this.tbFiltro.Size = new System.Drawing.Size(144, 26);
            this.tbFiltro.TabIndex = 1;
            // 
            // CbBeef
            // 
            this.CbBeef.AutoSize = true;
            this.CbBeef.Checked = true;
            this.CbBeef.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbBeef.Location = new System.Drawing.Point(513, 168);
            this.CbBeef.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbBeef.Name = "CbBeef";
            this.CbBeef.Size = new System.Drawing.Size(90, 24);
            this.CbBeef.TabIndex = 2;
            this.CbBeef.Text = "Vacuna";
            this.CbBeef.UseVisualStyleBackColor = true;
            // 
            // CbPork
            // 
            this.CbPork.AutoSize = true;
            this.CbPork.Checked = true;
            this.CbPork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbPork.Location = new System.Drawing.Point(513, 203);
            this.CbPork.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbPork.Name = "CbPork";
            this.CbPork.Size = new System.Drawing.Size(88, 24);
            this.CbPork.TabIndex = 3;
            this.CbPork.Text = "Porcina";
            this.CbPork.UseVisualStyleBackColor = true;
            // 
            // CbBird
            // 
            this.CbBird.AutoSize = true;
            this.CbBird.Checked = true;
            this.CbBird.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbBird.Location = new System.Drawing.Point(513, 238);
            this.CbBird.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbBird.Name = "CbBird";
            this.CbBird.Size = new System.Drawing.Size(62, 24);
            this.CbBird.TabIndex = 4;
            this.CbBird.Text = "Ave";
            this.CbBird.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(514, 103);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 20);
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
            this.dataGridView2.Location = new System.Drawing.Point(730, 257);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(828, 568);
            this.dataGridView2.TabIndex = 6;
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuy.Location = new System.Drawing.Point(1338, 179);
            this.lblBuy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(220, 61);
            this.lblBuy.TabIndex = 7;
            this.lblBuy.Text = "Compra";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(506, 469);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(171, 63);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(730, 834);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(171, 63);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Quitar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(1566, 482);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(171, 63);
            this.btnFinish.TabIndex = 11;
            this.btnFinish.Text = "Finalizar";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(18, 837);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 63);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbPesoBruto
            // 
            this.tbPesoBruto.Location = new System.Drawing.Point(506, 334);
            this.tbPesoBruto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPesoBruto.Name = "tbPesoBruto";
            this.tbPesoBruto.Size = new System.Drawing.Size(210, 26);
            this.tbPesoBruto.TabIndex = 14;
            // 
            // tbPesoNeto
            // 
            this.tbPesoNeto.Location = new System.Drawing.Point(506, 412);
            this.tbPesoNeto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPesoNeto.Name = "tbPesoNeto";
            this.tbPesoNeto.Size = new System.Drawing.Size(210, 26);
            this.tbPesoNeto.TabIndex = 15;
            // 
            // lblGrossWeight
            // 
            this.lblGrossWeight.AutoSize = true;
            this.lblGrossWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrossWeight.Location = new System.Drawing.Point(506, 291);
            this.lblGrossWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrossWeight.Name = "lblGrossWeight";
            this.lblGrossWeight.Size = new System.Drawing.Size(192, 37);
            this.lblGrossWeight.TabIndex = 16;
            this.lblGrossWeight.Text = "Peso bruto:";
            // 
            // lblNetWeight
            // 
            this.lblNetWeight.AutoSize = true;
            this.lblNetWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetWeight.Location = new System.Drawing.Point(506, 369);
            this.lblNetWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNetWeight.Name = "lblNetWeight";
            this.lblNetWeight.Size = new System.Drawing.Size(179, 37);
            this.lblNetWeight.TabIndex = 17;
            this.lblNetWeight.Text = "Peso neto:";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.Location = new System.Drawing.Point(18, 38);
            this.lblProducts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(274, 61);
            this.lblProducts.TabIndex = 18;
            this.lblProducts.Text = "Productos";
            // 
            // lblCalculator
            // 
            this.lblCalculator.AutoSize = true;
            this.lblCalculator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalculator.Location = new System.Drawing.Point(724, 103);
            this.lblCalculator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalculator.Name = "lblCalculator";
            this.lblCalculator.Size = new System.Drawing.Size(182, 33);
            this.lblCalculator.TabIndex = 19;
            this.lblCalculator.Text = "Calculadora";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(730, 165);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 26);
            this.textBox1.TabIndex = 20;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(904, 165);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 26);
            this.textBox2.TabIndex = 21;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1088, 165);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(148, 26);
            this.textBox3.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1064, 169);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(885, 169);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "*";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(730, 205);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(112, 35);
            this.btnCalculate.TabIndex = 25;
            this.btnCalculate.Text = "Calcular";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(730, 140);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(102, 20);
            this.lblQuantity.TabIndex = 26;
            this.lblQuantity.Text = "Cantidad(Kg)";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(900, 140);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(82, 20);
            this.lblPrice.TabIndex = 27;
            this.lblPrice.Text = "Precio(Kg)";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(1566, 291);
            this.tbDNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(205, 26);
            this.tbDNI.TabIndex = 28;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(1566, 363);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(205, 26);
            this.tbNombre.TabIndex = 29;
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(1566, 442);
            this.tbApellido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(205, 26);
            this.tbApellido.TabIndex = 30;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(1566, 257);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(48, 25);
            this.lblId.TabIndex = 31;
            this.lblId.Text = "DNI";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName2.Location = new System.Drawing.Point(1566, 334);
            this.lblName2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(87, 25);
            this.lblName2.TabIndex = 32;
            this.lblName2.Text = "Nombre";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurname.Location = new System.Drawing.Point(1566, 412);
            this.lblSurname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(90, 25);
            this.lblSurname.TabIndex = 33;
            this.lblSurname.Text = "Apellido";
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
            // clmId2
            // 
            this.clmId2.HeaderText = "Id";
            this.clmId2.MinimumWidth = 8;
            this.clmId2.Name = "clmId2";
            this.clmId2.ReadOnly = true;
            // 
            // clmName2
            // 
            this.clmName2.HeaderText = "Nombre";
            this.clmName2.MinimumWidth = 8;
            this.clmName2.Name = "clmName2";
            this.clmName2.ReadOnly = true;
            // 
            // clmKGPrice2
            // 
            this.clmKGPrice2.HeaderText = "PrecioKG";
            this.clmKGPrice2.MinimumWidth = 8;
            this.clmKGPrice2.Name = "clmKGPrice2";
            this.clmKGPrice2.ReadOnly = true;
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 998);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCalculator);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CartForm";
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
        private System.Windows.Forms.Label lblCalculator;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKGPrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKGPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNetWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGrossWeight;
    }
}