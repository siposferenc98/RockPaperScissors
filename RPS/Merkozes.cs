using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    class Merkozes
    {
        private Dictionary<Jatekos,int> pontok = new ();
        private Dictionary<Jatekos, KPO?> kor = new ();
        private int _korok;
        private Jatekos j1, j2;
        private enum KPO
        {
            Ko,
            Papir,
            Ollo
        }

        public Merkozes(Jatekos j1, Jatekos j2)
        {
            this.j1 = j1;
            this.j2 = j2;
            pontok.Add(j1, 0);
            pontok.Add(j2, 0);
            kor.Add(j1, null);
            kor.Add(j2, null);
            _korok = 10;
            MerkozesKezd();
        }

        private void MerkozesKezd()
        {
            for (int i = 0; i < _korok; i++)
            {
                Jatekos nyertes = KorNyertes();
                if (nyertes != null)
                    pontok[nyertes]++;
                //Kiir(i, nyertes);
            }
            if (pontok[j1] == pontok[j2])
            {
                Jatekos nyertes = KorNyertes();
                while (nyertes == null)
                    nyertes = KorNyertes();
                if (nyertes != null)
                    pontok[nyertes]++;
               // Kiir("Utolsó", nyertes);
            }


            /*foreach (KeyValuePair<Jatekos, int> s in pontok)
            {
                Console.WriteLine($"Ember: {s.Key.Id} ---- Pontok: {s.Value}");
            }*/
        }

        private Jatekos KorNyertes()
        {
            kor[j1] = (KPO)j1.Lepes();
            kor[j2] = (KPO)j2.Lepes();
            Jatekos nyertes = Pontoz();
            return nyertes;
        }

        private Jatekos Pontoz()
        {
            switch (kor[j1])
            {
                case KPO.Ko:
                    if (kor[j2] == KPO.Ollo)
                        return j1;
                    else if (kor[j2] == KPO.Papir)
                        return j2;
                    else
                        _korok++;
                    break;
                case KPO.Papir:
                    if (kor[j2] == KPO.Ko)
                        return j1;
                    else if (kor[j2] == KPO.Ollo)
                        return j2;
                    else
                        _korok++;
                    break;
                case KPO.Ollo:
                    if (kor[j2] == KPO.Papir)
                        return j1;
                    else if (kor[j2] == KPO.Ko)
                        return j2;
                    else
                        _korok++;
                    break;   
            }
            return null;
        }


        private void Kiir<T>(T i, Jatekos nyertes)
        {
            Console.WriteLine($"{i}. Kör");
            Console.WriteLine("--------------------");
            foreach (KeyValuePair<Jatekos, KPO?> pair in kor)
            {
                Console.WriteLine($"Ember: {pair.Key.Id} ---- {pair.Value}");
            }
            if (nyertes != null)
                Console.WriteLine($"{nyertes.Id} Nyert!");
            else
                Console.WriteLine("Döntetlen!");
            Console.WriteLine("--------------------");
        }

        public (Jatekos,int,Jatekos,int) Vege()
        {

            return (j1,pontok[j1],j2,pontok[j2]);
        }

    }
}
