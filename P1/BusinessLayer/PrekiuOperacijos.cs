using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    static class PrekiuOperacijos
    {        
        public static void NaujaPreke(Preke naujaPreke)
        {
            //issaugome nauja preke duomenu bazeje
            naujaPreke.UnikalusNumeris = Guid.NewGuid();
            naujaPreke.imonePirkejas = new Imone();
            PrekesRepository.IdetiNauja(naujaPreke);
        }

        public static void PrekesPirkimas(String pavadinimas, int kiekis, int kaina)
        {
            //pakeiciamas perkamos prekes likutis duomenu bazeje
            PrekesRepository.PirktiPreke(pavadinimas, kiekis, kaina);
        }

        public static void PrekesPardavimas(string pavadinimas, int kiekis, int kaina, int pirkejoKodas)
        {
            //pakeiciamas parduodamos prekes likutis duomenu bazeje
            PrekesRepository.ParduotiPreke(pavadinimas, kiekis, kaina, pirkejoKodas);
        }        

        public static List<Preke> PrekiuKatalogas()
        {
            //pasiimame is DB
            return PrekesRepository.GetPrekesKatalogas();
        }

        public static Preke PrekiuPaieska(string pavadinimas)
        {
            //pasiimame is DB
            return PrekesRepository.IeskotiPreke(pavadinimas);
        }       
    }
}
