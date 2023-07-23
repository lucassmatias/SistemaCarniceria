namespace GUI
{
    partial class UsersForm
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
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbBlocked = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbRol = new System.Windows.Forms.TextBox();
            this.btnActive = new System.Windows.Forms.Button();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.lblId = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.lblUserM = new System.Windows.Forms.Label();
            this.comboBoxImage1 = new Controles.ComboBoxImage();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.clmUniqueId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBlocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmTrys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLanguage = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.clmUniqueId,
            this.clmId,
            this.clmUsername,
            this.clmPassword,
            this.clmBlocked,
            this.clmName,
            this.clmSurname,
            this.clmEmail,
            this.clmRole,
            this.clmActive,
            this.clmTrys,
            this.clmLanguage});
            this.dataGridView1.Location = new System.Drawing.Point(44, 103);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1178, 269);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(140, 417);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(210, 26);
            this.tbUsername.TabIndex = 1;
            // 
            // tbContraseña
            // 
            this.tbContraseña.Location = new System.Drawing.Point(140, 452);
            this.tbContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.Size = new System.Drawing.Size(210, 26);
            this.tbContraseña.TabIndex = 2;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(65, 420);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(64, 20);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Usuario";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 457);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(92, 20);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Contraseña";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(380, 382);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(176, 60);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(380, 520);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(176, 60);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Eliminar";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(380, 451);
            this.btnModify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(176, 60);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlock.Location = new System.Drawing.Point(740, 382);
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(238, 77);
            this.btnUnlock.TabIndex = 8;
            this.btnUnlock.Text = "Des/bloquear";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1066, 58);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(148, 26);
            this.textBox3.TabIndex = 9;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(1062, 34);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(86, 20);
            this.lblFilter.TabIndex = 10;
            this.lblFilter.Text = "Filtro (DNI)";
            // 
            // cbBlocked
            // 
            this.cbBlocked.AutoSize = true;
            this.cbBlocked.Location = new System.Drawing.Point(951, 58);
            this.cbBlocked.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbBlocked.Name = "cbBlocked";
            this.cbBlocked.Size = new System.Drawing.Size(112, 24);
            this.cbBlocked.TabIndex = 11;
            this.cbBlocked.Text = "Bloqueado";
            this.cbBlocked.UseVisualStyleBackColor = true;
            this.cbBlocked.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1060, 616);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 57);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(66, 492);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 20);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Nombre";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(66, 531);
            this.lblSurname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(65, 20);
            this.lblSurname.TabIndex = 14;
            this.lblSurname.Text = "Apellido";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(84, 566);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 20);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(96, 606);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(33, 20);
            this.lblRole.TabIndex = 16;
            this.lblRole.Text = "Rol";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(140, 488);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(210, 26);
            this.tbNombre.TabIndex = 17;
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(140, 525);
            this.tbApellido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(210, 26);
            this.tbApellido.TabIndex = 18;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(140, 562);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(210, 26);
            this.tbEmail.TabIndex = 19;
            // 
            // tbRol
            // 
            this.tbRol.Location = new System.Drawing.Point(140, 602);
            this.tbRol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRol.Name = "tbRol";
            this.tbRol.Size = new System.Drawing.Size(210, 26);
            this.tbRol.TabIndex = 20;
            // 
            // btnActive
            // 
            this.btnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActive.Location = new System.Drawing.Point(987, 382);
            this.btnActive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(234, 77);
            this.btnActive.TabIndex = 21;
            this.btnActive.Text = "Des/activar";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Location = new System.Drawing.Point(768, 57);
            this.rbActive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(77, 24);
            this.rbActive.TabIndex = 22;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Activo";
            this.rbActive.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(860, 57);
            this.rbAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(78, 24);
            this.rbAll.TabIndex = 23;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Todos";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(96, 389);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(37, 20);
            this.lblId.TabIndex = 24;
            this.lblId.Text = "DNI";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(140, 382);
            this.tbDNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(210, 26);
            this.tbDNI.TabIndex = 25;
            // 
            // lblUserM
            // 
            this.lblUserM.AutoSize = true;
            this.lblUserM.Font = new System.Drawing.Font("Sylfaen", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserM.Location = new System.Drawing.Point(33, 34);
            this.lblUserM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserM.Name = "lblUserM";
            this.lblUserM.Size = new System.Drawing.Size(567, 62);
            this.lblUserM.TabIndex = 26;
            this.lblUserM.Text = "GESTIÓN DE USUARIOS";
            // 
            // comboBoxImage1
            // 
            this.comboBoxImage1.Location = new System.Drawing.Point(140, 638);
            this.comboBoxImage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxImage1.Name = "comboBoxImage1";
            this.comboBoxImage1.Size = new System.Drawing.Size(210, 35);
            this.comboBoxImage1.TabIndex = 27;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(74, 638);
            this.lblLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(57, 20);
            this.lblLanguage.TabIndex = 28;
            this.lblLanguage.Text = "Idioma";
            // 
            // clmUniqueId
            // 
            this.clmUniqueId.HeaderText = "UId";
            this.clmUniqueId.MinimumWidth = 8;
            this.clmUniqueId.Name = "clmUniqueId";
            this.clmUniqueId.ReadOnly = true;
            // 
            // clmId
            // 
            this.clmId.HeaderText = "Id";
            this.clmId.MinimumWidth = 8;
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            // 
            // clmUsername
            // 
            this.clmUsername.HeaderText = "Usuario";
            this.clmUsername.MinimumWidth = 8;
            this.clmUsername.Name = "clmUsername";
            this.clmUsername.ReadOnly = true;
            // 
            // clmPassword
            // 
            this.clmPassword.HeaderText = "Contraseña";
            this.clmPassword.MinimumWidth = 8;
            this.clmPassword.Name = "clmPassword";
            this.clmPassword.ReadOnly = true;
            // 
            // clmBlocked
            // 
            this.clmBlocked.HeaderText = "Blocked";
            this.clmBlocked.MinimumWidth = 8;
            this.clmBlocked.Name = "clmBlocked";
            this.clmBlocked.ReadOnly = true;
            // 
            // clmName
            // 
            this.clmName.HeaderText = "Nombre";
            this.clmName.MinimumWidth = 8;
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            // 
            // clmSurname
            // 
            this.clmSurname.HeaderText = "Apellido";
            this.clmSurname.MinimumWidth = 8;
            this.clmSurname.Name = "clmSurname";
            this.clmSurname.ReadOnly = true;
            // 
            // clmEmail
            // 
            this.clmEmail.HeaderText = "Email";
            this.clmEmail.MinimumWidth = 8;
            this.clmEmail.Name = "clmEmail";
            this.clmEmail.ReadOnly = true;
            // 
            // clmRole
            // 
            this.clmRole.HeaderText = "Rol";
            this.clmRole.MinimumWidth = 8;
            this.clmRole.Name = "clmRole";
            this.clmRole.ReadOnly = true;
            // 
            // clmActive
            // 
            this.clmActive.HeaderText = "Activo";
            this.clmActive.MinimumWidth = 8;
            this.clmActive.Name = "clmActive";
            this.clmActive.ReadOnly = true;
            this.clmActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clmTrys
            // 
            this.clmTrys.HeaderText = "Intentos";
            this.clmTrys.MinimumWidth = 8;
            this.clmTrys.Name = "clmTrys";
            this.clmTrys.ReadOnly = true;
            // 
            // clmLanguage
            // 
            this.clmLanguage.HeaderText = "Idioma";
            this.clmLanguage.MinimumWidth = 8;
            this.clmLanguage.Name = "clmLanguage";
            this.clmLanguage.ReadOnly = true;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 731);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.comboBoxImage1);
            this.Controls.Add(this.lblUserM);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.rbActive);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.tbRol);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbBlocked);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UsersForm";
            this.Text = "FormUsuario";
            this.Load += new System.EventHandler(this.FormUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbContraseña;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.CheckBox cbBlocked;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbRol;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.Label lblUserM;
        private Controles.ComboBoxImage comboBoxImage1;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUniqueId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPassword;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmBlocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRole;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTrys;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLanguage;
    }
}