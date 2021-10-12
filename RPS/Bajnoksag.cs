using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    class Bajnoksag
    {
        private Dictionary<Jatekos, int> pontszamok = new();
        private List<Jatekos> resztvevok = new();
        public Bajnoksag(int szam)
        {
            for (int i = 0; i < szam; i++)
            {
                Jatekos jatekos = new Jatekos(i, "Ember" + i.ToString());
                resztvevok.Add(jatekos);
                pontszamok.Add(jatekos, 0);
            }
            PontszamokKiir();
            BajnoksagKezdete();

        }
        private void BajnoksagKezdete()
        {
            Random rnd = new Random();
            Jatekos j2;
            while (resztvevok.Count != 1)
            {
                for(int i = 0; i < resztvevok.Count; i++)
                {
                    do
                    {
                        j2 = resztvevok[rnd.Next(0, resztvevok.Count)];
                    } while (j2 == resztvevok[i]);
                    Merkozes merkozes = new Merkozes(resztvevok[i], j2);
                    var eredmeny = merkozes.Vege();
                    pontszamok[eredmeny.Item1] += eredmeny.Item2;
                    pontszamok[eredmeny.Item3] += eredmeny.Item4;
                }
                PontszamokKiir();
                Kiesett();
                KovKor();
            }
            Console.WriteLine($"{resztvevok.First().Id} a győztes!");
        }
        private void Kiesett()
        {
            var kiesett = pontszamok.OrderBy(x => x.Value).First();
            resztvevok.Remove(kiesett.Key);
            pontszamok.Remove(kiesett.Key);
            Console.WriteLine($"{kiesett.Key.Id} kiesett!");
        }
        private void KovKor()
        {

            foreach (Jatekos jatekos in resztvevok)
            {
                jatekos.jatszottE = false;
            }
        }

        private void PontszamokKiir()
        {
            Console.WriteLine("---------------");
            foreach (KeyValuePair<Jatekos, int> val in pontszamok.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"Vegso: {val.Key.Id} ----- pont: {val.Value}");
            }
            Console.WriteLine("---------------");
        }
    }
}
