using System;
using System.Collections.Generic;

namespace CarStore
{
    public static class PrekesRepository
    {

        private static List<Preke> prekes = new List<Preke>();

        private static string _fileName = "prekes.xml";

        private static List<Preke> _prekes
        {
            get
            {
                //Nuskaityti faila ir desiarilizuoti                
                var failoSaugojimoPrietaisas = new SaveToFile();
                try
                {
                    prekes = failoSaugojimoPrietaisas.DeSerializeObject<List<Preke>>(_fileName);
                }
                catch (Exception)
                {
                    //jei failo nera ar klaida sukurit tuscia masyva
                    prekes = new List<Preke>();
                }
                return prekes;
            }
            set
            {
                // serializuoti objekta ir irasyti i faila
                prekes = value;
            }
        }

        //Saugojimo metodas
        private static void Save()
        {
            var failoSaugojimoPrietaisas = new SaveToFile();
            failoSaugojimoPrietaisas.SerializeObject<List<Preke>>(prekes, _fileName);
        }

        //Naujos prekes idejimas
        public static void IdetiNauja(Preke preke)
        {
            if (_prekes.Exists(x => x.UnikalusNumeris.Equals(preke.UnikalusNumeris)))
            {
                throw new Exception("Tokia preke siuo numeriu jau egzistuoja");
            }
            _prekes.Add(preke);
            Save();
        }

        //Prekes pirkimas - likucio padidinimas
        public static void PirktiPreke(string pavadinimas, int kiekis, int kaina)
        {
            if (!_prekes.Exists(x => x.Pavadinimas.Equals(pavadinimas)))
            {
                throw new Exception("Tokios prekes nera sarase");
            }
            else
            {
                //_prekes.Select(x => x.Pavadinimas = pavadinimas).Likutis = kiekis;
                //_prekes.Find(x => x.Pavadinimas.Equals(pavadinimas)).PirkimoKaina = kaina;

                Preke p = _prekes.Find(x => x.Pavadinimas == pavadinimas);
                p.Likutis += kiekis;
                p.PirkimoKaina = kaina;

                Save();
            }

        }

        //Prekes pardavimas - likucio sumazinimas ir pirkejo ivedimas
        public static void ParduotiPreke(string pavadinimas, int kiekis, int kaina, int pirkejoKodas)
        {
            if (!_prekes.Exists(x => x.Pavadinimas.Equals(pavadinimas)))
            {
                throw new Exception("Tokios prekes nera sarase");
            }
            else if (_prekes.Find(x => x.Pavadinimas.Equals(pavadinimas)).Likutis >= kiekis)
            {
                var pirkejas = ImonesRepository.IeskotiImone(pirkejoKodas);

                if (pirkejas == null)
                {
                    Console.WriteLine("Tokio pirkejo nera kataloge, iveskite pirkeja!");
                    return;
                }
                else
                {
                    Preke p = _prekes.Find(x => x.Pavadinimas == pavadinimas);
                    p.Likutis -= kiekis;
                    p.PardavimoKaina = kaina;
                    p.pirkejoImonesKodas = pirkejoKodas;

                    Save();
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

            if (!_prekes.Exists(x => x.Pavadinimas.Contains(pavadinimas)))
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
