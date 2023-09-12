using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using BEL;
using BLL;
using ServiceClasses;

namespace Controles
{
    public partial class ComboBoxImage: UserControl
    {
        public ComboBoxImage()
        {
            InitializeComponent();
            cmbImages.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbImages.DrawMode = DrawMode.OwnerDrawFixed;
            cmbImages.Items.AddRange(Enumerable.Repeat<string>("", listImages.Images.Count).ToArray());
        }
        bllUsuario a;
        private void cmbImages_DrawItem(object sender, DrawItemEventArgs e)
        {
            string[] items = new string[] { "Español", "English" };
            e.DrawBackground();
            e.DrawFocusRectangle();
            if(e.Index >= 0)
            {
                if(e.Index < listImages.Images.Count)
                {
                    Image img = new Bitmap(listImages.Images[e.Index], new Size(16, 16));
                    e.Graphics.DrawImage(img, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
                e.Graphics.DrawString(string.Format(items[e.Index], e.Index + 1), e.Font, new SolidBrush(e.ForeColor)
                    , e.Bounds.Left + 16, e.Bounds.Top);
            }
        }

        private void cmbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(a == null) a = new bllUsuario();
            ComboBox combo = (ComboBox)sender;
            int x = combo.SelectedIndex + 1;
            if (SessionManager.GetInstance == null)
            {
                LanguageManager.CambiarIdioma(x.ToString());
            }
            else
            {
                SessionManager sm = SessionManager.GetInstance;
                if (combo.SelectedIndex >= 0)
                {
                    sm.user.Idioma = LanguageManager.ListaIdioma.Find(y => y.Id == x.ToString());
                    LanguageManager.CambiarIdioma(sm.user.Idioma.Id);
                    a.Modificacion(sm.user);
                }
            }        
            if(combo.SelectedIndex >= 0)
            {
                picImage.Image = listImages.Images[combo.SelectedIndex];
            }
            else
            {
                picImage.Image = null;
            }
        }

        public ComboBox RetornaComboBox()
        {
            return cmbImages;
        }

        private void cmbImages_Resize(object sender, EventArgs e)
        {
            cmbImages.Width = Width;
            cmbImages.Height = Height;
        }

        private void ComboBoxImage_Resize(object sender, EventArgs e)
        {
            cmbImages_Resize(null, null);
        }
    }
}
