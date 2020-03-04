using System;
using System.Collections.Generic;

namespace CarStore
{
    public class ImonesRepository
    {
        private static string _fileName = "imones.xml";

        private static List<Imone> imones = new List<Imone>();

        private static List<Imone> _imones
        {
            get
            {
                //Nuskaityti faila ir desiarilizuoti                
                var failoSaugojimoPrietaisas = new SaveToFile();
                try
                {
                    imones = failoSaugojimoPrietaisas.DeSerializeObject<List<Imone>>(_fileName);
                }
                catch (Exception)
                {
                    //jei failo nera ar klaida sukurit tuscia masyva
                    imones = new List<Imone>();
                }
                return imones;
            }
            set
            {
                // serializuoti objekta ir irasyti i faila
                imones = value;
            }
        }

        //Saugojimo metodas
        private static void Save()
        {
            var failoSaugojimoPrietaisas = new SaveToFile();
            failoSaugojimoPrietaisas.SerializeObject<List<Imone>>(imones, _fileName);
        }

        //Naujos imones ivedimas i kataloga
        public static void IvestiImone(Imone imone)
        {
            if (_imones.Exists(x => x.ImonesKodas == imone.ImonesKodas))
            {
                throw new Exception("Imone su tokiu kodu jau egzistuoja");
            }

            _imones.Add(imone);
            Save();
           
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
