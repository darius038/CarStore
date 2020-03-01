using System;
using System.Collections.Generic;
using System.Text;

namespace P1
{
    static class PrekesRepository
    {
        private static List<Preke> _prekes = new List<Preke>();

        
        public static void IdetiNauja(Preke preke)
        {
            if (_prekes.Exists(x => x.UnikalusNumeris == preke.UnikalusNumeris) {
                throw new Exception ("Tokia preke siuo numeriu jau egzistuoja"):
            }

            _prekes.Add(preke);
        }
    }
}
