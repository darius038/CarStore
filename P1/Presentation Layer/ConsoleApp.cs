using System;
using System.Collections.Generic;
using System.Text;

namespace P1
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
            //Parodomas pagrindinis meniu
            var pasirinkimas = MainMenu();
            //Paleidziama atitinkama meniu pasirinkima
            //Griztama atgal i meniu
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
                Console.WriteLine("9 - Isejimas is programos");

                vartotojoIvestis = Console.ReadLine();

            } while (!int.TryParse(vartotojoIvestis, out pasirinkimas));

            return pasirinkimas;
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
