﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Pgmasst.Main.Pginfos;

#pragma warning disable 649

namespace Pgmasst.WebApi
{
    internal class XdwContext : DbContext
    {
        public DbSet<Xdw> Xdws { get; set; }
    }

    internal class Xdw
    {
        [Key]
        public int XdwId { get; set; }
        public string XdwName { get; set; }
        public string XdwLat { get; set; }
        public string XdwLon { get; set; }

        public override string ToString()
        {
            return this.XdwId + ", " + this.XdwName + ", " + this.XdwLat + ", " + this.XdwLon;
        }
    }

    //public class DownloadData
    //{
    //    public const string Folder = @"..\Data";
    //    private static SQLiteConnection mDbConnection;

    //    private static Random random = new Random(Environment.TickCount);

    //    static DownloadData()
    //    {
    //        //if (!File.Exists("pg.sqlite"))
    //        //    SQLiteConnection.CreateFile("pg.sqlite");
    //        //mDbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
    //        //mDbConnection.Open();
    //    }

    //    private static void Run()
    //    {
    //        ////1.232396, 103.601263 - left bottom
    //        ////1.489934, 104.023986 - right top
    //        ////var url = @"https://skiplagged.com/api/pokemon.php?bounds=22.18628,113.672943,22.623665,114.551849";
    //        //var url = @"https://skiplagged.com/api/pokemon.php?bounds=1.232396,103.601263,1.489934,104.023986";
    //        //var request = FastHttpRequest.Create(url);
    //        //request.Host = "skiplagged.com";
    //        //request.Referer = "https://skiplagged.com/pokemon/";

    //        //var startTime = DateTime.Now;
    //        //Form1.Logger.Log("Start Read");

    //        //using (var response = request.GetResponse())
    //        //{
    //        //    var rawJson = response.GetResponseStream().ReadAllText(Encoding.UTF8);
                
    //        //    var endTime = DateTime.Now;
    //        //    Form1.Logger.Log("End Read");

    //        //    Directory.CreateDirectory(Folder);
    //        //    var fileName = startTime.ToString("yyyyMMddHHmmss");

    //        //    var rawPath = Path.Combine(Folder, fileName + ".raw.txt");
    //        //    File.WriteAllText(rawPath, rawJson);
    //        //    Form1.Logger.Log("Export to " + rawPath);

    //        //    try
    //        //    {
    //        //        dynamic result = JsonConvert.DeserializeObject(rawJson);
    //        //        var pokemons = ((IEnumerable)result.pokemons).Cast<dynamic>();

    //        //        var monsters = pokemons.Select(pokemon => new Monster
    //        //        {
    //        //            Id = pokemon.pokemon_id,
    //        //            Name = pokemon.pokemon_name,
    //        //            Latitude = pokemon.latitude,
    //        //            Longitude = pokemon.longitude,
    //        //            Time = JavascriptUtil.GetDateTime((long)pokemon.expires * 1000),
    //        //            Source = "skiplagged"
    //        //        }).ToArray();

    //        //        var saveJson = JsonConvert.SerializeObject(monsters);
    //        //        var validPath = Path.Combine(Folder, fileName + ".json");
    //        //        File.WriteAllText(validPath, saveJson);
    //        //        Form1.Logger.Log("Export to " + validPath);
    //        //    }
    //        //    catch (Exception e)
    //        //    {
    //        //        Form1.Logger.Log(e);
    //        //    }
    //        //}
    //    }

    //    private static IEnumerable<Xdw> GetXdws()
    //    {
    //        //1.232396, 103.601263 - left bottom
    //        //1.489934, 104.023986 - right top
    //        //var url = @"https://skiplagged.com/api/pokemon.php?bounds=22.18628,113.672943,22.623665,114.551849";
    //        var url = @"https://skiplagged.com/api/pokemon.php?bounds=1.232396,103.601263,1.489934,104.023986";
    //        var request = FastHttpRequest.Create(url);
    //        request.Host = "skiplagged.com";
    //        request.Referer = "https://skiplagged.com/pokemon/";

    //        var startTime = DateTime.Now;

    //        using (var response = request.GetResponse())
    //        {
    //            var rawJson = response.GetResponseStream().ReadAllText(Encoding.UTF8);

    //            try
    //            {
    //                dynamic result = JsonConvert.DeserializeObject(rawJson);
    //                var pokemons = ((IEnumerable)result.pokemons).Cast<dynamic>();

    //                return pokemons.Select(pokemon => new Xdw
    //                {
    //                    XdwId = pokemon.pokemon_id,
    //                     XdwName = pokemon.pokemon_name,
    //                     XdwLat = pokemon.latitude,
    //                    XdwLon = pokemon.longitude,
    //                });
    //            }
    //            catch (Exception e)
    //            {
    //                //Form1.Logger.Log(e);
    //                throw new Exception("fail", e);
    //            }
    //        }
    //    }

    //    private static void Log(string log)
    //    {
    //        File.AppendAllText("log.txt", log + Environment.NewLine);
    //    }

    //    public static void StoreStat()
    //    {
    //        while (true)
    //        {
    //            try
    //            {
    //                using (var db = new XdwContext())
    //                {
    //                    db.Database.CreateIfNotExists();

    //                    var xdws = GetXdws().ToList();
    //                    db.Xdws.AddRange(xdws);
    //                    var loginfo = string.Format("{0}    {1} recorded", DateTime.Now, xdws.Count);
    //                    Log(loginfo);
    //                    Console.Clear();
    //                    Console.WriteLine(loginfo);

    //                    db.SaveChanges();
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                Log(ex.ToString());
    //            }
    //            Thread.Sleep(new TimeSpan(0, random.Next(1, 5), 0));
    //        }
    //        //            using (var db = new XdwContext())
    //        //            {
    //        //                db.Database.CreateIfNotExists();
    //        //                while (DateTime.Now.Hour < 17)
    //        //                {
    //        //                    try
    //        //                    {
    //        //                        var xdws = GetXdws().ToList();
    //        //                        db.Xdws.AddRange(xdws);
    //        //                        var loginfo = string.Format("{0}    {1} recorded", DateTime.Now, xdws.Count);
    //        //                        Log(loginfo);
    //        //                        Console.Clear();
    //        //                        Console.WriteLine(loginfo);
    //        //                    }
    //        //                    catch (Exception ex)
    //        //                    {
    //        //                        Debug.WriteLine(ex);
    //        //                    }
    //        //#if DEBUG
    //        //                    Thread.Sleep(1000);
    //        //#else
    //        //                    Thread.Sleep(new TimeSpan(0, random.Next(1, 5), 0));
    //        //#endif
    //        //                }
    //        //                //Console.WriteLine(db.Xdws.Count());
    //        //                db.SaveChanges();
    //        //            }
    //    }

    //    public static void ShowStat()
    //    {
    //        using (var db = new XdwContext())
    //        {
    //            db.Database.CreateIfNotExists();

    //            db.Xdws.GroupBy(xdw => xdw.XdwName).ToList().ForEach(x =>
    //            {
    //                Trace.WriteLine(string.Format("ID: {0}, Name: {1}, Count: {2}", x.Key, x.First().XdwName, x.Count()));
    //            });
    //            //db.SaveChanges();
    //        }
    //    }

    //    public static IEnumerable<PointLatLng> GetStat()
    //    {
    //        using (var db = new XdwContext())
    //        {
    //            db.Database.CreateIfNotExists();

    //            return db.Xdws.Where(p => p.XdwId == 25).Select(p => new PointLatLng(double.Parse(p.XdwLat),
    //                double.Parse(p.XdwLon)));

    //            //db.Xdws.GroupBy(xdw => xdw.XdwName).ToList().ForEach(x =>
    //            //{
    //            //    Trace.WriteLine(string.Format("ID: {0}, Name: {1}, Count: {2}", x.Key, x.First().XdwName, x.Count()));
    //            //});
    //            //db.SaveChanges();
    //        }
    //    }

    //    private static void CreateTable(string name)
    //    {
    //        mDbConnection = new SQLiteConnection("Data Source=pg.sqlite;Version=3;");
    //        mDbConnection.Open();

    //        var sqlOperation = string.Format("CREATE TABLE Xdws (XdwLat VARCHAR(50), (XdwLon VARCHAR(50))");
    //        var command = new SQLiteCommand(sqlOperation, mDbConnection);
    //        command.ExecuteNonQuery();
    //        mDbConnection.Close();
    //    }
    //}

    public class SgpkmApi : IModelSpawnInfo
    {
        #region type for json
        class Mon
        {
            public string pokemon_id;//": "2",
            public string lat;//: "1.374883",
            public string lng;//": "103.947437",
            public string despawn;//": "1474249480"    

            public string attack;
            public string defence;
            public string stamina;   
            public string move1;  
            public string move2;
        }

        class meta
        {
            public int inserted;
        }

        class Mons
        {
            public Mon[] pokemons;
            public meta meta;
        }
        #endregion

        private void GetMons(string since, IEnumerable<int> targeIds)
        {
            #region get
            var request = (HttpWebRequest)WebRequest.Create("https://sgpokemap.com/query2.php?since=0&mons=1,2,3,4,5,6,9,25,26,59,65,68,77,89,103,106,107,108,113,130,131,134,135,136,137,138,139,140,142,143,144,148,149,150,151");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "*/*";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.84 Safari/537.36";
            request.Referer = "https://sgpokemap.com/";
            request.Headers.Add("authority", "sgpokemap.com");
            request.Headers.Add("scheme", "https");
            request.Headers.Add("accept-encoding", "gzip, deflate, sdch, br");
            request.Headers.Add("accept-language", "zh-CN,zh;q=0.8,en;q=0.6");
            request.Headers.Add("cache-control", "max-age=0");
            request.Headers.Add("cookie", "__cfduid=d3b40e8c5519b26b97cd57855fea053d91473909813; _gat=1; _ga=GA1.2.760087683.1473909791");
            request.Headers.Add("x-requested-with", "XMLHttpRequest");
            var response = (HttpWebResponse)request.GetResponse();
            Debug.WriteLine(response.StatusDescription);
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            var responseFromServer = reader.ReadToEnd();
            Debug.WriteLine(responseFromServer);
            #endregion

            var m = JsonConvert.DeserializeObject<Mons>(responseFromServer);
            dataStream?.Close();
            response.Close();
        }

        public void InitApiVersion()
        {
            try
            {
                #region get

                var url = @"https://sgpokemap.com/pokemon_list.json?ver281";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = WebRequestMethods.Http.Get;
                request.Accept = "*/*";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
                //request.Headers.Add("accept-encoding", "gzip, deflate, sdch, br");
                request.Referer = @"https://sgpokemap.com/";
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Debug.WriteLine("Response status: " + response.StatusCode);
                    response.Close();
                    return;
                }

                var dataStream = response.GetResponseStream();
                if (dataStream == null)
                {
                    response.Close();
                    return;
                }
                var reader = new StreamReader(dataStream);
                var responseFromServer = reader.ReadToEnd();
                //Debug.WriteLine(responseFromServer);
                dataStream?.Close();
                response.Close();

                #endregion
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
            }
        }

        public IEnumerable<Sprite> GetCurrentSprites(string since, IEnumerable<string> ids)
        {
            try
            {
                #region get

                string responseFromServer = "";
#if DEBUG
                //if (File.Exists("response.txt"))
                //    responseFromServer = File.ReadAllText("response.txt");
                //else
                {
#endif
                    Debug.WriteLine("Since: " + since);
                    var url = string.Format("https://sgpokemap.com/query2.php?since={0}&mons={1}",
                        since, ids.Aggregate((id1, id2) => id1 + "," + id2));
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Method = WebRequestMethods.Http.Get;
                    request.Accept = "*/*";
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    request.UserAgent =
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.84 Safari/537.36";
                    request.Referer = "https://sgpokemap.com/";
                    request.Headers.Add("authority", "sgpokemap.com");
                    request.Headers.Add("accept-encoding", "gzip, deflate, sdch, br");
                    request.Headers.Add("accept-language", "zh-CN,zh;q=0.8,en;q=0.6");
                    request.Headers.Add("cache-control", "max-age=0");
                    request.Headers.Add("cookie",
                        "__cfduid=d3b40e8c5519b26b97cd57855fea053d91473909813; _gat=1; _ga=GA1.2.760087683.1473909791");
                    request.Headers.Add("x-requested-with", "XMLHttpRequest");
                    var response = (HttpWebResponse)request.GetResponse();
                    //Debug.WriteLine("Get data success: " + response.StatusDescription);
                    var dataStream = response.GetResponseStream();
                    if (dataStream == null)
                    {
                        response.Close();
                        return null;
                    }
                    var reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();
                    dataStream?.Close();
                    response.Close();
#if DEBUG                    
                    //File.WriteAllText("response.txt", responseFromServer);
                }
#endif
                #endregion

                if (string.IsNullOrEmpty(responseFromServer))
                    return null;
                var m = JsonConvert.DeserializeObject<Mons>(responseFromServer);
                return m.pokemons.Select(p =>
                {
                    var sp = new Sprite();
                    sp.Id = int.Parse(p.pokemon_id);
                    sp.Name = PkmIdName.GetName(sp.Id);
                    sp.NameCn = PkmIdName.GetCnName(sp.Id);
                    sp.DeSpawn = int.Parse(p.despawn);
                    sp.Lat = double.Parse(p.lat);
                    sp.Lng = double.Parse(p.lng);
                    sp.Iv = (int)Math.Floor((double.Parse(p.attack) + double.Parse(p.defence) + double.Parse(p.stamina)) / 45 * 100);
                    return sp;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                return new List<Sprite>();
            }
        }

        public IEnumerable<Sprite> GetCurrentSprites(string since, IEnumerable<int> ids)
        {
            return GetCurrentSprites(since, ids.Select(id => id.ToString()));
        }
    }

}
