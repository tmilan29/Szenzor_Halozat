//Milán - Alaposztály a mért adatok tárolására(DLL)

namespace Traffic
{
    public class Traffic
    {
        //Delegált és hozzá tartozó esemény
        public delegate void EvenetHandlerDelegate(string text);
        public event EvenetHandlerDelegate EventHandlerForChange;

        public int id { get; set; }
        public string address { get; set; }
        public string day { get; set; }
        public int novehicles { get; set; }
        public double avgspeed { get; set; }
        public bool roadblock { get; set; }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;      //Az esemény akkor következik be, amikor az address tulajdonság értéke megváltozi
                EventHandler();
            }
        }

        public Traffic(int Id, string Address, string Day, int Novehicles, double Avgspeed, bool Roadblock)
        {
            this.id = Id;
            this.address = Address;
            this.day = Day;
            this.novehicles = Novehicles;
            this.avgspeed = Avgspeed;
            this.roadblock = Roadblock;
        }

        private void EventHandler()
        {
            if (EventHandlerForChange != null)
            {
                EventHandlerForChange("Cím javítva!");
            }
        }

        //ToString felüldefiniálás a későbbi kiiratásért
        public string ToString()
        {
            string text = string.Empty;
            text = $"{id};{address};{day};{novehicles};{avgspeed};{roadblock}";

            return text;
        }

        public static void Sorbarendezes(List<Traffic> list)
        {
            Console.WriteLine("LINQ: növekvő sorbarendezés az autók száma szerint");
            var Result = from x in list
                         orderby x.novehicles descending
                         select new
                         {
                             Address = x.address,
                             NoOfVeh = x.novehicles,
                             Day = x.day
                         };

            Console.WriteLine("Cím\t\t\tAutókszáma\tNap");
            foreach (var x in Result)
            {
                Console.WriteLine(x.Address + "\t" + x.NoOfVeh + "\t" + x.Day);
            }
        }
        public static void NagyobbVolt(List<Traffic> list)
        {
            Console.WriteLine("LINQ: pénteken hol volt nagyobb az átlagsebesség, mint 50?");
            var Result = from x in list
                         where x.day == "Péntek" || x.avgspeed > 50
                         select new
                         {
                             Address = x.address,
                             AvgSpeed = x.avgspeed
                         };

            Console.WriteLine("Cím\t\t\t\tSebesség");
            foreach (var x in Result)
            {
                Console.WriteLine(x.Address + "\t" + x.AvgSpeed);
            }
        }
        public static void UtzarVolt(List<Traffic> list)
        {
            Console.WriteLine("LINQ: a mérés ideje alatt volt-e útzár? Ha igen, akkor hány autó szorult be?");
            var Result = from x in list
                         where x.roadblock is true
                         select x.novehicles;
            if(Result.Count() > 0)
            {
                Console.WriteLine("Volt útzár.");
                foreach (var x in Result)
                {
                    Console.WriteLine(x);
                }
            }
            else { Console.WriteLine("Nem volt útzár."); }
        }
    }
}
