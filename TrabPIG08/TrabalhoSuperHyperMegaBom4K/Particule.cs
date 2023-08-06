using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace TrabalhoSuperHyperMegaBom4K
{
    class Particule
    {

        protected Vector2 pos, velo, acel;
        protected float lifeSpan;

        protected Random rnd;

        protected SolidBrush brush;
        protected float radius;
        protected RectangleF area;
        protected Color fillColor;

        public Particule(Vector2 orig)
        {
            rnd = new Random((int)DateTime.Now.Ticks);
            pos = orig;
            velo = new Vector2(
                (float)(rnd.NextDouble() * 4.0 - 2.0),
                (float)(rnd.NextDouble() * -3.0));
            acel = new Vector2(0, 0.05f);
            lifeSpan = 255;

            fillColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            brush = new SolidBrush(Color.FromArgb(255, fillColor));
            radius = 5f;
            area = new RectangleF(-radius, -radius, radius * 2, radius * 2);
        }

        public virtual void move()
        {
            velo += acel;
            pos += velo;
            lifeSpan -= 2;
        }

        public virtual void draw(Graphics g)
        {
            brush.Color = Color.FromArgb((int)lifeSpan, fillColor);
            g.ResetTransform();
            g.TranslateTransform(pos.X, pos.Y);
            g.FillEllipse(brush, area);
        }

        public Boolean isDead()
        {
            return lifeSpan <= 0;
        }

    }
}
