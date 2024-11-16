using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Traffic;
using Newtonsoft.Json;

namespace AdatFeldolgozas
{
    internal class Program
    {
        static void Event(string text)
        {
            Console.WriteLine(text);
        }

        static List<Traffic.Traffic> Import()
        {
            StreamReader json = new StreamReader("traffic.json");
            string string_json = json.ReadToEnd();
            json.Close();

            List<Traffic.Traffic> traffics = JsonConvert.DeserializeObject<List<Traffic.Traffic>>(string_json.ToString());

            return traffics;
        }
        static void Main(string[] args)
        {
            List<Traffic.Traffic> traffics = Import();

            try
            {
                Console.WriteLine("Az adatok beolvasása elkezdődött!\n");
                //Az 1. ID-jú szenzor esetén a cím rosszul lett rögzítve a beolvasás során. Ezt javítjuk, melyet eseménykezelés kisér.
                foreach (var t in traffics)
                {
                    Console.WriteLine(t.ToString());
                    if (t.id == 1)
                    {
                        t.EventHandlerForChange += Event;
                        t.Address = "Holland fasor 2, Auchan";

                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\nTovábbhaladáshoz nyomj le egy karaktert!");
            Console.ReadKey();
            Console.Clear();
            

            Console.WriteLine("A beolvasott adatok:");
            foreach (var t in traffics)
            {
                Console.WriteLine(t.ToString());
            }


        }
    }
}
