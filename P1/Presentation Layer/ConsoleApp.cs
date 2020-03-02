using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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

        //Interfeiso paleidimas
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
                Console.WriteLine("1 - Naujos prekes ivedimas");
                Console.WriteLine("2 - Prekes pirkimas");
                Console.WriteLine("3 - Prekes pardavimas");
                Console.WriteLine("4 - Prekes paieska");
                Console.WriteLine("5 - Prekiu katalogas");
                Console.WriteLine("6 - Sandelio likutis");
                Console.WriteLine("9 - Isejimas is programos");

                vartotojoIvestis = Console.ReadLine();

            } while (!int.TryParse(vartotojoIvestis, out pasirinkimas));

            return pasirinkimas;
        }

        //***1 - Naujos prekes ivedimas
        private void NaujosPrekesIvedimas()
        {
            Console.WriteLine("Iveskite prekes duomenis");

            //Pavadinimas
            Console.WriteLine("Prekes pavadinimas:");
            var pavadinimas = Console.ReadLine();

            //Pirkimo kaina
            Console.WriteLine("Pirkimo kaina:");
            int kainaPirkimo = int.Parse(Console.ReadLine());

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
                PirkimoKaina = kainaPirkimo,
                PrekesTipas = (PrekesTipasEnum)tipas
            };

            //Naujos prekes itraukimas i sarasa
            PrekiuOperacijos.NaujaPreke(naujaPreke);
        }

        //***2 - prekes pirkimas, t.y. esamos prekes likucio padidinimas
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

        //***3 - prekes pardavimas, t.y. esamos prekes likucio padidinimas
        private void PrekesPardavimas()
        {
            Console.WriteLine("Iveskite parduodamos prekes duomenis");
            Console.WriteLine("Iveskite pavadinima: ");
            var pavadinimas = Console.ReadLine();

            Console.WriteLine("Iveskite pardavimo kaina");
            int pardavimoKaina = int.Parse(Console.ReadLine());

            Console.WriteLine("Iveskite parduodama kieki");
            int parduodamasKiekis = int.Parse(Console.ReadLine());

            PrekiuOperacijos.PrekesPardavimas(pavadinimas, parduodamasKiekis, pardavimoKaina);
        }

        //***4 - prekes paieska
        private void PrekiuPaieska()
        {
            Console.WriteLine("-------Prekes paieska pagal pavadinima-------");
            Console.WriteLine("Iveskite prekes pavadinima: ");
            var pavadinimas = Console.ReadLine();

            try
            {
                List<Preke> rastosPrekes = PrekiuOperacijos.PrekiuPaieska(pavadinimas);

                Console.WriteLine("Rastos prekes: ");
                foreach (var preke in rastosPrekes)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        //***5 - prekiu katalogas
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

    }
}
