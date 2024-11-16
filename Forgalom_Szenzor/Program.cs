using System;
using System.IO;
using System.Collections.Generic;

namespace Adateloallitas
{
    class Traffic
    {
        public int id {  get; set; }
        public string address { get; set; }
        public string day { get; set; }
        public int novehicles { get; set; }
        public double avgspeed { get; set; }
        public bool roadblock { get; set; }

        public Traffic(int Id, string Address, string Day, int Novehicles, double Avgspeed, bool Roadblock)
        {
            this.id = Id;
            this.address = Address;
            this.day = Day;
            this.novehicles = Novehicles;
            this.avgspeed = Avgspeed;
            this.roadblock = Roadblock;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Traffic> outputs = new List<Traffic>();
            List<string> days = new List<string>() { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek"};

            Random r = new Random();

            foreach (string day in days)
            {
                for (int i = 0; i < 4; i++)
                {
                    int id = i+1;
                    switch (id) 
                    {
                        case 1:
                            string address = "Holland fasor 2, Auchan";
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
                            else {roadblock = false;}
                            outputs.Add(new Traffic(id, address, day, novehicles, avgspeed, roadblock));
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
                            outputs.Add(new Traffic(id, address, day, novehicles, avgspeed, roadblock));
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
                            outputs.Add(new Traffic(id, address, day, novehicles, avgspeed, roadblock));
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
                            outputs.Add(new Traffic(id, address, day, novehicles, avgspeed, roadblock));
                            break;

                        default: Console.WriteLine("ID not found");
                            break;
                    }
                }
            }

            



        }
    }
}
