using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    class Jatekos
    {
        public readonly int Id;
        public readonly string Nev;
        public bool jatszottE = false;

        public Jatekos(int id, string nev)
        {
            Id = id;
            Nev = nev;
        }

        public int Lepes()
        {
            Random rnd = new Random();
            return rnd.Next(0, 3);
        }

    }
}
