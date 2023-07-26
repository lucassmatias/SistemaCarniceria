using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles
{
    public partial class ComboBoxImageNotEvent : UserControl
    {
        public ComboBoxImageNotEvent()
        {
            InitializeComponent();
            cmbImages.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbImages.DrawMode = DrawMode.OwnerDrawFixed;
            cmbImages.Items.AddRange(Enumerable.Repeat<string>("", listImages.Images.Count).ToArray());
        }

        public ComboBox RetornaComboBox()
        {
            return cmbImages;
        }
        private void cmbImages_DrawItem(object sender, DrawItemEventArgs e)
        {
            string[] items = new string[] { "Español", "English" };
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
            {
                if (e.Index < listImages.Images.Count)
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
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedIndex >= 0)
            {
                picImage.Image = listImages.Images[combo.SelectedIndex];
            }
            else
            {
                picImage.Image = null;
            }
        }

        private void cmbImages_Resize(object sender, EventArgs e)
        {
            cmbImages.Width = Width;
            cmbImages.Height = Height;
        }

        private void ComboBoxImageNotEvent_Resize(object sender, EventArgs e)
        {
            cmbImages_Resize(null, null);
        }
    }
}
