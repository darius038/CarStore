using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    static class PrekesRepository
    {
        private static List<Preke> _prekes = new List<Preke>();         

        //Naujos prekes idejimas
        public static void IdetiNauja(Preke preke)
        {
            if (_prekes.Exists(x => x.UnikalusNumeris == preke.UnikalusNumeris))
            {
                throw new Exception("Tokia preke siuo numeriu jau egzistuoja");
            }

            _prekes.Add(preke);
        }

        //Prekes pirkimas - likucio padidinimas
        public static void PirktiPreke(Preke preke, int kiekis)
        {
            if (_prekes.Exists(x => x.UnikalusNumeris != preke.UnikalusNumeris))
            {
                throw new Exception("Tokios prekes nera sarase, iveskite nauja preke");
            }
           var tmpPreke = _prekes.Find(x => x.UnikalusNumeris == preke.UnikalusNumeris).Likutis += kiekis;
        }

        //Prekes pardavimas - likucio sumazinimas
        public static void ParduotiPreke(Preke preke, int kiekis)
        {
            
            if (_prekes.Exists(x => x.UnikalusNumeris != preke.UnikalusNumeris))
            {
                throw new Exception("Tokios prekes nera sarase!");
            } else if (_prekes.Find(x => x.UnikalusNumeris == preke.UnikalusNumeris).Likutis>=kiekis)
            {
                var tmpPreke = _prekes.Find(x => x.UnikalusNumeris == preke.UnikalusNumeris).Likutis += kiekis;
            }
                throw new Exception("Prekes likutis nepakankamas!");
        }
        
        public static List<Preke> GetPrekesKatalogas()
        {
            return _prekes;
        }

    }
}
