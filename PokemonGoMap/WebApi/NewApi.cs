using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pgmasst.Api
{
    //public class WebRequestGetExample
    //{
    //    #region type for json
    //    class Mon
    //    {
    //        public string pokemon_id;//": "2",
    //        public string lat;//: "1.374883",
    //        public string lng;//": "103.947437",
    //        public string despawn;//": "1474249480"    
    //    }

    //    class meta
    //    {
    //        public int inserted;
    //    }

    //    class Mons
    //    {
    //        public Mon[] pokemons;
    //        public meta meta;
    //    }
    //    #endregion

    //    public static void GetMons(string since, IEnumerable<int> targeIds)
    //    {
    //        #region get
    //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://sgpokemap.com/query2.php?since=0&mons=1,2,3,4,5,6,9,25,26,59,65,68,77,89,103,106,107,108,113,130,131,134,135,136,137,138,139,140,142,143,144,148,149,150,151");
    //        request.Credentials = CredentialCache.DefaultCredentials;
    //        request.Method = WebRequestMethods.Http.Get;
    //        request.Accept = "*/*";
    //        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    //        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.84 Safari/537.36";
    //        request.Referer = "https://sgpokemap.com/";
    //        request.Headers.Add("authority", "sgpokemap.com");
    //        request.Headers.Add("scheme", "https");
    //        request.Headers.Add("accept-encoding", "gzip, deflate, sdch, br");
    //        request.Headers.Add("accept-language", "zh-CN,zh;q=0.8,en;q=0.6");
    //        request.Headers.Add("cache-control", "max-age=0");
    //        request.Headers.Add("cookie", "__cfduid=d3b40e8c5519b26b97cd57855fea053d91473909813; _gat=1; _ga=GA1.2.760087683.1473909791");
    //        request.Headers.Add("x-requested-with", "XMLHttpRequest");
    //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    //        Debug.WriteLine(response.StatusDescription);
    //        Stream dataStream = response.GetResponseStream();
    //        StreamReader reader = new StreamReader(dataStream);
    //        string responseFromServer = reader.ReadToEnd();
    //        Debug.WriteLine(responseFromServer);
    //        #endregion

    //        var m = JsonConvert.DeserializeObject<Mons>(responseFromServer);
    //        dataStream?.Close();
    //        response.Close();
    //    }

    //    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    //    {
    //        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
    //        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
    //        return dtDateTime;
    //    }
    //}
}