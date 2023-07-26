namespace Controles
{
    partial class ComboBoxImageNotEvent
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComboBoxImageNotEvent));
            this.cmbImages = new System.Windows.Forms.ComboBox();
            this.listImages = new System.Windows.Forms.ImageList(this.components);
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbImages
            // 
            this.cmbImages.FormattingEnabled = true;
            this.cmbImages.Location = new System.Drawing.Point(0, 0);
            this.cmbImages.Name = "cmbImages";
            this.cmbImages.Size = new System.Drawing.Size(105, 21);
            this.cmbImages.TabIndex = 0;
            this.cmbImages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbImages_DrawItem);
            this.cmbImages.SelectedIndexChanged += new System.EventHandler(this.cmbImages_SelectedIndexChanged);
            this.cmbImages.Resize += new System.EventHandler(this.cmbImages_Resize);
            // 
            // listImages
            // 
            this.listImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listImages.ImageStream")));
            this.listImages.TransparentColor = System.Drawing.Color.Transparent;
            this.listImages.Images.SetKeyName(0, "bandera-espana-224c725f1e6eaac8ff319d60bae7127f.jpg");
            this.listImages.Images.SetKeyName(1, "R.png");
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(189, 27);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 50);
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            // 
            // ComboBoxImageNotEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.cmbImages);
            this.Name = "ComboBoxImageNotEvent";
            this.Size = new System.Drawing.Size(105, 22);
            this.Resize += new System.EventHandler(this.ComboBoxImageNotEvent_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbImages;
        private System.Windows.Forms.ImageList listImages;
        private System.Windows.Forms.PictureBox picImage;
    }
}
