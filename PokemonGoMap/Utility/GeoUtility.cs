using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using PokemonGoMap.Utility;
using HtmlAgilityPack;
using System.Linq;
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//:::                                                                         :::
//:::  This routine calculates the distance between two points (given the     :::
//:::  latitude/longitude of those points). It is being used to calculate     :::
//:::  the distance between two locations using GeoDataSource(TM) products    :::
//:::                                                                         :::
//:::  Definitions:                                                           :::
//:::    South latitudes are negative, east longitudes are positive           :::
//:::                                                                         :::
//:::  Passed to function:                                                    :::
//:::    lat1, lon1 = Latitude and Longitude of point 1 (in decimal degrees)  :::
//:::    lat2, lon2 = Latitude and Longitude of point 2 (in decimal degrees)  :::
//:::    unit = the unit you desire for results                               :::
//:::           where: 'M' is statute miles (default)                         :::
//:::                  'K' is kilometers                                      :::
//:::                  'N' is nautical miles                                  :::
//:::                                                                         :::
//:::  Worldwide cities and other features databases with latitude longitude  :::
//:::  are available at http://www.geodatasource.com                          :::
//:::                                                                         :::
//:::  For enquiries, please contact sales@geodatasource.com                  :::
//:::                                                                         :::
//:::  Official Web site: http://www.geodatasource.com                        :::
//:::                                                                         :::
//:::           GeoDataSource.com (C) All Rights Reserved 2015                :::
//:::                                                                         :::
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::


namespace Pgmasst.Utility
{
    public class GeoUtility
    {
        //private struct XmlAdressElement
        //{
        //    public string AddressType;
        //    public string Adress;
        //}

        //http://maps.google.com/maps/api/geocode/xml?latlng=40.714224,-73.961452&sensor=false 

        public static string GetAdresses(double lat, double lng)
        {
            var url =
                string.Format(@"http://maps.google.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false ", lat, lng);
            var request = FastHttpRequest.Create(url);
            request.Host = "maps.google.com";

            var returnAddressInfo = "";
            using (var response = request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    returnAddressInfo = sr.ReadToEnd();
                    Debug.WriteLine(returnAddressInfo);
                }
            }

            //var str = File.ReadAllText(@"C:\Users\ZhiYong\Desktop\1.xml");
            var xmlDoc = new HtmlDocument();
            xmlDoc.LoadHtml(returnAddressInfo);

            if (!xmlDoc.DocumentNode.SelectNodes("//status")[0].InnerText.Equals("OK"))
                return null;

            string address = null;
            foreach (var node in  xmlDoc.DocumentNode.SelectNodes("//result").Where(n =>
            {
                var typenode = n.SelectSingleNode("type");
                if (typenode == null)
                    return false;
                if (typenode.InnerText == "premise" ||
                    typenode.InnerText == "establishment" ||
                    typenode.InnerText == "route")
                    return true;
                return false;
            }))
            {
                if (node.SelectSingleNode("type").InnerText == "establishment")
                    address = node.SelectSingleNode("formatted_address").InnerText;
                else if (node.SelectSingleNode("type").InnerText == "premise")
                    address = node.SelectSingleNode("formatted_address").InnerText;
                else if (node.SelectSingleNode("type").InnerText == "route")
                    address = node.SelectSingleNode("formatted_address").InnerText;
            }
            return address;
        }

        public static double CalcuDeistance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
            dist = Math.Acos(dist);
            dist = Rad2Deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private static double Deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private static double Rad2Deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}