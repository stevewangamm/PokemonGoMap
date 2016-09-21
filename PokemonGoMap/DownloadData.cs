using Newtonsoft.Json;
using PokemonGoMap.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GMap.NET;

namespace PokemonGoMap
{
    public class XdwContext : DbContext
    {
        public DbSet<Xdw> Xdws { get; set; }
    }

    public class Xdw
    {
        [Key]
        public int XdwId { get; set; }
        public string XdwName { get; set; }
        public string XdwLat { get; set; }
        public string XdwLon { get; set; }

        public override string ToString()
        {
            return XdwId + ", " + XdwName + ", " + XdwLat + ", " + XdwLon;
        }
    }

    class DownloadData
    {
        public const string Folder = @"..\Data";
        private static SQLiteConnection mDbConnection;

        private static Random random = new Random(Environment.TickCount);

        static DownloadData()
        {
            //if (!File.Exists("pg.sqlite"))
            //    SQLiteConnection.CreateFile("pg.sqlite");
            //mDbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            //mDbConnection.Open();
        }

        public static void Run()
        {
            //1.232396, 103.601263 - left bottom
            //1.489934, 104.023986 - right top
            //var url = @"https://skiplagged.com/api/pokemon.php?bounds=22.18628,113.672943,22.623665,114.551849";
            var url = @"https://skiplagged.com/api/pokemon.php?bounds=1.232396,103.601263,1.489934,104.023986";
            var request = FastHttpRequest.Create(url);
            request.Host = "skiplagged.com";
            request.Referer = "https://skiplagged.com/pokemon/";

            var startTime = DateTime.Now;
            Form1.Logger.Log("Start Read");

            using (var response = request.GetResponse())
            {
                var rawJson = response.GetResponseStream().ReadAllText(Encoding.UTF8);
                
                var endTime = DateTime.Now;
                Form1.Logger.Log("End Read");

                Directory.CreateDirectory(Folder);
                var fileName = startTime.ToString("yyyyMMddHHmmss");

                var rawPath = Path.Combine(Folder, fileName + ".raw.txt");
                File.WriteAllText(rawPath, rawJson);
                Form1.Logger.Log("Export to " + rawPath);

                try
                {
                    dynamic result = JsonConvert.DeserializeObject(rawJson);
                    var pokemons = ((IEnumerable)result.pokemons).Cast<dynamic>();

                    var monsters = pokemons.Select(pokemon => new Monster
                    {
                        Id = pokemon.pokemon_id,
                        Name = pokemon.pokemon_name,
                        Latitude = pokemon.latitude,
                        Longitude = pokemon.longitude,
                        Time = JavascriptUtil.GetDateTime((long)pokemon.expires * 1000),
                        Source = "skiplagged"
                    }).ToArray();

                    var saveJson = JsonConvert.SerializeObject(monsters);
                    var validPath = Path.Combine(Folder, fileName + ".json");
                    File.WriteAllText(validPath, saveJson);
                    Form1.Logger.Log("Export to " + validPath);
                }
                catch (Exception e)
                {
                    Form1.Logger.Log(e);
                }
            }
        }

        private static IEnumerable<Xdw> GetXdws()
        {
            //1.232396, 103.601263 - left bottom
            //1.489934, 104.023986 - right top
            //var url = @"https://skiplagged.com/api/pokemon.php?bounds=22.18628,113.672943,22.623665,114.551849";
            var url = @"https://skiplagged.com/api/pokemon.php?bounds=1.232396,103.601263,1.489934,104.023986";
            var request = FastHttpRequest.Create(url);
            request.Host = "skiplagged.com";
            request.Referer = "https://skiplagged.com/pokemon/";

            var startTime = DateTime.Now;

            using (var response = request.GetResponse())
            {
                var rawJson = response.GetResponseStream().ReadAllText(Encoding.UTF8);

                try
                {
                    dynamic result = JsonConvert.DeserializeObject(rawJson);
                    var pokemons = ((IEnumerable)result.pokemons).Cast<dynamic>();

                    return pokemons.Select(pokemon => new Xdw
                    {
                        XdwId = pokemon.pokemon_id,
                         XdwName = pokemon.pokemon_name,
                         XdwLat = pokemon.latitude,
                        XdwLon = pokemon.longitude,
                    });
                }
                catch (Exception e)
                {
                    Form1.Logger.Log(e);
                    throw new Exception("fail", e);
                }
            }
        }

        private static void Log(string log)
        {
            File.AppendAllText("log.txt", log + Environment.NewLine);
        }

        public static void StoreStat()
        {
            while (true)
            {
                try
                {
                    using (var db = new XdwContext())
                    {
                        db.Database.CreateIfNotExists();

                        var xdws = GetXdws().ToList();
                        db.Xdws.AddRange(xdws);
                        var loginfo = string.Format("{0}    {1} recorded", DateTime.Now, xdws.Count);
                        Log(loginfo);
                        Console.Clear();
                        Console.WriteLine(loginfo);

                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
                Thread.Sleep(new TimeSpan(0, random.Next(1, 5), 0));
            }
            //            using (var db = new XdwContext())
            //            {
            //                db.Database.CreateIfNotExists();
            //                while (DateTime.Now.Hour < 17)
            //                {
            //                    try
            //                    {
            //                        var xdws = GetXdws().ToList();
            //                        db.Xdws.AddRange(xdws);
            //                        var loginfo = string.Format("{0}    {1} recorded", DateTime.Now, xdws.Count);
            //                        Log(loginfo);
            //                        Console.Clear();
            //                        Console.WriteLine(loginfo);
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        Debug.WriteLine(ex);
            //                    }
            //#if DEBUG
            //                    Thread.Sleep(1000);
            //#else
            //                    Thread.Sleep(new TimeSpan(0, random.Next(1, 5), 0));
            //#endif
            //                }
            //                //Console.WriteLine(db.Xdws.Count());
            //                db.SaveChanges();
            //            }
        }

        public static void ShowStat()
        {
            using (var db = new XdwContext())
            {
                db.Database.CreateIfNotExists();

                db.Xdws.GroupBy(xdw => xdw.XdwName).ToList().ForEach(x =>
                {
                    Trace.WriteLine(string.Format("ID: {0}, Name: {1}, Count: {2}", x.Key, x.First().XdwName, x.Count()));
                });
                //db.SaveChanges();
            }
        }

        public static IEnumerable<PointLatLng> GetStat()
        {
            using (var db = new XdwContext())
            {
                db.Database.CreateIfNotExists();

                return db.Xdws.Where(p => p.XdwId == 25).Select(p => new PointLatLng(double.Parse(p.XdwLat),
                    double.Parse(p.XdwLon)));

                //db.Xdws.GroupBy(xdw => xdw.XdwName).ToList().ForEach(x =>
                //{
                //    Trace.WriteLine(string.Format("ID: {0}, Name: {1}, Count: {2}", x.Key, x.First().XdwName, x.Count()));
                //});
                //db.SaveChanges();
            }
        }

        private static void CreateTable(string name)
        {
            mDbConnection = new SQLiteConnection("Data Source=pg.sqlite;Version=3;");
            mDbConnection.Open();

            var sqlOperation = string.Format("CREATE TABLE Xdws (XdwLat VARCHAR(50), (XdwLon VARCHAR(50))");
            var command = new SQLiteCommand(sqlOperation, mDbConnection);
            command.ExecuteNonQuery();
            mDbConnection.Close();
        }
    }
}
