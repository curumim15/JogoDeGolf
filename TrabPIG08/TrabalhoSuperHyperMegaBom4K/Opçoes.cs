using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoSuperHyperMegaBom4K
{
    public partial class Opçoes : Form
    {
        public static int dificuldade;
        public static int TipoBola = 2;

        private Boolean check;
        private Boolean checkBola;


        public Opçoes()
        {
            InitializeComponent();
            check = false;
            checkBola = false;
            
            if(dificuldade == 0)
            {
                checkBoxFacil.Checked = true;
            }
            if (dificuldade == 1)
            {
                checkBoxMedio.Checked = true;
            }
            if (dificuldade == 2)
            {
                checkBoxDificil.Checked = true;
            }
            



        }

        private void buttonConfir_Click(object sender, EventArgs e)
        {
             System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Sounds\clickeffect.wav");
            player.Play();
            this.Close(); 
        }

        private void checkBoxFacil_CheckedChanged(object sender, EventArgs e)
        {
            if(check == false)
            {
                check = true;
               
            }
            if (checkBoxDificil.Checked == true || checkBoxMedio.Checked == true)
            {
                checkBoxFacil.Checked = false;
            }
            if(checkBoxFacil.Checked == true)
            {
                dificuldade = 0;
            }
           

        }

        private void checkBoxMedio_CheckedChanged(object sender, EventArgs e)
        {
            if (check == false)
            {
                dificuldade = 1;
                check = true;
     
            }

            if (checkBoxFacil.Checked == true || checkBoxDificil.Checked == true)
            {
                checkBoxMedio.Checked = false;
            }

            if (checkBoxMedio.Checked == true)
            {
                dificuldade = 1;
            }
        }

        private void checkBoxDificil_CheckedChanged(object sender, EventArgs e)
        {
            if (check == false)
            {
                dificuldade = 2;
                check = true;

            }

            if (checkBoxFacil.Checked == true || checkBoxMedio.Checked == true)
            {
                checkBoxDificil.Checked = false;
            }


            if (checkBoxDificil.Checked == true)
            {
                dificuldade = 2;
            }
        }

        private void pictureBoxBasket_Click(object sender, EventArgs e)
        {
            if (checkBola == false)
            {
                TipoBola = 0;
                pictureBoxBasket.BackColor = Color.White;
                checkBola = !checkBola;

            }
            else if (checkBola == true)
            {
                pictureBoxBasket.BackColor = Color.Transparent;
                checkBola = !checkBola;
            }
          

        }

        private void pictureBoxFut_Click(object sender, EventArgs e)
        {
            if (checkBola == false)
            {
                TipoBola = 1;
                pictureBoxFut.BackColor = Color.White;
                checkBola = !checkBola;

            }
           else  if(checkBola == true)
            {
                pictureBoxFut.BackColor = Color.Transparent;
                checkBola = !checkBola;
            }
            
        }

        private void pictureBoxGolf_Click(object sender, EventArgs e)
        {
            if (checkBola == false)
            {
                TipoBola = 2;
                pictureBoxGolf.BackColor = Color.White;
                checkBola = !checkBola;

            }
            else if (checkBola == true)
            {
                pictureBoxGolf.BackColor = Color.Transparent;
                checkBola = !checkBola;
            }

          
        }

        private void pictureBoxTenis_Click(object sender, EventArgs e)
        {
            if (checkBola == false)
            {
                TipoBola = 3;
                pictureBoxTenis.BackColor = Color.White;
                checkBola = !checkBola;
               
            }
            else if (checkBola == true)
            {
                pictureBoxTenis.BackColor = Color.Transparent;
                checkBola = !checkBola;

            }
            
        }

        private void pictureBoxRugby_Click(object sender, EventArgs e)
        {
            if (checkBola == false)
            {
                TipoBola = 4;
                pictureBoxRugby.BackColor = Color.White;
                checkBola = !checkBola;

            }
            else if (checkBola == true)
            {
                pictureBoxRugby.BackColor = Color.Transparent;
                checkBola = !checkBola;

            }
        }

        private void pictureBoxPingPong_Click(object sender, EventArgs e)
        {
            if (checkBola == false)
            {
                TipoBola = 5;
                pictureBoxPingPong.BackColor = Color.White;
                checkBola = !checkBola;

            }
            else if (checkBola == true)
            {
                pictureBoxPingPong.BackColor = Color.Transparent;
                checkBola = !checkBola;

            }
        }

        private void Opçoes_Load(object sender, EventArgs e)
        {

        }
    }
}
