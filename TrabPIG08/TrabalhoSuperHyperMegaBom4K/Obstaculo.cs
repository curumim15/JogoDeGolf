using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Windows.Forms;

namespace TrabalhoSuperHyperMegaBom4K
{
    class Obstaculo
    {

        PictureBox pictureBox;

        public Obstaculo(Size s2)
        {
            pictureBox = new PictureBox();
            pictureBox.Height = s2.Height;
            pictureBox.Width = s2.Width;
        }

        public PictureBox PB
        {
            get { return this.pictureBox; }
            set { this.pictureBox = value; }
        }




    }
}
