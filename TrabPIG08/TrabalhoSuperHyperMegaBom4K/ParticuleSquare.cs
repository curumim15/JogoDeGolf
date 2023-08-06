using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrabalhoSuperHyperMegaBom4K
{
    class ParticuleSquare : Particule
    {
        private float angle, aVelo;

        public ParticuleSquare(Vector2 pos) : base(pos)
        {
            angle = 0;
            aVelo = rnd.Next(-9, 9);
        }

        public override void draw(Graphics g)
        {
            g.ResetTransform();
            g.RotateTransform(angle);
            g.TranslateTransform(pos.X, pos.Y, MatrixOrder.Append);
            g.FillRectangle(brush, area);
        }

        public override void move()
        {
            base.move();
            angle += aVelo;
        }
    }
}
