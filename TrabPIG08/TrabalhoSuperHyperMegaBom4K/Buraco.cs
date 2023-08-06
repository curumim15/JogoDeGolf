using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace TrabalhoSuperHyperMegaBom4K
{
    class Buraco
    {
        private SolidBrush pincel;
        private RectangleF area;
        private  Vector2 pos;


        public Buraco()
        {
            pos = new Vector2(FormMain.w-100, FormMain.h/2);
            area = new RectangleF(-12, -12, 12 * 2, 12 * 2);
            pincel = new SolidBrush(Color.Black);
        }
        public  Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }


        // Desenha o buraco no panel
        public void drawB(Graphics g)
        {

            g.ResetTransform();

            g.TranslateTransform(FormMain.w - 100, FormMain.h / 2);
            g.FillEllipse(pincel,area);
        }




    }
}
