using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    class ImonesRepository
    {
        private static List<Imone> _imones = new List<Imone>();


        public static void NaujaImone(Imone imone)
        {
            if (_imones.Exists(x => x.ImonesKodas == imone.ImonesKodas))
            {
                throw new Exception("Imone su tokiu kodu jau egzistuoja");
            }

            _imones.Add(imone);
        }

        public static List<Imone> GetImoniuKatalogas()
        {
            return _imones;
        }
    }
}
