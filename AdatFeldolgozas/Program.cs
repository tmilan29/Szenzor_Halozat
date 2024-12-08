using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Traffic;
using Newtonsoft.Json;
using Microsoft.Data.Sqlite;

namespace AdatFeldolgozas
{
    internal class Program
    {
        //Milán - adatok beolvasása, JSON deszerializálás
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

            //Gergő - LINQ
            Console.WriteLine("\nTovábbhaladáshoz nyomj le egy karaktert!");
            Console.ReadKey();
            Console.Clear();

            Traffic.Traffic.Sorbarendezes(traffics);
            Console.WriteLine("\nTovábbhaladáshoz nyomj le egy karaktert!");
            Console.ReadKey();
            Console.Clear();

            Traffic.Traffic.NagyobbVolt(traffics);
            Console.WriteLine("\nTovábbhaladáshoz nyomj le egy karaktert!");
            Console.ReadKey();
            Console.Clear();

            Traffic.Traffic.UtzarVolt(traffics);
            Console.WriteLine("\nTovábbhaladáshoz nyomj le egy karaktert!");
            Console.ReadKey();
            Console.Clear();

            //Gergő és Milán közös - SQLite DB
            try
            {
                var connection = new SqliteConnection("Data Source=traffic.db");
                connection.Open();
                Console.WriteLine("Adatbázishoz sikeresen kapcsolódva.");

                var dropTable = @"DROP TABLE traffic";
                using var tableDrop = new SqliteCommand(dropTable, connection);
                tableDrop.ExecuteNonQuery();

                var createTable = @"CREATE TABLE IF NOT EXISTS traffic(
                            id INTEGER NOT NULL,
                            address TEXT NOT NULL,
                            day TEXT NOT NULL,
                            noveh INTEGER NOT NULL,
                            avgspeed REAL NOT NULL,
                            roadblock NUMERIC NOT NULL
                        )";

                using var tableCreation = new SqliteCommand(createTable, connection);
                tableCreation.ExecuteNonQuery();
                Console.WriteLine("A tábla sikeresen elkészült.");

                var insertValues = "INSERT INTO traffic (id, address, day, noveh, avgspeed, roadblock) " +
                          "VALUES (@id, @address, @day, @noveh, @avgspeed, @roadblock)";
                foreach (var t in traffics)
                {
                    using var insert = new SqliteCommand(insertValues, connection);

                    insert.Parameters.AddWithValue("@id", t.id);
                    insert.Parameters.AddWithValue("@address", t.address);
                    insert.Parameters.AddWithValue("@day", t.day);
                    insert.Parameters.AddWithValue("@noveh", t.novehicles);
                    insert.Parameters.AddWithValue("@avgspeed", t.avgspeed);
                    insert.Parameters.AddWithValue("@roadblock", t.roadblock);
                    var rowInserted = insert.ExecuteNonQuery();
                }

                var select = "SELECT * FROM traffic";
                using var read = new SqliteCommand(select, connection);
                using var reader = read.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("ID\tCím\t\t\t\tNap\tAutók száma\tÁtlag seb.\tÚtzár");
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var address = reader.GetString(1);
                        var day = reader.GetString(2);
                        var novehicles = reader.GetInt32(3);
                        var avgspeed = reader.GetDouble(4);
                        var roadblock = reader.GetBoolean(5);
                        Console.WriteLine($"{id}\t{address}\t\t{day}\t{novehicles}\t{avgspeed}\t{roadblock}");
                    }
                }

                connection.Close();
            }
            catch(SqliteException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
