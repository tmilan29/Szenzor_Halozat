//Alaposztály a mért adatok tárolására

namespace Traffic
{
    public class Traffic
    {
        public delegate void EvenetHandlerDelegate(string text);
        public event EvenetHandlerDelegate EventHandlerForChange;

        public int id {  get; set; }
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
                address = value;      //az esemény akkor következik be, amikor 
                EventHandler(); //a szam mező értéket kap 
            }
        }//Szam tulajdonság

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
    }
}
