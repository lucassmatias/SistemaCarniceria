namespace GUI
{
    partial class LogForm
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
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCriticality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblChanges = new System.Windows.Forms.Label();
            this.lblInitialDate = new System.Windows.Forms.Label();
            this.lblFinalDate = new System.Windows.Forms.Label();
            this.lblCriticity = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnRollback = new System.Windows.Forms.Button();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPreEstate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPostEstate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDifference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOperation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCasualty = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnConsult = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDate,
            this.clmText,
            this.clmUser,
            this.clmCriticality});
            this.dataGridView1.Location = new System.Drawing.Point(12, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(915, 205);
            this.dataGridView1.TabIndex = 0;
            // 
            // clmDate
            // 
            this.clmDate.HeaderText = "Fecha";
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            this.clmDate.Width = 218;
            // 
            // clmText
            // 
            this.clmText.HeaderText = "Texto";
            this.clmText.Name = "clmText";
            this.clmText.ReadOnly = true;
            this.clmText.Width = 218;
            // 
            // clmUser
            // 
            this.clmUser.HeaderText = "Usuario";
            this.clmUser.Name = "clmUser";
            this.clmUser.ReadOnly = true;
            this.clmUser.Width = 218;
            // 
            // clmCriticality
            // 
            this.clmCriticality.HeaderText = "Criticidad";
            this.clmCriticality.Name = "clmCriticality";
            this.clmCriticality.ReadOnly = true;
            this.clmCriticality.Width = 218;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmMeat,
            this.clmPreEstate,
            this.clmPostEstate,
            this.clmDifference,
            this.clmDate2,
            this.clmOperation,
            this.clmCasualty});
            this.dataGridView2.Location = new System.Drawing.Point(12, 360);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(915, 215);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_RowEnter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 269);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(320, 269);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(85, 295);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(320, 295);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 5;
            // 
            // lblEvents
            // 
            this.lblEvents.AutoSize = true;
            this.lblEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvents.Location = new System.Drawing.Point(5, 16);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(150, 39);
            this.lblEvents.TabIndex = 33;
            this.lblEvents.Text = "Eventos";
            // 
            // lblChanges
            // 
            this.lblChanges.AutoSize = true;
            this.lblChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChanges.Location = new System.Drawing.Point(5, 318);
            this.lblChanges.Name = "lblChanges";
            this.lblChanges.Size = new System.Drawing.Size(162, 39);
            this.lblChanges.TabIndex = 34;
            this.lblChanges.Text = "Cambios";
            // 
            // lblInitialDate
            // 
            this.lblInitialDate.AutoSize = true;
            this.lblInitialDate.Location = new System.Drawing.Point(13, 272);
            this.lblInitialDate.Name = "lblInitialDate";
            this.lblInitialDate.Size = new System.Drawing.Size(66, 13);
            this.lblInitialDate.TabIndex = 35;
            this.lblInitialDate.Text = "Fecha inicial";
            // 
            // lblFinalDate
            // 
            this.lblFinalDate.AutoSize = true;
            this.lblFinalDate.Location = new System.Drawing.Point(255, 272);
            this.lblFinalDate.Name = "lblFinalDate";
            this.lblFinalDate.Size = new System.Drawing.Size(59, 13);
            this.lblFinalDate.TabIndex = 36;
            this.lblFinalDate.Text = "Fecha final";
            // 
            // lblCriticity
            // 
            this.lblCriticity.AutoSize = true;
            this.lblCriticity.Location = new System.Drawing.Point(13, 298);
            this.lblCriticity.Name = "lblCriticity";
            this.lblCriticity.Size = new System.Drawing.Size(50, 13);
            this.lblCriticity.TabIndex = 37;
            this.lblCriticity.Text = "Criticidad";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(255, 298);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(29, 13);
            this.lblArea.TabIndex = 38;
            this.lblArea.Text = "Area";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(824, 581);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 37);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(443, 274);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(103, 37);
            this.btnFilter.TabIndex = 40;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollback.Location = new System.Drawing.Point(443, 587);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(130, 37);
            this.btnRollback.TabIndex = 41;
            this.btnRollback.Text = "Deshacer";
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
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
            // clmCasualty
            // 
            this.clmCasualty.HeaderText = "Baja";
            this.clmCasualty.Name = "clmCasualty";
            this.clmCasualty.ReadOnly = true;
            // 
            // btnConsult
            // 
            this.btnConsult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsult.Location = new System.Drawing.Point(802, 274);
            this.btnConsult.Name = "btnConsult";
            this.btnConsult.Size = new System.Drawing.Size(125, 37);
            this.btnConsult.TabIndex = 42;
            this.btnConsult.Text = "Consulta";
            this.btnConsult.UseVisualStyleBackColor = true;
            this.btnConsult.Click += new System.EventHandler(this.btnConsult_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 636);
            this.Controls.Add(this.btnConsult);
            this.Controls.Add(this.btnRollback);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.lblCriticity);
            this.Controls.Add(this.lblFinalDate);
            this.Controls.Add(this.lblInitialDate);
            this.Controls.Add(this.lblChanges);
            this.Controls.Add(this.lblEvents);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.Load += new System.EventHandler(this.LogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmText;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCriticality;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblChanges;
        private System.Windows.Forms.Label lblInitialDate;
        private System.Windows.Forms.Label lblFinalDate;
        private System.Windows.Forms.Label lblCriticity;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPreEstate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPostEstate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDifference;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOperation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCasualty;
        private System.Windows.Forms.Button btnConsult;
    }
}