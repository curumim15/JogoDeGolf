using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace TrabalhoSuperHyperMegaBom4K
{
    class ObsCurvo
    {
        private Vector2 pos;
        private RectangleF aread,areaf, areaObs;
        private Region regiao,regiaofora;
        private SolidBrush brushcurvo;
        private GraphicsPath gp,gpcurvo;
    


        public ObsCurvo(float x, float y)
        {
            pos = new Vector2(x -100 , y - 115);
 
            aread = new RectangleF(120, 120, 150, 160);

            areaf = new RectangleF(100, 100, 200, 200);

            areaObs = new RectangleF(pos.X +100, pos.Y +115, 100, 170);
          
            gpcurvo = new GraphicsPath();
            gpcurvo.AddArc(areaf, -120, -125);

            regiaofora = new Region(gpcurvo);


            gp = new GraphicsPath();
            gp.AddArc(aread, -120, -125);
        
        
            regiao = new Region(gp);

            brushcurvo = new SolidBrush(Color.SandyBrown);

            regiaofora.Exclude(regiao);
            regiaofora.Translate(pos.X , pos.Y);
            regiao.Translate(pos.X , pos.Y );
          


        }
        public Region Regiao
        {
            get { return regiao; }
            set { regiao = value; }
        }

        public Region RegiaoFora
        {
            get { return regiaofora; }
            set { regiaofora = value; }
        }

        public RectangleF AreaObs
        {
            get { return areaObs; }
            set { areaObs = value; }
        }

        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }



        // Desenha o/s obstáculo/s curvo/s no panel
        public void drawCurvo(Graphics g)
        {

            g.ResetTransform();
            g.FillRegion(brushcurvo, regiaofora);

        }
    }
}
