using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmShowImage : Form
    {
        public FrmShowImage()
        {
            InitializeComponent();
        }

        Image image;
        public FrmShowImage(Image image)
        {
            InitializeComponent();
            this.image = image;
        }
        private void FrmShowImage_Load(object sender, EventArgs e)
        {
            pbShowImage.Image = this.image;
        }

        private void FrmShowImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
