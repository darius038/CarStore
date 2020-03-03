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
                Likutis = 10,
                PrekesTipas = PrekesTipasEnum.Maisto_Prekes,
                imonePirkejas = new Imone() {Pavadinimas= "UAB Ankora", ImonesKodas = 123456}
            },
            new Preke
            {
                Pavadinimas = "Valiklis",
                UnikalusNumeris = Guid.NewGuid(),
                PirkimoKaina = 4,
                PardavimoKaina = 0,
                Likutis = 1,
                PrekesTipas = PrekesTipasEnum.Buitines_Prekes,
                imonePirkejas = new Imone() {Pavadinimas= "UAB Baltas miskas", ImonesKodas = 456789}
            },
            new Preke
            {
                Pavadinimas = "Stalas",
                UnikalusNumeris = Guid.NewGuid(),
                PirkimoKaina = 123,
                PardavimoKaina = 0,
                Likutis = 7,
                PrekesTipas = PrekesTipasEnum.Kitos_Prekes,
                imonePirkejas = new Imone() {Pavadinimas= "UAB Zalia zole", ImonesKodas = 425587}
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

        //Prekes pardavimas - likucio sumazinimas ir pirkejo ivedimas
        public static void ParduotiPreke(string pavadinimas, int kiekis, int kaina, int pirkejoKodas)
        {
            if (!_prekes.Exists(x => x.Pavadinimas.Equals(pavadinimas)))
            {
                throw new Exception("Tokios prekes nera sarase");
            }
            else if (_prekes.Find(x => x.Pavadinimas == pavadinimas).Likutis >= kiekis)
            {
                var pirkejas = ImonesRepository.IeskotiImone(pirkejoKodas);

                if (pirkejas == null)
                {
                    Console.WriteLine("Tokio pirkejo nera kataloge, iveskite pirkeja!");
                    return;
                }
                else
                {
                    _prekes.Find(x => x.Pavadinimas == pavadinimas).Likutis -= kiekis;
                    _prekes.Find(x => x.Pavadinimas == pavadinimas).PardavimoKaina = kaina;
                    _prekes.Find(x => x.Pavadinimas == pavadinimas).imonePirkejas = pirkejas;
                }
            }
            else
            {
                throw new Exception("Prekes likutis nepakankamas!");
            }             
        }

        //Prekes paieska
        public static Preke IeskotiPreke(string pavadinimas)
        {
            Preke rastaPreke;

            if (!_prekes.Exists(x => x.Pavadinimas.Equals(pavadinimas)))
            {
                throw new Exception("Tokios prekes nera sarase");
            }
            else
            {
                rastaPreke = _prekes.Find(x => x.Pavadinimas == pavadinimas);
            }
            return rastaPreke;
        }

        public static List<Preke> GetPrekesKatalogas()
        {
            return _prekes;
        }

    }
}
