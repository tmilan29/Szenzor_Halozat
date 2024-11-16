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
        static List<Traffic.Traffic> Import()
        {
            StreamReader input = new StreamReader("traffic.txt");
            StringBuilder rows = new StringBuilder();
            
            while (!input.EndOfStream)
            {
                rows.Append(input.ReadLine());
            }
            
            input.Close();
            List<Traffic.Traffic> traffics = JsonConvert.DeserializeObject<List<Traffic.Traffic>>(rows.ToString());
            
            return traffics;
        }
        static void Main(string[] args)
        {
            List<Traffic.Traffic> traffics = Import();

            Console.WriteLine("A beolvasott adatok:");
            foreach (var t in traffics)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
}
