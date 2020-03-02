using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    static class ImonesOperacijos
    {
        public static void NaujaImone(Imone naujaImone)
        {
            //issaugoma nauja imone duomenu bazeje           
            ImonesRepository.IvestiImone(naujaImone);
        }        

        public static List<Imone> ImoniuKatalogas()
        {
            //pasiimame sarasa is DB
            return ImonesRepository.GetImoniuKatalogas();
        }

        public static Imone ImoniuPaieska(int kodas)
        {
            //pasiimame Imone is DB
            return ImonesRepository.IeskotiImone(kodas);
        }
    }
}
