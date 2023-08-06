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
    // É nesta classe que determinamos a área do jogo e a maior parte dos métodos para desenhar, criar e remover os vários objetos do jogo
    class Arena
    {
        public static Size area;
        private Buraco buraco;
        public static Boolean ganhar;
        private ObsCurvo curvo, curvo1;
        private int nObs;

        Particulas system;
        Random rnd;

        public Arena(int w1, int h1)
        {
            ganhar = false;
            rnd = new Random();
            area.Width = w1;
            area.Height = h1;

            StartGame();
        }

        // São criados os obstáculos retangulares, obstáculo curvo, o buraco e as particulas
        public void StartGame()
        {
            FormMain.Obstaculos.Clear();

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Sounds\soundeffect.wav");
            player.Play();


            Random rnd1 = new Random();


            if (Opçoes.dificuldade == 0)
            {
                nObs = rnd1.Next(3, 5);
            }
            if (Opçoes.dificuldade == 1)
            {
                nObs = rnd1.Next(5, 8);

                curvo = new ObsCurvo(rnd.Next(100, FormMain.w - 150), rnd.Next(0, FormMain.h - 200));
            }
            if (Opçoes.dificuldade == 2)
            {
                nObs = rnd1.Next(8, 14);
                curvo = new ObsCurvo(rnd.Next(100, FormMain.w - 150), rnd.Next(0, FormMain.h - 200));
                curvo1 = new ObsCurvo(rnd.Next(100, FormMain.w - 150), rnd.Next(0, FormMain.h - 200));
            }


            int x, y;
           

            Size s = new Size(20, 150);
            Size s1 = new Size(150, 20);

            for (int i = 0; i < nObs; i++)
            {


                x = rnd1.Next(1, 3);


                if (x == 1)
                {
                    Obstaculo b = new Obstaculo(s);
                    x = rnd.Next(100, FormMain.w - 150);
                    y = rnd.Next(0, FormMain.h - s.Height);

                    b.PB.Location = new Point(x, y);

                    FormMain.Obstaculos.Add(b);

                }
                else if (x == 2)
                {
                    Obstaculo b = new Obstaculo(s1);

                    x = rnd.Next(100, FormMain.w - 150);
                    y = rnd.Next(0, FormMain.h - s1.Height);

                    b.PB.Location = new Point(x, y);
                    FormMain.Obstaculos.Add(b);
                }



            }
            
            buraco = new Buraco();

            system = new Particulas(buraco.Pos);

            system.Emiter = buraco.Pos;


        }


        // Dá um reset á posição da bola, anulando a sua velocidade
        public void Restart()
        {

            Point p = new Point(70, FormMain.h / 2);
            FormMain.Bola.PB.Location = p;

            FormMain.Bola.veloX = 0;
            FormMain.Bola.veloY = 0;

            ganhar = false;

        }

        // Verifica se a bola intercetou algum dos obstáculos retangulares presentes.
        public void intersectaLateralObsX()
        {

            for (int i = FormMain.Obstaculos.Count - 1; i >= 0; i--)
            {

                Vector2 force = new Vector2(0);
                float intensidade = 30f;

                Point p = new Point(FormMain.Obstaculos[i].PB.Location.X, FormMain.Obstaculos[i].PB.Location.Y);
                Point p2 = new Point(FormMain.Obstaculos[i].PB.Location.X, FormMain.Obstaculos[i].PB.Bounds.Bottom - 3);


                Size z = new Size(FormMain.Obstaculos[i].PB.Width, 3);

                Size z2 = new Size(FormMain.Obstaculos[i].PB.Width, 3);

                Rectangle rect = new Rectangle(p, z);
                Rectangle rect2 = new Rectangle(p2, z2);


                if (FormMain.Bola.PB.Location.Y <= FormMain.Obstaculos[i].PB.Bounds.Bottom && FormMain.Bola.PB.Location.Y >= FormMain.Obstaculos[i].PB.Location.Y &&
                    FormMain.Bola.PB.Location.X <= FormMain.Obstaculos[i].PB.Location.X && FormMain.Bola.PB.Bounds.Right >= FormMain.Obstaculos[i].PB.Location.X ||
                    FormMain.Bola.PB.Location.Y + 20 <= FormMain.Obstaculos[i].PB.Bounds.Bottom && FormMain.Bola.PB.Location.Y + 20 >= FormMain.Obstaculos[i].PB.Location.Y &&
                    FormMain.Bola.PB.Location.X <= FormMain.Obstaculos[i].PB.Location.X && FormMain.Bola.PB.Bounds.Right >= FormMain.Obstaculos[i].PB.Location.X)
                {

                    FormMain.Bola.veloX *= -1;
                    force.X = -intensidade;
                    FormMain.Bola.aplicarForca(force);

                }
                else if (FormMain.Bola.PB.Location.Y <= FormMain.Obstaculos[i].PB.Bounds.Bottom && FormMain.Bola.PB.Location.Y >= FormMain.Obstaculos[i].PB.Location.Y &&
                         FormMain.Bola.PB.Bounds.Right >= FormMain.Obstaculos[i].PB.Bounds.Right && FormMain.Bola.PB.Location.X <= FormMain.Obstaculos[i].PB.Bounds.Right ||
                         FormMain.Bola.PB.Location.Y + 20 <= FormMain.Obstaculos[i].PB.Bounds.Bottom && FormMain.Bola.PB.Location.Y + 20 >= FormMain.Obstaculos[i].PB.Location.Y &&
                         FormMain.Bola.PB.Bounds.Right >= FormMain.Obstaculos[i].PB.Bounds.Right && FormMain.Bola.PB.Location.X <= FormMain.Obstaculos[i].PB.Bounds.Right)
                {
                    FormMain.Bola.veloX *= -1;
                    force.X = +intensidade;
                    FormMain.Bola.aplicarForca(force);

                }


                if (FormMain.Bola.PB.Bounds.IntersectsWith(rect))
                {

                    FormMain.Bola.veloY = -FormMain.Bola.veloY;
                    force.Y = -intensidade;
                    FormMain.Bola.aplicarForca(force);

                }

                else if (FormMain.Bola.PB.Bounds.IntersectsWith(rect2))
                {

                    FormMain.Bola.veloY = -FormMain.Bola.veloY;
                    force.Y = +intensidade;
                    FormMain.Bola.aplicarForca(force);

                }
            }
        }

        // Verifica se a bola intercetou as laterais da área da arena.
        public void intersectaLateral()
        {
            if (FormMain.Bola.PB.Location.X <= 0)
            {
                FormMain.Bola.veloX *= -1;
                FormMain.Bola.PB.Left = FormMain.Bola.PB.Location.X + 2;
            }
            else if (FormMain.Bola.PB.Bounds.Right >= FormMain.w)
            {
                FormMain.Bola.veloX *= -1;
                FormMain.Bola.PB.Left = FormMain.w - FormMain.Bola.PB.Width;
            }
            if (FormMain.Bola.PB.Location.Y <= 0)
            {
                FormMain.Bola.veloY *= -1;
                FormMain.Bola.PB.Top = FormMain.Bola.PB.Location.Y + 2;

            }
            else if (FormMain.Bola.PB.Bounds.Bottom >= FormMain.h)
            {
                FormMain.Bola.veloY *= -1;

                FormMain.Bola.PB.Top = FormMain.h - FormMain.Bola.PB.Height;
            }


            if (FormMain.Bola.PB.Bounds.Right >= FormMain.w - 100 && FormMain.Bola.PB.Location.X <= FormMain.w - 100 + 24 && FormMain.Bola.PB.Bounds.Bottom >= FormMain.h / 2 && FormMain.Bola.PB.Bounds.Location.Y <= FormMain.h / 2 + 24)
            {
                ganhar = true;
            }

        }

        // Verifica se a bola intercetou algum dos obstáculos curvos presentes
        public void BolaInterceptaRegiao(ObsCurvo curvo)
        {

            if (curvo.Regiao.IsVisible(FormMain.Bola.PB.Bounds) && curvo.RegiaoFora.IsVisible(FormMain.Bola.PB.Bounds))
            {
                Vector2 force = new Vector2(0);
                Vector2 temp;

                if (FormMain.Bola.veloY > 0)
                {
                    FormMain.Bola.PB.Left = (int)curvo.AreaObs.X + 60;
                    FormMain.Bola.PB.Top = (int)curvo.AreaObs.Y + 150;

                    temp.X = (float)Math.Cos(120) * FormMain.Bola.Velo.Length();
                    temp.Y = (float)Math.Sin(120) * FormMain.Bola.Velo.Length();

                    FormMain.Bola.Velo = temp;
                }
                else if (FormMain.Bola.veloY < 0)
                {
                    FormMain.Bola.PB.Left = (int)curvo.AreaObs.X + 55;
                    FormMain.Bola.PB.Top = (int)curvo.AreaObs.Y + 20;

                    temp.X = -(float)Math.Cos(60) * FormMain.Bola.Velo.Length();
                    temp.Y = (float)Math.Sin(60) * FormMain.Bola.Velo.Length();

                    FormMain.Bola.Velo = temp;
                }
            }

            if (curvo.Regiao.IsVisible(FormMain.Bola.PB.Bounds) == false && curvo.RegiaoFora.IsVisible(FormMain.Bola.PB.Bounds))
            {
                FormMain.Bola.veloX = -FormMain.Bola.veloX;
                FormMain.Bola.veloY = +FormMain.Bola.veloY;

                FormMain.Bola.PB.Left = FormMain.Bola.PB.Left - 6;
                FormMain.Bola.PB.Top = FormMain.Bola.PB.Top - 6;
            }
        }

        // Verifica todas as condições em que a bola se pode mover, movendo a bola de seguida
        public void move()
        {
            intersectaLateralObsX();

            if(Opçoes.dificuldade == 1)
            {
                BolaInterceptaRegiao(curvo);
            }
           if( Opçoes.dificuldade == 2)
            {
                BolaInterceptaRegiao(curvo);
                BolaInterceptaRegiao(curvo1);
            }


         
            intersectaLateral();
            FormMain.Bola.move();
            system.move();
        }


        // Desenha todas as figuras no panel
        public void draw(Graphics g)
        {
            FormMain.Bola.draw(g);

            if (ganhar == true)
            {
                system.draw(g);
            }
        }

        public void DrawCurvoBuraco(Graphics g)
        {
            buraco.drawB(g);
            if (Opçoes.dificuldade == 1)
            {
                curvo.drawCurvo(g);
            }
            if (Opçoes.dificuldade == 2)
            {
                curvo.drawCurvo(g);
                curvo1.drawCurvo(g);
            }
              
        }
    }
}
