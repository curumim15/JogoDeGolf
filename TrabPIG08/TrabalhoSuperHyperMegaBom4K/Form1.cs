using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing;
using System.Threading;

namespace TrabalhoSuperHyperMegaBom4K
{
    public partial class FormMain : Form
    {
        public static int w, h;
        public static Point posRato;
        public static Boolean mouseBaixo;
        private Arena arena;
        private static Bola bola;
        private static List<Obstaculo> obstaculos;
        private int NumTacadas = 0;
        private bool newlvl;

        internal static List<Obstaculo> Obstaculos { get => obstaculos; set => obstaculos = value; }
        internal static Bola Bola { get => bola; set => bola = value; }

        public FormMain()
        {
            InitializeComponent();

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Sounds\soundeffect.wav");
            player.Play();

            w = panel.DisplayRectangle.Width;
            h = panel.DisplayRectangle.Height;

            Bola = new Bola();

            if(Opçoes.TipoBola == 0)
            {
                Bola.PB.Image = Image.FromFile(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Resources\basket.png");
            }
            if(Opçoes.TipoBola == 1)
            {
                Bola.PB.Image = Image.FromFile(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Resources\fute.png");
            }
            if(Opçoes.TipoBola == 2)
            {
                Bola.PB.Image = Image.FromFile(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Resources\Golf-Ball.png");
            }
            if(Opçoes.TipoBola == 3)
            {
                Bola.PB.Image = Image.FromFile(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Resources\tenis.png");
            }
            if (Opçoes.TipoBola == 4)
            {
                Bola.PB.Image = Image.FromFile(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Resources\rugby.png");
            }
            if (Opçoes.TipoBola == 5)
            {
                Bola.PB.Image = Image.FromFile(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Resources\pingpong.png");
            }


            Bola.PB.SizeMode = PictureBoxSizeMode.StretchImage;


            panel.Controls.Add(Bola.PB);

            obstaculos = new List<Obstaculo>();

            mouseBaixo = false;
            arena = new Arena(w, h);

            for (int i = obstaculos.Count - 1; i >= 0; i--)
            {
                panel.Controls.Remove(obstaculos[i].PB);
            }
            Obstaculos.Clear();
            newlvl = false;

        }

        // Fecha a aplicação do jogo, remove todos os obstáculos do panel e “limpa” a lista com todos os obstáculos.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Sounds\clickeffect.wav");
            player.Play();
            for (int i = obstaculos.Count - 1; i >= 0; i--)
            {
                panel.Controls.Remove(obstaculos[i].PB);
            }
            Obstaculos.Clear();


            Application.Exit();
        }


        // Atualiza toda a área de desenho na arena
        private void redesenhaArena()
        {
            BufferedGraphicsContext currentContext;
            BufferedGraphics myBuffer;
            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(this.panel.CreateGraphics(),
            this.panel.DisplayRectangle);
            Graphics g = myBuffer.Graphics;

            desenhaArena(g);
            


            myBuffer.Render();
            myBuffer.Dispose();
        }

        // Desenha a arena, o obstáculo curvo e o buraco
        private void desenhaArena(Graphics g)
        {
            g.Clear(panel.BackColor);
            arena.draw(g);
            if (newlvl == true)
            {
                arena.DrawCurvoBuraco(g);
            }
           
        }

        // Faz todos os desenhos presentes nesta moverem-se
        private void calculaMover()
        {
            arena.move();

        }

        //  Faz todos os movimentos do jogo, verifica se ganhamos o jogo
        private void Gametimer_Tick(object sender, EventArgs e)
        {
            labelTacadas.Text = "Nª Tacadas : " + NumTacadas;

            if (Arena.ganhar)
            {
                txtWin.Visible = true;
                txtWin.BringToFront();
                txtWin.Text = "Ganhaste !! Fizeste " + NumTacadas + " tacadas";
                FormMain.Bola.PB.Visible = false;

            }
            
            calculaMover();
            redesenhaArena();
        }


        // Obtém a posição do mouse
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
                posRato.X = e.X;
                posRato.Y = e.Y;
                LabelRato.Text = e.Location.ToString();

        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseBaixo = true;
   
        }

        // Determina se a distancia permitida para lançar a bola passou o limite, aplicando uma velocidade á bola
        private void panel_MouseUp(object sender, MouseEventArgs e)
        { 

            mouseBaixo = false;
            if (bola.Velo.X == 0 && bola.Velo.Y == 0 && Bola.Distancia.Length() < 90)
            {

                bola.Velo = bola.Distancia;
                NumTacadas++;

            }

        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Sounds\clickeffect.wav");
            player.Play();
            txtWin.Visible = false;
            FormMain.Bola.PB.Visible = true;
            NumTacadas = 0;
            redesenhaArena();
            Gametimer.Start();
            arena.Restart();


        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            desenhaArena(e.Graphics);
        }

        // // Dá um reset ao número de tacadas, posição da bola e velocidade, remove todos os obstáculos da form e utiliza o método arena
        private void newNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Sounds\clickeffect.wav");
            player.Play();
            NumTacadas = 0;
            FormMain.Bola.PB.Visible = true;

            for (int i = obstaculos.Count - 1; i >= 0; i--)
            {
                panel.Controls.Remove(obstaculos[i].PB);
            }

            Point p = new Point(70, FormMain.h / 2);
            FormMain.Bola.PB.Location = p;
            FormMain.Bola.veloX = 0;
            FormMain.Bola.veloY = 0;
        
            arena.StartGame();
            desenharObs();
            newlvl = true;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            w = panel.DisplayRectangle.Width;
            h = panel.DisplayRectangle.Height;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        // Insere todos os obstáculos contidos na sua respetiva lista do panel
        private void desenharObs()
        {
            if (obstaculos[0] != null)
            {
                for (int i = obstaculos.Count - 1; i >= 0; i--)
                {
                    if (obstaculos[i].PB.Width > obstaculos[i].PB.Height)
                    {
                        //obstaculos[i].PB.Image = Image.FromFile(@"C:\Users\andre\Desktop\PlatHorizontal.png");
                        //obstaculos[i].PB.SizeMode = PictureBoxSizeMode.StretchImage;
                        obstaculos[i].PB.BorderStyle = BorderStyle.None;
                        obstaculos[i].PB.BackColor = Color.SandyBrown;


                        panel.Controls.Add(obstaculos[i].PB);
                        FormMain.Obstaculos[i].PB.BringToFront();

                    }
                    else if (obstaculos[i].PB.Width < obstaculos[i].PB.Height)
                    {
                        //obstaculos[i].PB.Image = Image.FromFile(@"C:\Users\andre\Desktop\PlatVertical.png");
                        //obstaculos[i].PB.SizeMode = PictureBoxSizeMode.StretchImage;
                        obstaculos[i].PB.BorderStyle = BorderStyle.None;
                        obstaculos[i].PB.BackColor = Color.SandyBrown;

                        panel.Controls.Add(obstaculos[i].PB);
                        FormMain.Obstaculos[i].PB.BringToFront();

                    }

                    
                

                }

            }

        }

    }
}
