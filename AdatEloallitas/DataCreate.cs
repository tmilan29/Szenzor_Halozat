using System;
using System.IO;
using System.Collections.Generic;
using Traffic;
using Newtonsoft.Json;
using System.Xml;

namespace Adateloallitas
{
    internal class DataCreate
    {
        static List<Traffic.Traffic> traffics()
        {
            List<Traffic.Traffic> outputs = new List<Traffic.Traffic>();
            List<string> days = new List<string>() { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek" };
            Random r = new Random();

            foreach (string day in days)
            {
                for (int i = 0; i < 4; i++)
                {
                    int id = i + 1;
                    switch (id)
                    {
                        case 1:
                            string address = "Holland fasor 2, Tesco";
                            int novehicles = r.Next(20, 51);
                            double avgspeed = 0;
                            if (novehicles > 35)
                            {
                                avgspeed = 5 + (r.NextDouble() * (20 - 5));
                            }
                            else
                            {
                                avgspeed = 21 + (r.NextDouble() * (36 - 21));
                            }
                            int rb_chance = r.Next(1, 11);
                            bool roadblock = false;
                            if (rb_chance == 1)
                            {
                                roadblock = true;
                            }
                            else { roadblock = false; }
                            outputs.Add(new Traffic.Traffic(id, address, day, novehicles, Math.Round(avgspeed, 2), roadblock));
                            break;

                        case 2:
                            address = "Balatoni út 44-46, Praktiker";
                            novehicles = r.Next(5, 41);
                            avgspeed = 0;
                            if (novehicles > 30)
                            {
                                avgspeed = 15 + (r.NextDouble() * (30 - 15));
                            }
                            else
                            {
                                avgspeed = 31 + (r.NextDouble() * (56 - 31));
                            }
                            rb_chance = r.Next(1, 21);
                            roadblock = false;
                            if (rb_chance == 1)
                            {
                                roadblock = true;
                            }
                            else { roadblock = false; }
                            outputs.Add(new Traffic.Traffic(id, address, day, novehicles, Math.Round(avgspeed, 2), roadblock));
                            break;

                        case 3:
                            address = "Palotai út 1, Alba Pláza";
                            novehicles = r.Next(15, 50);
                            avgspeed = 0;
                            if (novehicles > 45)
                            {
                                avgspeed = 30 + (r.NextDouble() * (40 - 30));
                            }
                            else
                            {
                                avgspeed = 41 + (r.NextDouble() * (60 - 41));
                            }
                            rb_chance = r.Next(1, 51);
                            roadblock = false;
                            if (rb_chance == 1)
                            {
                                roadblock = true;
                            }
                            else { roadblock = false; }
                            outputs.Add(new Traffic.Traffic(id, address, day, novehicles, Math.Round(avgspeed, 2), roadblock));
                            break;

                        case 4:
                            address = "Budai út 43, Óbudai Egyetem";
                            novehicles = r.Next(15, 50);
                            avgspeed = 0;
                            if (novehicles > 45)
                            {
                                avgspeed = 30 + (r.NextDouble() * (40 - 30));
                            }
                            else
                            {
                                avgspeed = 41 + (r.NextDouble() * (60 - 41));
                            }
                            rb_chance = r.Next(1, 51);
                            roadblock = false;
                            if (rb_chance == 1)
                            {
                                roadblock = true;
                            }
                            else { roadblock = false; }
                            outputs.Add(new Traffic.Traffic(id, address, day, novehicles, Math.Round(avgspeed, 2), roadblock));
                            break;

                        default:
                            Console.WriteLine("ID not found");
                            break;
                    }
                }
            }
            return outputs;
        }

        static void Main(string[] args)
        {
            try
            {
                string json = JsonConvert.SerializeObject(traffics(), Newtonsoft.Json.Formatting.Indented);
                FileStream fsjson = new FileStream("C:\\Users\\Milan\\Downloads\\Forgalom_Szenzor\\AdatFeldolgozas\\bin\\Debug\\net8.0\\traffic.json", FileMode.Create, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fsjson);
                sw.WriteLine(json);
                sw.Flush();
                sw.Close();
                Console.WriteLine("Adatok sikeresen exportálva!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}