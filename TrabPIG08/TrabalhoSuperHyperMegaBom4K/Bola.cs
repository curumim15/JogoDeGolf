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
    class Bola
    {

        float atrito;
        private Vector2 acel;

        private Vector2 velo;
        private Vector2 distancia;
        private Vector2 pos;
        private int massa;



        PictureBox pictureBox;


        public Bola()
        {

            atrito = 0.8f;
            pos = new Vector2(70, FormMain.h / 2);

            velo = new Vector2(0);
            acel = new Vector2(0);
            massa = 10;


            pictureBox = new PictureBox();

            pictureBox.Height = 20;
            pictureBox.Width = 20;

            pictureBox.Location = new Point((int)posX, (int)posY);


        }




        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public int Left {

            get { return pictureBox.Left; }
            set { pictureBox.Left = value; }

        }
        public float posX
        {
            get { return this.pos.X; }
            set { this.pos.X = value; }
        }

        public  float posY
        {
            get { return this.pos.Y; }
            set { this.pos.Y = value; }
        }

        public float veloX
        {
            get { return velo.X; }
            set { velo.X = value; }
        }

        public float veloY
        {
            get { return velo.Y; }
            set { velo.Y = value; }
        }

        public Vector2 Velo
        {
            get { return velo; }
            set { velo = value; }
        }

        public Vector2 Acel
        {
            get { return acel; }
            set { acel = value; }
        }

        public Vector2 Distancia
        {
            get { return distancia; }
            set { distancia = value; }
        }




        public PictureBox PB
        {
            get { return this.pictureBox; }
            set { this.pictureBox = value; }
        }


        // Este método permite aplicar a força que desejarmos á bola.  
        public void aplicarForca(Vector2 force)
        {
              velo += Vector2.Divide(force, massa);
        }
        
        // Faz o movimento da bola
        public void move()
        {
            if (velo.X < 0.2 && velo.Y < 0.2 && velo.X > -0.2 && velo.Y > -0.2)
                {
                   
                    velo.X = 0;
                    velo.Y = 0;
                }


                velo *= atrito;

                pictureBox.Left += (int)velo.X;
                pictureBox.Top += (int)veloY;

        }

        // Permite desenhar a linha a tracejado, a seta e o circulo em redor da bola
        public void draw(Graphics g)
        {
       

            Pen lapis = new Pen(Color.Black);
            Pen lapis1 = new Pen(Color.Red);
            Pen lapis2 = new Pen(Color.White);
            lapis1.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            lapis.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            lapis1.Width = 6;
            lapis.Width = 3;

            distancia = new Vector2((pictureBox.Left + pictureBox.Width / 2) - FormMain.posRato.X, ( pictureBox.Top + pictureBox.Height / 2 ) - FormMain.posRato.Y);

            if (distancia.Length() < 90 && FormMain.mouseBaixo && Velo.X == 0 &&  Velo.Y == 0)
            {
               

                g.DrawLine(lapis, pictureBox.Left+pictureBox.Width/2, pictureBox.Top+ pictureBox.Height / 2, FormMain.posRato.X, FormMain.posRato.Y);

                g.DrawLine(lapis1, pictureBox.Left+pictureBox.Width / 2, pictureBox.Top + pictureBox.Height / 2, (pictureBox.Left+pictureBox.Width/2) + distancia.X, (pictureBox.Top+ pictureBox.Height / 2) + distancia.Y);




                g.DrawEllipse(lapis2, pictureBox.Left - 80, pictureBox.Top - 80, 180, 180);
         

            }

  
        }

    }
}
