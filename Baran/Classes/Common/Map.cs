
namespace Demo.WindowsForms
{
    using System.Windows.Forms;
    using System.Drawing;
    using System;
    using System.Globalization;
    using GMap.NET.WindowsForms;
    using GMap.NET.MapProviders;
    using GMap.NET;

    /// <summary>
    /// custom map of GMapControl
    /// </summary>
    public class Map : GMapControl
    {
        public Map()
        {
            //if (!GMapControl.IsDesignerHosted)
            //{
            //    this.Overlays.Add(routes)
            //}
        }




        //#region Variables

        //internal readonly GMapOverlay objects = new GMapOverlay("objects");
        //internal readonly GMapOverlay routes = new GMapOverlay("routes");
        //internal readonly GMapOverlay polygons = new GMapOverlay("polygons");

        //#endregion

        public long ElapsedMilliseconds;

#if DEBUG
        private int counter;
        readonly Font DebugFont = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Regular);
        readonly Font DebugFontSmall = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
        DateTime start;
        DateTime end;
        int delta;

        protected override void OnPaint(PaintEventArgs e)
        {
            start = DateTime.Now;

            base.OnPaint(e);

            end = DateTime.Now;
            delta = (int)(end - start).TotalMilliseconds;
        }

        protected override void OnPaintOverlays(System.Drawing.Graphics g)
        {
            base.OnPaintOverlays(g);

            ShowCenter = false;

            //g.DrawString(string.Format(CultureInfo.InvariantCulture, "{0:0.0}", Zoom) + "z, " + MapProvider + ", refresh: " + counter++ + ", load: " + ElapsedMilliseconds + "ms, render: " + delta + "ms", DebugFont, Brushes.Blue, DebugFont.Height, DebugFont.Height + 20);

            //g.DrawString(ViewAreaPixel.Location.ToString(), DebugFontSmall, Brushes.Blue, DebugFontSmall.Height, DebugFontSmall.Height);

            //string lb = ViewAreaPixel.LeftBottom.ToString();
            //var lbs = g.MeasureString(lb, DebugFontSmall);
            //g.DrawString(lb, DebugFontSmall, Brushes.Blue, DebugFontSmall.Height, Height - DebugFontSmall.Height * 2);

            //string rb = ViewAreaPixel.RightBottom.ToString();
            //var rbs = g.MeasureString(rb, DebugFontSmall);
            //g.DrawString(rb, DebugFontSmall, Brushes.Blue, Width - rbs.Width - DebugFontSmall.Height, Height - DebugFontSmall.Height * 2);

            //string rt = ViewAreaPixel.RightTop.ToString();
            //var rts = g.MeasureString(rb, DebugFontSmall);
            //g.DrawString(rt, DebugFontSmall, Brushes.Blue, Width - rts.Width - DebugFontSmall.Height, DebugFontSmall.Height);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //// add your custom map db provider
            //GMap.NET.CacheProviders.MySQLPureImageCache ch = new GMap.NET.CacheProviders.MySQLPureImageCache();
            //ch.ConnectionString = @"server=sql2008;User Id=trolis;Persist Security Info=True;database=gmapnetcache;password=trolis;";
            //MainMap.Manager.SecondaryCache = ch;

            CacheLocation = System.Windows.Forms.Application.StartupPath + @"\Map\";
            MapProvider = BingHybridMapProvider.Instance;//GoogleHybridMapProvider.Instance;//GoogleSatelliteMapProvider.Instance;// BingSatelliteMapProvider.Instance;//GoogleHybridMapProvider.Instance;//    GoogleHybridMapProvider.Instance;// 
            Manager.Mode = AccessMode.ServerAndCache;//.CacheOnly; ////
            String mapPath = Application.StartupPath + @"\Map\TileDBv5\en\Data.gmdb";//This is the 2G package, let the young man make it all night! ! ! !


            //GMap.NET.GMaps.Instance.ImportFromGMDB(mapPath);
            Position = new PointLatLng(32.843888, 51.967501);
            MinZoom = 1;
            MaxZoom = 20;
            Zoom = 5;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (Focused)
            {
                System.Globalization.CultureInfo _enCultureInfo = new System.Globalization.CultureInfo("en-US", false);
                System.Windows.Forms.InputLanguage.CurrentInputLanguage =
                    System.Windows.Forms.InputLanguage.FromCulture(_enCultureInfo);
                if (e.KeyChar == '+')
                {
                    Zoom = ((int)Zoom) + 1;
                }
                else if (e.KeyChar == '-')
                {
                    Zoom = ((int)(Zoom + 0.99)) - 1;
                }
                else if (e.KeyChar == 'a')
                {
                    Bearing--;
                }
                else if (e.KeyChar == 'z')
                {
                    Bearing++;
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            int offset = -22;

            if (e.KeyCode == Keys.Left)
            {
                Offset(-offset, 0);
            }
            else if (e.KeyCode == Keys.Right)
            {
                Offset(offset, 0);
            }
            else if (e.KeyCode == Keys.Up)
            {
                Offset(0, -offset);
            }
            else if (e.KeyCode == Keys.Down)
            {
                Offset(0, offset);
            }
            
        }
#endif
    }
}

