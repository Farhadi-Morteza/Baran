using Infragistics.Win;

namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinChart.UltraChart))]
    public class UltraChart : Infragistics.Win.UltraWinChart.UltraChart
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackColor = System.Drawing.Color.Transparent;

            this.Axis.X.Labels.FontColor =  BaranLibrary.GeneralProperties.BaseControlForeColor;
            this.Axis.X.Labels.Font = new System.Drawing.Font("Tahoma", 8.25F);
            
            this.Axis.X.Labels.SeriesLabels.FontColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            this.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Far;

            this.Axis.X.LineColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            this.Axis.X.ScrollScale.Visible = true;
            this.Axis.X.ScrollScale.Width = 10;
            this.Axis.X.Extent = 100;
            


            this.Axis.Y.Labels.FontColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            this.Axis.Y.Labels.Font = new System.Drawing.Font("Tahoma", 8.25F);

            this.Axis.Y.Labels.SeriesLabels.FontColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            this.Axis.Y.Labels.SeriesLabels.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Far;

            this.Axis.Y.LineColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            this.Axis.Y.ScrollScale.Visible = true;
            this.Axis.Y.ScrollScale.Width = 10;
            this.Axis.Y.Extent = 80;

        }

    }
}

