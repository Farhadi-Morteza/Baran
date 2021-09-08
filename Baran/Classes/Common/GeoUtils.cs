using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Device.Location;
using System.Drawing;
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
            List<PointLatLng> coordinates = new List<PointLatLng>();

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
                    sb.Append(coordinate.Lng + " " + coordinate.Lat);
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

        public static PointLatLng FindCentroid(List<PointLatLng> Points)
        {
            // Add the first point at the end of the array.
            int num_points = Points.Count;
            PointLatLng[] pts = new PointLatLng[num_points + 1];
            Points.CopyTo(pts, 0);
            pts[num_points] = Points[0];

            // Find the centroid.
            double X = 0;
            double Y = 0;
            double second_factor;
            for (int i = 0; i < num_points; i++)
            {
                second_factor =
                    pts[i].Lat * pts[i + 1].Lng -
                    pts[i + 1].Lat * pts[i].Lng;
                X += (pts[i].Lat + pts[i + 1].Lat) * second_factor;
                Y += (pts[i].Lng + pts[i + 1].Lng) * second_factor;
            }

            // Divide by 6 times the polygon's area.
            //float polygon_area = PolygonArea();
            //X /= (6 * polygon_area);
            //Y /= (6 * polygon_area);

            // If the values are negative, the polygon is
            // oriented counterclockwise so reverse the signs.
            if (X < 0)
            {
                X = -X;
                Y = -Y;
            }

            return new PointLatLng(X, Y);
        }

        private static decimal PolygonArea(List<PointLatLng> Points)
        {
            //    // Add the first point to the end.
            //    int num_points = Points.Count;
            //    PointLatLng[] pts = new PointLatLng[num_points + 1];
            //    Points.CopyTo(pts, 0);
            //    pts[num_points] = Points[0];

            //    // Get the areas.
            decimal area = 0;
            //    for (int i = 0; i < num_points; i++)
            //    {
            //        area =
            //            (pts[i + 1].Lat - pts[i].Lat) *
            //            (pts[i + 1].Lng + pts[i].Lng) / 2;
            //    }

            //    // Return the result.
            return area;
            //}
        }

        //public class GeoMarkerGoogle : GMapMarker
        //{
        //    public GeoMarkerGoogle(PointLatLng p, GMap.NET.WindowsForms.Markers.GMarkerGoogleType type) : base(GeoMarkerGoogle);
        //    public readonly GMap.NET.WindowsForms.Markers.GMarkerGoogleType Type;

        //    public GMarkerGoogle(PointLatLng p, GMap.NET.WindowsForms.Markers.GMarkerGoogleType type);
        //    public GMarkerGoogle(PointLatLng p, Bitmap Bitmap);
        //    protected GMarkerGoogle(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);

        //    public override void Dispose();
        //    public void OnDeserialization(object sender);
        //    public override void OnRender(Graphics g);
        //}
    }
}





