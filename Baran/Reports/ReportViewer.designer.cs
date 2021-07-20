namespace Baran.Reports
{
    partial class ReportViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewer));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.miniToolStrip = new Baran.Windows.Forms.ToolStrip();
            this.tlsButtonExport = new System.Windows.Forms.ToolStripButton();
            this.tlsButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.tlsButtonFirstPage = new System.Windows.Forms.ToolStripButton();
            this.tlsButtonPreviousPage = new System.Windows.Forms.ToolStripButton();
            this.tlsButtonNextPage = new System.Windows.Forms.ToolStripButton();
            this.tlsButtonLastPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsButtonZoom = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.grpHeader = new Baran.Windows.Forms.GroupBox();
            this.lblMessage = new Baran.Windows.Forms.Label();
            this.lblCaption = new Baran.Windows.Forms.Label();
            this.pictureBox1 = new Baran.Windows.Forms.PictureBox();
            this.grpMain = new Baran.Windows.Forms.GroupBox();
            this.tlsReportViewer = new Baran.Windows.Forms.ToolStrip();
            //this.crvReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            this.tlsReportViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(251, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(254, 25);
            this.miniToolStrip.TabIndex = 1;
            this.miniToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.miniToolStrip_ItemClicked);
            // 
            // tlsButtonExport
            // 
            this.tlsButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("tlsButtonExport.Image")));
            this.tlsButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsButtonExport.Name = "tlsButtonExport";
            this.tlsButtonExport.Size = new System.Drawing.Size(58, 24);
            this.tlsButtonExport.Text = "ذخیره";
            this.tlsButtonExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tlsButtonExport.Click += new System.EventHandler(this.tlsButtonExport_Click);
            // 
            // tlsButtonPrint
            // 
            this.tlsButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("tlsButtonPrint.Image")));
            this.tlsButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsButtonPrint.Name = "tlsButtonPrint";
            this.tlsButtonPrint.Size = new System.Drawing.Size(57, 24);
            this.tlsButtonPrint.Text = "پرینت";
            this.tlsButtonPrint.Click += new System.EventHandler(this.tlsButtonPrint_Click);
            // 
            // tlsButtonFirstPage
            // 
            this.tlsButtonFirstPage.Image = ((System.Drawing.Image)(resources.GetObject("tlsButtonFirstPage.Image")));
            this.tlsButtonFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsButtonFirstPage.Name = "tlsButtonFirstPage";
            this.tlsButtonFirstPage.Size = new System.Drawing.Size(77, 24);
            this.tlsButtonFirstPage.Text = "صفحه اول";
            this.tlsButtonFirstPage.Click += new System.EventHandler(this.tlsButtonFirstPage_Click);
            // 
            // tlsButtonPreviousPage
            // 
            this.tlsButtonPreviousPage.Image = ((System.Drawing.Image)(resources.GetObject("tlsButtonPreviousPage.Image")));
            this.tlsButtonPreviousPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsButtonPreviousPage.Name = "tlsButtonPreviousPage";
            this.tlsButtonPreviousPage.Size = new System.Drawing.Size(77, 24);
            this.tlsButtonPreviousPage.Text = "صفحه قبل";
            this.tlsButtonPreviousPage.Click += new System.EventHandler(this.tlsButtonPreviousPage_Click);
            // 
            // tlsButtonNextPage
            // 
            this.tlsButtonNextPage.Image = ((System.Drawing.Image)(resources.GetObject("tlsButtonNextPage.Image")));
            this.tlsButtonNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsButtonNextPage.Name = "tlsButtonNextPage";
            this.tlsButtonNextPage.Size = new System.Drawing.Size(76, 24);
            this.tlsButtonNextPage.Text = "صفحه بعد";
            this.tlsButtonNextPage.Click += new System.EventHandler(this.tlsButtonNextPage_Click);
            // 
            // tlsButtonLastPage
            // 
            this.tlsButtonLastPage.Image = ((System.Drawing.Image)(resources.GetObject("tlsButtonLastPage.Image")));
            this.tlsButtonLastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsButtonLastPage.Name = "tlsButtonLastPage";
            this.tlsButtonLastPage.Size = new System.Drawing.Size(78, 24);
            this.tlsButtonLastPage.Text = "صفحه آخر";
            this.tlsButtonLastPage.Click += new System.EventHandler(this.tlsButtonLastPage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tlsButtonZoom
            // 
            this.tlsButtonZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsButtonZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.tlsButtonZoom.Image = ((System.Drawing.Image)(resources.GetObject("tlsButtonZoom.Image")));
            this.tlsButtonZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsButtonZoom.Name = "tlsButtonZoom";
            this.tlsButtonZoom.Size = new System.Drawing.Size(36, 24);
            this.tlsButtonZoom.Text = "Zoom";
            this.tlsButtonZoom.TextChanged += new System.EventHandler(this.tlsSplitButtonZoom_TextChanged);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem2.Text = "400%";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem1.Text = "300%";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem3.Text = "200%";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem4.Text = "150%";
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Enabled = false;
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Size = new System.Drawing.Size(699, 469);
            // 
            // grpHeader
            // 
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grpHeader.Appearance = appearance3;
            this.grpHeader.Controls.Add(this.lblMessage);
            this.grpHeader.Controls.Add(this.lblCaption);
            this.grpHeader.Controls.Add(this.pictureBox1);
            this.grpHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpHeader.Location = new System.Drawing.Point(0, 0);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpHeader.Size = new System.Drawing.Size(699, 65);
            this.grpHeader.TabIndex = 12;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackColor2 = System.Drawing.Color.Transparent;
            appearance2.FontData.BoldAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.MediumOrchid;
            this.lblMessage.Appearance = appearance2;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMessage.Location = new System.Drawing.Point(12, 39);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(552, 20);
            this.lblMessage.TabIndex = 10;
            // 
            // lblCaption
            // 
            this.lblCaption.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblCaption.Appearance = appearance1;
            this.lblCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCaption.Location = new System.Drawing.Point(347, 23);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCaption.Size = new System.Drawing.Size(280, 18);
            this.lblCaption.TabIndex = 6;
            this.lblCaption.Text = "Caption";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(633, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.tlsReportViewer);
            //this.grpMain.Controls.Add(this.crvReportViewer);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 65);
            this.grpMain.Name = "grpMain";
            this.grpMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpMain.Size = new System.Drawing.Size(699, 454);
            this.grpMain.TabIndex = 13;
            // 
            // tlsReportViewer
            // 
            this.tlsReportViewer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlsReportViewer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsReportViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsButtonExport,
            this.tlsButtonPrint,
            this.tlsButtonFirstPage,
            this.tlsButtonPreviousPage,
            this.tlsButtonNextPage,
            this.tlsButtonLastPage,
            this.toolStripSeparator1,
            this.tlsButtonZoom});
            this.tlsReportViewer.Location = new System.Drawing.Point(3, 424);
            this.tlsReportViewer.Name = "tlsReportViewer";
            this.tlsReportViewer.Size = new System.Drawing.Size(693, 27);
            this.tlsReportViewer.TabIndex = 1;
            // 
            // crvReportViewer
            // 
            //this.crvReportViewer.ActiveViewIndex = -1;
            //this.crvReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.crvReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            //this.crvReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.crvReportViewer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            //this.crvReportViewer.Location = new System.Drawing.Point(3, 0);
            //this.crvReportViewer.Name = "crvReportViewer";
            //this.crvReportViewer.ShowCloseButton = false;
            //this.crvReportViewer.ShowGroupTreeButton = false;
            //this.crvReportViewer.ShowRefreshButton = false;
            //this.crvReportViewer.Size = new System.Drawing.Size(693, 451);
            //this.crvReportViewer.TabIndex = 0;
            //this.crvReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 519);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.grpHeader);
            this.Name = "ReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.tlsReportViewer.ResumeLayout(false);
            this.tlsReportViewer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripButton tlsButtonExport;
        private System.Windows.Forms.ToolStripButton tlsButtonPrint;
        private System.Windows.Forms.ToolStripButton tlsButtonFirstPage;
        private System.Windows.Forms.ToolStripButton tlsButtonPreviousPage;
        private System.Windows.Forms.ToolStripButton tlsButtonNextPage;
        private System.Windows.Forms.ToolStripButton tlsButtonLastPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton tlsButtonZoom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        public Windows.Forms.GroupBox grpHeader;
        public Windows.Forms.Label lblMessage;
        protected Windows.Forms.Label lblCaption;
        public Windows.Forms.PictureBox pictureBox1;
        protected Windows.Forms.GroupBox grpMain;
        private Windows.Forms.ToolStrip tlsReportViewer;
        //private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReportViewer;

    }
}