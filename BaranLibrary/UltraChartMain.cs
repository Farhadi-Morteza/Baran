
using Infragistics.Win;

namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinChart.UltraChart))]
    public class UltraChartMain : Infragistics.Win.UltraWinChart.UltraChart
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackColor = System.Drawing.Color.Transparent;

            this.Axis.X.Labels.FontColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            this.Axis.X.Labels.Font = new System.Drawing.Font("Tahoma", 8.25F);
            Axis.X.LineColor = BaranLibrary.GeneralProperties.BaseControlForeColor;


            this.Axis.Y.Labels.FontColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            this.Axis.Y.Labels.Font = new System.Drawing.Font("Tahoma", 8.25F);
            Axis.Y.LineColor = BaranLibrary.GeneralProperties.BaseControlForeColor;

            Legend.BorderColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            Legend.BackgroundColor = System.Drawing.Color.Transparent;
            Legend.FontColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            Legend.Visible = true;
            Legend.SpanPercentage = 10;

            EmptyChartText = string.Empty;
        }

    }
}


