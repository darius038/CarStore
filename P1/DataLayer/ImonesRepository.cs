using System;
using System.Collections.Generic;

namespace CarStore
{
    class ImonesRepository
    {
        private static List<Imone> _imones = new List<Imone>()
            {
            //Listo uzpildymas
            new Imone
            {
                Pavadinimas = "UAB Apuoko lizdas",
                ImonesKodas = 123456
            },
            new Imone
             {
                Pavadinimas = "UAB Baltas namas",
                ImonesKodas = 987456
            }
        };


        public static void IvestiImone(Imone imone)
        {
            if (_imones.Exists(x => x.ImonesKodas == imone.ImonesKodas))
            {
                throw new Exception("Imone su tokiu kodu jau egzistuoja");
            }

            _imones.Add(imone);
        }

        //Imones paieska pagal koda
        public static Imone IeskotiImone(int kodas)
        {
            Imone tmpImone;

            if (!_imones.Exists(x => x.ImonesKodas == kodas))
            {
                throw new Exception("Tokios imones nera sarase");
            }
            else
            {
                tmpImone = _imones.Find(x => x.ImonesKodas == kodas);
            }
            return tmpImone;
        }

        //Imoniu sarasas
        public static List<Imone> GetImoniuKatalogas()
        {
            return _imones;
        }
    }
}
