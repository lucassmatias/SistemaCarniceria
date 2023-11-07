namespace GUI
{
    partial class CartSelectForm
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
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.clmId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMeat2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPriceKG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblQuotes = new System.Windows.Forms.Label();
            this.lblCart = new System.Windows.Forms.Label();
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
            this.clmId,
            this.clmMeat,
            this.clmQuantity,
            this.clmPrice});
            this.dataGridView1.Location = new System.Drawing.Point(11, 54);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(775, 169);
            this.dataGridView1.TabIndex = 0;
            // 
            // clmId
            // 
            this.clmId.HeaderText = "Codigo";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            // 
            // clmMeat
            // 
            this.clmMeat.HeaderText = "Carne";
            this.clmMeat.Name = "clmMeat";
            this.clmMeat.ReadOnly = true;
            // 
            // clmQuantity
            // 
            this.clmQuantity.HeaderText = "Cantidad";
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.ReadOnly = true;
            // 
            // clmPrice
            // 
            this.clmPrice.HeaderText = "Precio";
            this.clmPrice.Name = "clmPrice";
            this.clmPrice.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId2,
            this.clmMeat2,
            this.clmQuantity2,
            this.clmPriceKG,
            this.clmPrice2});
            this.dataGridView2.Location = new System.Drawing.Point(11, 301);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(775, 169);
            this.dataGridView2.TabIndex = 1;
            // 
            // clmId2
            // 
            this.clmId2.HeaderText = "Codigo";
            this.clmId2.Name = "clmId2";
            this.clmId2.ReadOnly = true;
            // 
            // clmMeat2
            // 
            this.clmMeat2.HeaderText = "Carne";
            this.clmMeat2.Name = "clmMeat2";
            this.clmMeat2.ReadOnly = true;
            // 
            // clmQuantity2
            // 
            this.clmQuantity2.HeaderText = "Cantidad";
            this.clmQuantity2.Name = "clmQuantity2";
            this.clmQuantity2.ReadOnly = true;
            // 
            // clmPriceKG
            // 
            this.clmPriceKG.HeaderText = "Precio/Kilo";
            this.clmPriceKG.Name = "clmPriceKG";
            this.clmPriceKG.ReadOnly = true;
            // 
            // clmPrice2
            // 
            this.clmPrice2.HeaderText = "Precio";
            this.clmPrice2.Name = "clmPrice2";
            this.clmPrice2.ReadOnly = true;
            // 
            // btnFinalize
            // 
            this.btnFinalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalize.Location = new System.Drawing.Point(635, 476);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(151, 37);
            this.btnFinalize.TabIndex = 48;
            this.btnFinalize.Text = "Finalizar";
            this.btnFinalize.UseVisualStyleBackColor = true;
            this.btnFinalize.Click += new System.EventHandler(this.btnFinalize_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(11, 229);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(151, 37);
            this.btnAdd.TabIndex = 49;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(255, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 50;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(168, 239);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(81, 20);
            this.lblQuantity.TabIndex = 51;
            this.lblQuantity.Text = "Cantidad";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(11, 476);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(151, 37);
            this.btnDelete.TabIndex = 52;
            this.btnDelete.Text = "Quitar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblQuotes
            // 
            this.lblQuotes.AutoSize = true;
            this.lblQuotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuotes.Location = new System.Drawing.Point(559, 12);
            this.lblQuotes.Name = "lblQuotes";
            this.lblQuotes.Size = new System.Drawing.Size(229, 39);
            this.lblQuotes.TabIndex = 53;
            this.lblQuotes.Text = "Cotizaciones";
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCart.Location = new System.Drawing.Point(559, 259);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(129, 39);
            this.lblCart.TabIndex = 54;
            this.lblCart.Text = "Carrito";
            // 
            // CartSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.lblCart);
            this.Controls.Add(this.lblQuotes);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnFinalize);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CartSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CartSelectForm";
            this.Load += new System.EventHandler(this.CartSelectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblQuotes;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMeat2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPriceKG;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrice2;
    }
}