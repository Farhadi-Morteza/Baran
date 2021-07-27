using GMap.NET;
using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Device.Location;
using System.Globalization;
using System.Linq;

namespace Baran.Classes.Common
{

    /// <summary>
    /// Geolocation helpers for Entity Framework types
    /// </summary>
    public static class GeoUtils
    {
        /// <summary>
        /// Create a GeoLocation point based on latitude and longitude
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public static DbGeography CreatePoint(double latitude, double longitude)
        {
            var text = string.Format(CultureInfo.InvariantCulture.NumberFormat,
                                     "POINT({0} {1})", longitude, latitude);
            // 4326 is most common coordinate system used by GPS/Maps
            return DbGeography.PointFromText(text, 4326);
          
        }

        /// <summary>
        /// Create a GeoLocation point based on latitude and longitude
        /// </summary>
        /// <param name="latitudeLongitude">
        /// String should be two values either single comma or space delimited
        /// 45.710030,-121.516153
        /// 45.710030 -121.516153
        /// </param>
        /// <returns></returns>
        public static DbGeography CreatePoint(string latitudeLongitude)
        {
            var tokens = latitudeLongitude.Split(',', ' ');
            if (tokens.Length != 2)
                throw new ArgumentException("InvalidLocationStringPassed");
            var text = string.Format(CultureInfo.InvariantCulture.NumberFormat,
                                     "POINT({0} {1})", tokens[2], tokens[0]);
            return DbGeography.PointFromText(text, 4326);
        }
        //============================================================================
        //===================
        public static List<PointLatLng> ConvertStringArrayToGeographicCoordinates(string pointString)
        {
            pointString = string.Concat(pointString.Skip(10).Take(pointString.Length - 2));
            string[] points = pointString.Split(',');
            List<PointLatLng> coordinates = new List<PointLatLng>();

            foreach (string point in points)
            {
                
                string[] p = point.Trim().Split(' ');
                coordinates.Add(new PointLatLng(Convert.ToDouble(p.First()), Convert.ToDouble(p.Last())));
                //coordinates.Add(new PointLatLng(double.Parse(p.First().Replace(".", "/")), double.Parse(p.Last().Replace(".", "/"))));
            }
            //for (var i = 0; i < points.Length / 2; i++)
            //{
            //    var geoPoint = points.Skip(i * 2).Take(2).ToList();
            //    coordinates.Add(new PointLatLng(double.Parse(geoPoint.First()), double.Parse(geoPoint.Last())));
            //}

            return coordinates;

            //string[] pp = pointString.Split(',');
            ////int g = pointString.Length - 2;
            ////var firstAndLastRemoved = string.Concat(pointString.Skip(10).Take(pointString.Length - 2));
            ////string str = string.Concat(pointString.Skip(10));
            ////str = str.Take(str.Length - 2);
            ////var jkj = string.Concat(pointString.Skip(10).Take(pointString.Length - 2));
            ////string p = pointString.Substring(10, 90);

            ////pointString = string.Concat(pointString.Skip(10).Take(pointString.Length - 2));

            //var points = pointString.Split(',');
            //var t = "";
            //foreach (var p in points)
            //{
            //    t = p.ToString().Trim();
            //}
            //var coordinates = new List<PointLatLng>();

            //foreach (var p in points)
            //{

            //    var gg = p.Split(' ');
            //    double d1 = Convert.ToDouble(gg.First());
            //    coordinates.Add(new PointLatLng(Convert.ToDouble(gg[0]), Convert.ToDouble(gg[1])));
            //    //var jj = p
            //}

            //for (var i = 0; i < points.Length / 2; i++)
            //{
            //    var geoPoint = points.Skip(i * 2).Take(2).ToList();
            //    //coordinates.Add(new GeoCoordinate(double.Parse(geoPoint.First()), double.Parse(geoPoint.Last())));
            //    //coordinates.Add(new PointLatLng(double.Parse(geoPoint[0], double.Parse(geoPoint[1])));
            //    //points.Add(new PointLatLng(Convert.ToDouble(point.Latitude), Convert.ToDouble(point.Longitude)));
            //    var dd = geoPoint[0];
            //    var jk = Convert.ToDouble(geoPoint[0]);
            //    coordinates.Add(new PointLatLng(Convert.ToDouble(geoPoint.First()), Convert.ToDouble(geoPoint.Last())));
            //}

            //return coordinates;
        }
        //===================

        //===================
        public static DbGeometry ConvertGMapPolygonPointsToDbGeometryPolygon(IEnumerable<PointLatLng> coordinates)
        {            
            var coordinateList = coordinates.ToList();
            if (coordinateList.First() != coordinateList.Last())
            {
                coordinateList.Add(coordinateList.First());                
            }

            var count = 0;
            var sb = new System.Text.StringBuilder();

            sb.Append(@"POLYGON((");
            foreach (var coordinate in coordinateList)
            {
                if (count == 0)
                {
                    sb.Append( coordinate.Lng + " " + coordinate.Lat);
                }
                else
                {
                    sb.Append("," + coordinate.Lng + " " + coordinate.Lat);
                }

                count++;
            }

            sb.Append(@"))");
            return DbGeometry.PolygonFromText(sb.ToString().Replace("/", "."), 4326);
        }
        //===================
        //============================================================================

        /// <summary>
        /// Convert meters to miles
        /// </summary>
        /// <param name="meters"></param>
        /// <returns></returns>
        public static double MetersToMiles(double? meters)
        {
            if (meters == null)
                return 0F;

            return meters.Value * 0.000621371192;
        }

        /// <summary>
        /// Convert meters to feet
        /// </summary>
        /// <param name="meters"></param>
        /// <returns></returns>
        public static double MetersToFeet(double? meters)
        {
            if (meters == null)
                return 0;

            return meters.Value * 3.2808399;
        }

        /// <summary>
        /// Convert miles to meters
        /// </summary>
        /// <param name="miles"></param>
        /// <returns></returns>
        public static double MilesToMeters(double? miles)
        {
            if (miles == null)
                return 0;

            return miles.Value * 1609.344;
        }


        /// <summary>
        /// Displays a miles value as a string with a mile postfix
        /// 1.0
        /// </summary>
        /// <param name="meters"></param>
        /// <returns></returns>
        public static string DisplayMiles(double? meters)
        {
            var miles = MetersToMiles(meters);
            if (miles <= 0)
                return string.Empty;

            if (miles <= 1)
                return string.Format("{0:n2} mile", miles);
            else if (miles < 10)
                return string.Format("{0:n2} miles", miles);
            else
                return string.Format("{0:n0} miles", miles);
        }
    }
}
