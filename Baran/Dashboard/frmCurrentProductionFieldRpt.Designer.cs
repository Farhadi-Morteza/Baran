
namespace Baran.Dashboard
{
    partial class frmCurrentProductionFieldRpt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.grpControls = new Baran.Windows.Forms.GroupBox();
            this.label1 = new Baran.Windows.Forms.Label();
            this.cmbCrop = new Baran.Windows.Forms.UltraComboEditor();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Mpa = new Demo.WindowsForms.Map();
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpControls)).BeginInit();
            this.grpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCrop)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMaxMin
            // 
            this.btnMaxMin.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // grpButons
            // 
            this.grpButons.Location = new System.Drawing.Point(0, 630);
            this.grpButons.Size = new System.Drawing.Size(809, 75);
            // 
            // lblLine2
            // 
            this.lblLine2.Size = new System.Drawing.Size(807, 3);
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(809, 75);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(744, 9);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(438, 22);
            // 
            // lblMessage
            // 
            this.lblMessage.Text = "";
            // 
            // lblLine1
            // 
            this.lblLine1.Size = new System.Drawing.Size(807, 3);
            // 
            // grpMessage
            // 
            this.grpMessage.Size = new System.Drawing.Size(809, 30);
            // 
            // lblLine3
            // 
            this.lblLine3.Location = new System.Drawing.Point(1, 521);
            this.lblLine3.Size = new System.Drawing.Size(807, 3);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.tableLayoutPanel);
            this.grpMain.Controls.Add(this.grpControls);
            this.grpMain.Size = new System.Drawing.Size(809, 525);
            this.grpMain.Controls.SetChildIndex(this.lblLine3, 0);
            this.grpMain.Controls.SetChildIndex(this.grpControls, 0);
            this.grpMain.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            // 
            // grpControls
            // 
            this.grpControls.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grpControls.Controls.Add(this.cmbCrop);
            this.grpControls.Controls.Add(this.label1);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpControls.Location = new System.Drawing.Point(1, 0);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(807, 47);
            this.grpControls.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.label1.Appearance = appearance2;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(750, 16);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "محصول";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbCrop
            // 
            this.cmbCrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BorderColor = System.Drawing.Color.LightGray;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.cmbCrop.Appearance = appearance3;
            this.cmbCrop.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbCrop.BackColor = System.Drawing.Color.Transparent;
            this.cmbCrop.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbCrop.Editable = Baran.Windows.Forms.Editable.Editable;
            this.cmbCrop.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.cmbCrop.ItemAppearance = appearance4;
            this.cmbCrop.Location = new System.Drawing.Point(444, 12);
            this.cmbCrop.Name = "cmbCrop";
            this.cmbCrop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCrop.Size = new System.Drawing.Size(300, 22);
            this.cmbCrop.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.Mpa, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(1, 47);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(807, 474);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // Mpa
            // 
            this.Mpa.Bearing = 0F;
            this.Mpa.CanDragMap = true;
            this.Mpa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Mpa.EmptyTileColor = System.Drawing.Color.Navy;
            this.Mpa.GrayScaleMode = false;
            this.Mpa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Mpa.LevelsKeepInMemmory = 5;
            this.Mpa.Location = new System.Drawing.Point(3, 3);
            this.Mpa.MarkersEnabled = true;
            this.Mpa.MaxZoom = 20;
            this.Mpa.MinZoom = 1;
            this.Mpa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Mpa.Name = "Mpa";
            this.Mpa.NegativeMode = false;
            this.Mpa.PolygonsEnabled = true;
            this.Mpa.RetryLoadTile = 0;
            this.Mpa.RoutesEnabled = true;
            this.Mpa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Mpa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Mpa.ShowTileGridLines = false;
            this.Mpa.Size = new System.Drawing.Size(801, 231);
            this.Mpa.TabIndex = 0;
            this.Mpa.Zoom = 5D;
            // 
            // frmCurrentProductionFieldRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(809, 705);
            this.FormMessage = "";
            this.Name = "frmCurrentProductionFieldRpt";
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpControls)).EndInit();
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCrop)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Forms.GroupBox grpControls;
        private Windows.Forms.Label label1;
        private Windows.Forms.UltraComboEditor cmbCrop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Demo.WindowsForms.Map Mpa;
    }
}
