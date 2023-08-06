using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;


namespace TrabalhoSuperHyperMegaBom4K
{
    class Particulas
    {
        private List<Particule> particules;
        Vector2 emiter;

        Random rnd;

        public Particulas(Vector2 pos)
        {
            rnd = new Random();

            particules = new List<Particule>();
            emiter = pos;
        }

        public Vector2 Emiter
        {
            get { return emiter; }
            set { emiter = value; }
        }

        public void draw(Graphics g)
        {
            foreach (Particule p in particules)
                p.draw(g);
        }

        public void move()
        {
            particules.Add(addNew());
            for (int i = particules.Count - 1; i >= 0; i--)
            {
                particules[i].move();
                if (particules[i].isDead())
                    particules.RemoveAt(i);
            }
        }

        private Particule addNew()
        {
            double pr = rnd.NextDouble();
            if (pr < 1) return new Particule(emiter);
            else return new ParticuleSquare(emiter);
        }
    }
}
