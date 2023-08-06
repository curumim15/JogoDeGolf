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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Sounds\clickeffect.wav");
            player.Play();
            Application.Exit();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Sounds\clickeffect.wav");
            player.Play();
            FormMain gameWindow = new FormMain();
            gameWindow.Show();
            this.Hide();
        }

        private void buttonOpçoes_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\berna\Escola\PROGIG\TrabalhoPratico\TrabPIG08\TrabalhoSuperHyperMegaBom4K\Sounds\clickeffect.wav");
            player.Play();
            Opçoes gameWindow = new Opçoes();
            gameWindow.Show();
        }
    }
}
