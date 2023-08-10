namespace GUI
{
    partial class ProfileForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Permisos");
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblProfiles = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.lblPermissions = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnAssignProfile = new System.Windows.Forms.Button();
            this.btnCreateProfile = new System.Windows.Forms.Button();
            this.btnRemoveProfile = new System.Windows.Forms.Button();
            this.rbLeaf = new System.Windows.Forms.RadioButton();
            this.rbComposite = new System.Windows.Forms.RadioButton();
            this.btnCreatePermission = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblActualProfile = new System.Windows.Forms.Label();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 68);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(166, 290);
            this.listBox1.TabIndex = 3;
            // 
            // lblProfiles
            // 
            this.lblProfiles.AutoSize = true;
            this.lblProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfiles.Location = new System.Drawing.Point(8, 43);
            this.lblProfiles.Name = "lblProfiles";
            this.lblProfiles.Size = new System.Drawing.Size(69, 20);
            this.lblProfiles.TabIndex = 4;
            this.lblProfiles.Text = "Perfiles";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(184, 68);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox2.Size = new System.Drawing.Size(222, 290);
            this.listBox2.TabIndex = 5;
            // 
            // lblPermissions
            // 
            this.lblPermissions.AutoSize = true;
            this.lblPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermissions.Location = new System.Drawing.Point(180, 45);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(82, 20);
            this.lblPermissions.TabIndex = 6;
            this.lblPermissions.Text = "Permisos";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(412, 68);
            this.treeView1.Name = "treeView1";
            treeNode1.BackColor = System.Drawing.Color.Transparent;
            treeNode1.Name = "Permisos";
            treeNode1.Text = "Permisos";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(239, 290);
            this.treeView1.TabIndex = 7;
            // 
            // btnAssignProfile
            // 
            this.btnAssignProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignProfile.Location = new System.Drawing.Point(12, 364);
            this.btnAssignProfile.Name = "btnAssignProfile";
            this.btnAssignProfile.Size = new System.Drawing.Size(140, 34);
            this.btnAssignProfile.TabIndex = 8;
            this.btnAssignProfile.Text = "Asignar Perfil";
            this.btnAssignProfile.UseVisualStyleBackColor = true;
            this.btnAssignProfile.Click += new System.EventHandler(this.btnAssignProfile_Click);
            // 
            // btnCreateProfile
            // 
            this.btnCreateProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateProfile.Location = new System.Drawing.Point(184, 364);
            this.btnCreateProfile.Name = "btnCreateProfile";
            this.btnCreateProfile.Size = new System.Drawing.Size(140, 34);
            this.btnCreateProfile.TabIndex = 9;
            this.btnCreateProfile.Tag = "ProfileCreate";
            this.btnCreateProfile.Text = "Crear Perfil";
            this.btnCreateProfile.UseVisualStyleBackColor = true;
            this.btnCreateProfile.Click += new System.EventHandler(this.btnCreateProfile_Click);
            // 
            // btnRemoveProfile
            // 
            this.btnRemoveProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveProfile.Location = new System.Drawing.Point(12, 404);
            this.btnRemoveProfile.Name = "btnRemoveProfile";
            this.btnRemoveProfile.Size = new System.Drawing.Size(140, 34);
            this.btnRemoveProfile.TabIndex = 10;
            this.btnRemoveProfile.Tag = "ProfileDelete";
            this.btnRemoveProfile.Text = "Eliminar Perfil";
            this.btnRemoveProfile.UseVisualStyleBackColor = true;
            this.btnRemoveProfile.Click += new System.EventHandler(this.btnRemoveProfile_Click);
            // 
            // rbLeaf
            // 
            this.rbLeaf.AutoSize = true;
            this.rbLeaf.Checked = true;
            this.rbLeaf.Location = new System.Drawing.Point(555, 364);
            this.rbLeaf.Name = "rbLeaf";
            this.rbLeaf.Size = new System.Drawing.Size(96, 17);
            this.rbLeaf.TabIndex = 11;
            this.rbLeaf.TabStop = true;
            this.rbLeaf.Text = "Permiso Simple";
            this.rbLeaf.UseVisualStyleBackColor = true;
            // 
            // rbComposite
            // 
            this.rbComposite.AutoSize = true;
            this.rbComposite.Location = new System.Drawing.Point(555, 381);
            this.rbComposite.Name = "rbComposite";
            this.rbComposite.Size = new System.Drawing.Size(118, 17);
            this.rbComposite.TabIndex = 12;
            this.rbComposite.Text = "Permiso Compuesto";
            this.rbComposite.UseVisualStyleBackColor = true;
            // 
            // btnCreatePermission
            // 
            this.btnCreatePermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePermission.Location = new System.Drawing.Point(409, 364);
            this.btnCreatePermission.Name = "btnCreatePermission";
            this.btnCreatePermission.Size = new System.Drawing.Size(140, 34);
            this.btnCreatePermission.TabIndex = 13;
            this.btnCreatePermission.Tag = "PermissionCreate";
            this.btnCreatePermission.Text = "Crear Permiso";
            this.btnCreatePermission.UseVisualStyleBackColor = true;
            this.btnCreatePermission.Click += new System.EventHandler(this.btnCreatePermission_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(533, 429);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 34);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblActualProfile
            // 
            this.lblActualProfile.AutoSize = true;
            this.lblActualProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualProfile.Location = new System.Drawing.Point(8, 9);
            this.lblActualProfile.Name = "lblActualProfile";
            this.lblActualProfile.Size = new System.Drawing.Size(111, 20);
            this.lblActualProfile.TabIndex = 15;
            this.lblActualProfile.Text = "Perfil Actual:";
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileName.Location = new System.Drawing.Point(125, 9);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(116, 20);
            this.lblProfileName.TabIndex = 16;
            this.lblProfileName.Text = "Nombre perfil";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 475);
            this.Controls.Add(this.lblProfileName);
            this.Controls.Add(this.lblActualProfile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreatePermission);
            this.Controls.Add(this.rbComposite);
            this.Controls.Add(this.rbLeaf);
            this.Controls.Add(this.btnRemoveProfile);
            this.Controls.Add(this.btnCreateProfile);
            this.Controls.Add(this.btnAssignProfile);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.lblPermissions);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.lblProfiles);
            this.Controls.Add(this.listBox1);
            this.Name = "ProfileForm";
            this.Text = "PermissionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblProfiles;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnAssignProfile;
        private System.Windows.Forms.Button btnCreateProfile;
        private System.Windows.Forms.Button btnRemoveProfile;
        private System.Windows.Forms.RadioButton rbLeaf;
        private System.Windows.Forms.RadioButton rbComposite;
        private System.Windows.Forms.Button btnCreatePermission;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblActualProfile;
        private System.Windows.Forms.Label lblProfileName;
    }
}