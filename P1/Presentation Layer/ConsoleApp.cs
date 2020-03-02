using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    public class ConsoleApp
    {
        private bool isStarted = false;

        public ConsoleApp()
        {
            if (isStarted)
            {
                throw new Exception("Programa jau paleista");
            }
            isStarted = true;
        }

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
                    case 2: /* Kitas meniu;  */ break;
                    case 5: PrekiuKatalogas(); break;
                    default:
                        break;
                }
                // Jei 9 baigiame meniu cikla
            } while (pasirinkimas != 9);
        }

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

        private void NaujosPrekesIvedimas()
        {
            Console.WriteLine("Iveskite prekes duomenis");
            Console.WriteLine("Iveskite Pavadima");
            var pavadinimas = Console.ReadLine();

            var naujaPreke = new Preke()
            {
                Pavadinimas = pavadinimas
            };

            PrekiuOperacijos.NaujaPreke(naujaPreke);
        }

        private void PrekiuKatalogas()
        {
            Console.WriteLine("-------Prekiu Katalogas----------");
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

        private void PrekesPirkimas()
        {
            Console.WriteLine("Iveskite prekes duomenis");
            Console.WriteLine("Iveskite pavadinima");
            var pavadinimas = Console.ReadLine();

            var naujaPreke = new Preke();


        }
    }
}
