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
            PrekesRepository.IdetiNauja(naujaPreke);

        }

        public static void PrekesPirkimas(Preke preke, int kiekis)
        {
            //pakeiciamas prekes likutis duomenu bazeje
            PrekesRepository.PirktiPreke(preke, kiekis);

        }

        public static void PrekesPardavimas(Preke preke, int kiekis)
        {
            //pakeiciamas prekes likutis duomenu bazeje
            PrekesRepository.ParduotiPreke(preke, kiekis);

        }        

        public static List<Preke> PrekiuKatalogas()
        {
            //pasiimame is DB
            return PrekesRepository.GetPrekesKatalogas();
        }
    }
}
