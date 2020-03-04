using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    public class Preke
    {
        public string Pavadinimas { get; set; }        
        public int PirkimoKaina { get; set; }
        public int PardavimoKaina { get; set; }
        public int Likutis { get; set; }
        public PrekesTipasEnum PrekesTipas { get; set; }
        public int pirkejoImonesKodas { get; set; }
        public string UnikalusNumeris { get; set; }
    }
}
