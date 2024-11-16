namespace Traffic
{
    public class Traffic
    {
        public int id { get; set; }
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

        public string ToString()
        {
            string text = string.Empty;
            text = $"{id};{address};{day};{novehicles};{avgspeed};{roadblock}";

            return text;
        }
    }
}
