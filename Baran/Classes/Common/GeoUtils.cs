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

        //============================================================================
        public static List<PointLatLng> ConvertStringPointToGMapPoint(string pointString)
        {
            pointString = pointString.Remove(pointString.Length - 2);
            pointString = string.Concat(pointString.Skip(7));

            string[] points = pointString.Split(',');
            List <PointLatLng> coordinates = new List<PointLatLng>();

            foreach (string point in points)
            {
                string[] p = point.Trim().Split(' ');
                coordinates.Add(new PointLatLng(PublicMethods.ConvertToDouble(p.Last()), PublicMethods.ConvertToDouble(p.First())));
                //coordinate.Lat = PublicMethods.ConvertToDouble(p.Last());
                //coordinate.Lng = PublicMethods.ConvertToDouble(p.First());
            }
            return coordinates;
        }
        //============================================================================

        //============================================================================
        public static DbGeometry ConvertGMapPointToDbGeometryPoint(PointLatLng point)
        {
            var text = string.Format(CultureInfo.InvariantCulture.NumberFormat,
                                     "POINT({0} {1})", point.Lng, point.Lat);
            // 4326 is most common coordinate system used by GPS/Maps
            return DbGeometry.PointFromText(text, 4326);
        }
        //============================================================================

        //============================================================================
        public static List<PointLatLng> ConvertStringCoordinatesToGMapPolygony(string pointString)
        {
            pointString = pointString.Remove(pointString.Length - 2);
            pointString = string.Concat(pointString.Skip(10));

            string[] points = pointString.Split(',');
            List<PointLatLng> coordinates = new List<PointLatLng>();

            foreach (string point in points)
            {                
                string[] p = point.Trim().Split(' ');
                coordinates.Add(new PointLatLng(PublicMethods.ConvertToDouble(p.Last()), PublicMethods.ConvertToDouble(p.First())));
            }
            return coordinates;
        }
        //============================================================================

        //============================================================================
        public static List<PointLatLng> ConvertStringCoordinatesToGMapRoute(string pointString)
        {
            pointString = pointString.Remove(pointString.Length - 1);
            pointString = string.Concat(pointString.Skip(12));

            string[] points = pointString.Split(',');
            List<PointLatLng> coordinates = new List<PointLatLng>();

            foreach (string point in points)
            {
                string[] p = point.Trim().Split(' ');
                coordinates.Add(new PointLatLng(PublicMethods.ConvertToDouble(p.Last()), PublicMethods.ConvertToDouble(p.First())));
            }
            return coordinates;
        }
        //============================================================================

        //============================================================================        
        public static DbGeometry ConvertGMapPolygonPointsToDbGeometryPolygon(List<PointLatLng> coordinates)
        {            
            var coordinateList = coordinates.ToList();
            if (coordinateList.First() != coordinateList.Last())
            {
                coordinateList.Add(coordinateList.First());                
            }

            var count = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

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
        //============================================================================

        //============================================================================        
        public static DbGeometry ConvertGMapLinePointsToDbGeometryLine(List<PointLatLng> coordinates)
        {
            var coordinateList = coordinates.ToList();
            //if (coordinateList.First() != coordinateList.Last())
            //{
            //    coordinateList.Add(coordinateList.First());
            //}

            var count = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(@"LINESTRING(");
            foreach (var coordinate in coordinateList)
            {
                if (count == 0)
                {
                    sb.Append(coordinate.Lng + " " + coordinate.Lat);
                }
                else
                {
                    sb.Append("," + coordinate.Lng + " " + coordinate.Lat);
                }

                count++;
            }

            sb.Append(@")");
            string sdf = sb.ToString();
            return DbGeometry.LineFromText(sb.ToString().Replace("/", "."), 4326);
        }
        //============================================================================

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
