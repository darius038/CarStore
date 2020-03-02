using System;
using System.Collections.Generic;

namespace CarStore
{
    static class PrekesRepository
    {
        private static List<Preke> _prekes = new List<Preke>
        {
            //Listo uzpildymas
            new Preke
            {
                Pavadinimas = "Juoda duona",
                UnikalusNumeris = Guid.NewGuid(),
                PirkimoKaina = 2,
                PardavimoKaina = 0,
                PrekesTipas = PrekesTipasEnum.Maisto_Prekes
            },
            new Preke
            {
                Pavadinimas = "Valiklis",
                UnikalusNumeris = Guid.NewGuid(),
                PirkimoKaina = 4,
                PardavimoKaina = 0,
                PrekesTipas = PrekesTipasEnum.Buitines_Prekes
            },
            new Preke
            {
                Pavadinimas = "Stalas",
                UnikalusNumeris = Guid.NewGuid(),
                PirkimoKaina = 123,
                PardavimoKaina = 0,
                PrekesTipas = PrekesTipasEnum.Kitos_Prekes
            }
        };

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
        public static void PirktiPreke(string pavadinimas, int kiekis, int kaina)
        {
            if (!_prekes.Exists(x => x.Pavadinimas.Equals(pavadinimas)))
            {
                throw new Exception("Tokios prekes nera sarase");
            }
            _prekes.Find(x => x.Pavadinimas == pavadinimas).Likutis += kiekis;
            _prekes.Find(x => x.Pavadinimas == pavadinimas).PirkimoKaina = kaina;
        }

        //Prekes pardavimas - likucio sumazinimas
        public static void ParduotiPreke(string pavadinimas, int kiekis, int kaina)
        {
            if (!_prekes.Exists(x => x.Pavadinimas.Equals(pavadinimas)))
            {
                throw new Exception("Tokios prekes nera sarase");
            }
            else if (_prekes.Find(x => x.Pavadinimas == pavadinimas).Likutis >= kiekis)
            {
                _prekes.Find(x => x.Pavadinimas == pavadinimas).Likutis -= kiekis;
                _prekes.Find(x => x.Pavadinimas == pavadinimas).PardavimoKaina = kaina;
            }
            throw new Exception("Prekes likutis nepakankamas!");
        }

        //Prekes paieska
        public static List<Preke> IeskotiPreke(string pavadinimas)
        {
            List<Preke> rastosPrekes;

            if (!_prekes.Exists(x => x.Pavadinimas.Equals(pavadinimas)))
            {
                throw new Exception("Tokios prekes nera sarase");
            }
            else
            {
                rastosPrekes = _prekes.FindAll(x => x.Pavadinimas == pavadinimas);
            }
            return rastosPrekes;
        }

        public static List<Preke> GetPrekesKatalogas()
        {
            return _prekes;
        }

    }
}
