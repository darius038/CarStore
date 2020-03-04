using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    public class Imone
    {
        public string Pavadinimas { get; set; }
        public int ImonesKodas { get; set; }

        public override string ToString()
        {
            return Pavadinimas + " kodas: " + ImonesKodas;
        }
    }

    
}
