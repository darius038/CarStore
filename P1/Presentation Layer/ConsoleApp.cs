using System;
using System.Reflection;

namespace CarStore
{
    public class ConsoleApp
    {
        private bool isStarted = false;

        //Konstruktorius
        public ConsoleApp()
        {
            if (isStarted)
            {
                throw new Exception("Programa jau paleista");
            }
            isStarted = true;
        }

        //UI paleidimas
        public void Start()
        {
            int pasirinkimas;
            do
            {
                //Pateikiam vartotojui pagrindinis meniu
                pasirinkimas = MainMenu();

                //paleidciam atitinkama meniu pasirinkima
                switch (pasirinkimas)
                {
                    case 1: NaujosPrekesIvedimas(); break;
                    case 2: PrekesPirkimas(); break;
                    case 3: PrekesPardavimas(); break;
                    case 4: PrekiuPaieska(); break;
                    case 5: PrekiuKatalogas(); break;
                    case 6: PrekesPirkimas(); break;
                    case 7: ImonesIvedimas(); break;
                    case 8: ImonesPaieska(); break;
                    default:
                        break;
                }
                // Jei 9 baigiame meniu cikla
            } while (pasirinkimas != 9);
        }

        //Pagrindinis programos meniu
        private int MainMenu()
        {
            string vartotojoIvestis = "";
            int pasirinkimas;

            do
            {
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Console.WriteLine("1 - Naujos prekes ivedimas");
                Console.WriteLine("2 - Prekes pirkimas");
                Console.WriteLine("3 - Prekes pardavimas");
                Console.WriteLine("4 - Prekes paieska");
                Console.WriteLine("5 - Prekiu katalogas");
                Console.WriteLine("6 - Sandelio likutis");
                Console.WriteLine("7 - Imones / Pirkejo ivedimas");
                Console.WriteLine("8 - Imones / Pirkejo paieska");
                Console.WriteLine("9 - Isejimas is programos");
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                vartotojoIvestis = Console.ReadLine();

            } while (!int.TryParse(vartotojoIvestis, out pasirinkimas));

            return pasirinkimas;
        }

        //********** 1 - Naujos prekes ivedimas
        private void NaujosPrekesIvedimas()
        {
            Console.WriteLine("Iveskite prekes duomenis");

            //Pavadinimas
            Console.WriteLine("Prekes pavadinimas:");
            var pavadinimas = Console.ReadLine();

            //Prekes tipas pagal enum  
            int tipas;
            do
            {
                Console.WriteLine("Prekes tipas (iveskite numeri):");
                foreach (PrekesTipasEnum t in Enum.GetValues(typeof(PrekesTipasEnum)))
                {
                    Console.WriteLine((int)t + " " + t.ToString());
                }
                tipas = int.Parse(Console.ReadLine());

            } while (!typeof(PrekesTipasEnum).IsEnumDefined(tipas));

            //Naujos prekes suformavimas
            var naujaPreke = new Preke()
            {
                Pavadinimas = pavadinimas,
                PrekesTipas = (PrekesTipasEnum)tipas
            };

            //Naujos prekes itraukimas i sarasa
            PrekiuOperacijos.NaujaPreke(naujaPreke);
        }

        //********** 2 - prekes pirkimas, t.y. esamos prekes likucio padidinimas
        private void PrekesPirkimas()
        {
            Console.WriteLine("Iveskite perkamos prekes duomenis");
            Console.WriteLine("Iveskite pavadinima: ");
            var pavadinimas = Console.ReadLine();

            Console.WriteLine("Iveskite pirkimo kaina");
            int pirkimoKaina = int.Parse(Console.ReadLine());

            Console.WriteLine("Iveskite perkama kieki");
            int perkamasKiekis = int.Parse(Console.ReadLine());

            PrekiuOperacijos.PrekesPirkimas(pavadinimas, perkamasKiekis, pirkimoKaina);
        }

        //********** 3 - prekes pardavimas, likucio sumazinimas ir pirkejo ivedimas
        private void PrekesPardavimas()
        {
            Console.WriteLine("Iveskite parduodamos prekes duomenis");
            Console.WriteLine("Iveskite pavadinima:");
            var pavadinimas = Console.ReadLine();

            Console.WriteLine("Iveskite pardavimo kaina:");
            int pardavimoKaina = int.Parse(Console.ReadLine());

            Console.WriteLine("Iveskite parduodama kieki:");
            int parduodamasKiekis = int.Parse(Console.ReadLine());

            Console.WriteLine("Iveskite pirkejo/imones koda;");
            int pirkejoKodas = int.Parse(Console.ReadLine());

            try
            {
                PrekiuOperacijos.PrekesPardavimas(pavadinimas, parduodamasKiekis, pardavimoKaina, pirkejoKodas);
                Console.WriteLine("Pardavimo operacija sekmingai ivesta");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //********** 4 - prekes paieska
        private void PrekiuPaieska()
        {
            Console.WriteLine("-------Prekes paieska pagal pavadinima-------");
            Console.WriteLine("Iveskite prekes pavadinima: ");
            var pavadinimas = Console.ReadLine();

            try
            {
                Preke preke = PrekiuOperacijos.PrekiuPaieska(pavadinimas);

                Console.WriteLine("Rasta preke: ");

                var pType = preke.GetType();
                var props = pType.GetProperties();
                foreach (PropertyInfo prp in props)
                {
                    string propertyName = prp.Name;
                    string propertyValue = prp.GetValue(preke, new object[] { }).ToString();
                    Console.Write(propertyName + ": " + propertyValue + ";  ");
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        //********** 5 - prekiu katalogas
        private void PrekiuKatalogas()
        {
            Console.WriteLine("-------Prekiu Katalogas-------");
            foreach (var preke in PrekiuOperacijos.PrekiuKatalogas())
            {

                var pType = preke.GetType();
                var props = pType.GetProperties();
                foreach (PropertyInfo prp in props)
                {
                    string propertyName = prp.Name;
                    string propertyValue = prp.GetValue(preke, new object[] { }).ToString();
                    Console.Write(propertyName + ": " + propertyValue + ";  ");
                }
                Console.WriteLine();
            }
        }

        //********** 6 - naujos imones ivedimas
        private void ImonesIvedimas()
        {
            Console.WriteLine("-------Naujos Imones ivedimas i kataloga-------");
            Console.WriteLine("Imones pavadinimas: ");
            string pavadinimas = Console.ReadLine();
            Console.WriteLine("Imones kodas: ");
            int kodas = int.Parse(Console.ReadLine());

            //Naujos imones sukurimas
            var naujaImone = new Imone()
            {
                Pavadinimas = pavadinimas,
                ImonesKodas = kodas
            };

            //Naujos imones itraukimas i kataloga
            ImonesOperacijos.NaujaImone(naujaImone);

        }
        //********** 7 - imones paieska pagal koda
        private void ImonesPaieska()
        {
            Console.WriteLine("-------Imones paieska pagal koda-------");
            Console.WriteLine("Iveskite imones koda: ");
            int kodas = int.Parse(Console.ReadLine());

            try
            {
                Imone rastaImone = ImonesOperacijos.ImoniuPaieska(kodas);
                Console.WriteLine("Rasta imone: ");
                Console.WriteLine(rastaImone.Pavadinimas + ", imones kodas: " + rastaImone.ImonesKodas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

    }
}
