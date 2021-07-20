namespace Baran.Source
{
    partial class frmBuildingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuildingsView));
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.grpDoc = new Baran.Windows.Forms.GroupBox();
            this.imageListView1 = new Manina.Windows.Forms.imageListView();
            this.lblCollection = new Baran.Windows.Forms.Label();
            this.lblDiscription = new Baran.Windows.Forms.Label();
            this.lblBuildingsCategory = new Baran.Windows.Forms.Label();
            this.lblArea = new Baran.Windows.Forms.Label();
            this.lblSubCollection = new Baran.Windows.Forms.Label();
            this.lblName = new Baran.Windows.Forms.Label();
            this.label6 = new Baran.Windows.Forms.Label();
            this.label5 = new Baran.Windows.Forms.Label();
            this.label4 = new Baran.Windows.Forms.Label();
            this.label3 = new Baran.Windows.Forms.Label();
            this.label2 = new Baran.Windows.Forms.Label();
            this.label1 = new Baran.Windows.Forms.Label();
            this.grpMap = new Baran.Windows.Forms.GroupBox();
            this.MainMap = new Demo.WindowsForms.Map();
            this.gprControls = new Baran.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grpDoc)).BeginInit();
            this.grpDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMap)).BeginInit();
            this.grpMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gprControls)).BeginInit();
            this.gprControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDoc
            // 
            this.grpDoc.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grpDoc.Controls.Add(this.imageListView1);
            this.grpDoc.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpDoc.Location = new System.Drawing.Point(841, 25);
            this.grpDoc.Name = "grpDoc";
            this.grpDoc.Size = new System.Drawing.Size(135, 497);
            this.grpDoc.TabIndex = 8;
            // 
            // imageListView1
            // 
            this.imageListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(94)))), ((int)(((byte)(112)))));
            this.imageListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageListView1.DefaultImage = ((System.Drawing.Image)(resources.GetObject("imageListView1.DefaultImage")));
            this.imageListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListView1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imageListView1.ErrorImage")));
            this.imageListView1.ForeColor = System.Drawing.Color.White;
            this.imageListView1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageListView1.Location = new System.Drawing.Point(1, 0);
            this.imageListView1.Name = "imageListView1";
            this.imageListView1.Size = new System.Drawing.Size(133, 496);
            this.imageListView1.TabIndex = 0;
            this.imageListView1.Text = "";
            this.imageListView1.ItemDoubleClick += new Manina.Windows.Forms.ItemDoubleClickEventHandler(this.imageListView1_ItemDoubleClick);
            // 
            // lblCollection
            // 
            this.lblCollection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance8.ForeColor = System.Drawing.Color.White;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.lblCollection.Appearance = appearance8;
            this.lblCollection.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCollection.Location = new System.Drawing.Point(587, 8);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCollection.Size = new System.Drawing.Size(271, 24);
            this.lblCollection.TabIndex = 22;
            this.lblCollection.Text = ": نام واحد";
            // 
            // lblDiscription
            // 
            this.lblDiscription.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Top";
            this.lblDiscription.Appearance = appearance5;
            this.lblDiscription.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDiscription.Location = new System.Drawing.Point(54, 54);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDiscription.Size = new System.Drawing.Size(834, 24);
            this.lblDiscription.TabIndex = 21;
            this.lblDiscription.Text = ": توضیحات";
            // 
            // lblBuildingsCategory
            // 
            this.lblBuildingsCategory.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblBuildingsCategory.Appearance = appearance1;
            this.lblBuildingsCategory.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBuildingsCategory.Location = new System.Drawing.Point(277, 32);
            this.lblBuildingsCategory.Name = "lblBuildingsCategory";
            this.lblBuildingsCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBuildingsCategory.Size = new System.Drawing.Size(259, 24);
            this.lblBuildingsCategory.TabIndex = 19;
            this.lblBuildingsCategory.Text = ": گروه";
            // 
            // lblArea
            // 
            this.lblArea.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Right";
            appearance7.TextVAlignAsString = "Middle";
            this.lblArea.Appearance = appearance7;
            this.lblArea.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblArea.Location = new System.Drawing.Point(53, 8);
            this.lblArea.Name = "lblArea";
            this.lblArea.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblArea.Size = new System.Drawing.Size(81, 24);
            this.lblArea.TabIndex = 20;
            this.lblArea.Text = ":مساحت متر مربع";
            // 
            // lblSubCollection
            // 
            this.lblSubCollection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblSubCollection.Appearance = appearance3;
            this.lblSubCollection.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSubCollection.Location = new System.Drawing.Point(587, 33);
            this.lblSubCollection.Name = "lblSubCollection";
            this.lblSubCollection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSubCollection.Size = new System.Drawing.Size(314, 24);
            this.lblSubCollection.TabIndex = 18;
            this.lblSubCollection.Text = ": نام واحد";
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance12.ForeColor = System.Drawing.Color.White;
            appearance12.TextHAlignAsString = "Right";
            appearance12.TextVAlignAsString = "Middle";
            this.lblName.Appearance = appearance12;
            this.lblName.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblName.Location = new System.Drawing.Point(283, 8);
            this.lblName.Name = "lblName";
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblName.Size = new System.Drawing.Size(259, 24);
            this.lblName.TabIndex = 17;
            this.lblName.Text = ": نام";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.label6.Appearance = appearance2;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(854, 8);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(95, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = ": نام کشت و صنعت";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.label5.Appearance = appearance4;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(894, 56);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(55, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = ": توضیحات";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.label4.Appearance = appearance6;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(542, 32);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(32, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = ": گروه";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.label3.Appearance = appearance9;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(140, 8);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = ":مساحت متر مربع";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance10.TextHAlignAsString = "Right";
            appearance10.TextVAlignAsString = "Middle";
            this.label2.Appearance = appearance10;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(900, 32);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(49, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = ": نام واحد";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            appearance11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.label1.Appearance = appearance11;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(542, 8);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(24, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = ": نام";
            // 
            // grpMap
            // 
            this.grpMap.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grpMap.Controls.Add(this.MainMap);
            this.grpMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMap.Location = new System.Drawing.Point(0, 25);
            this.grpMap.Name = "grpMap";
            this.grpMap.Size = new System.Drawing.Size(976, 583);
            this.grpMap.TabIndex = 10;
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(1, 0);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 18;
            this.MainMap.MinZoom = 1;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(974, 582);
            this.MainMap.TabIndex = 0;
            this.MainMap.Zoom = 5D;
            // 
            // gprControls
            // 
            this.gprControls.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.gprControls.Controls.Add(this.lblDiscription);
            this.gprControls.Controls.Add(this.lblCollection);
            this.gprControls.Controls.Add(this.label5);
            this.gprControls.Controls.Add(this.lblArea);
            this.gprControls.Controls.Add(this.lblBuildingsCategory);
            this.gprControls.Controls.Add(this.label6);
            this.gprControls.Controls.Add(this.label3);
            this.gprControls.Controls.Add(this.label2);
            this.gprControls.Controls.Add(this.lblName);
            this.gprControls.Controls.Add(this.label4);
            this.gprControls.Controls.Add(this.lblSubCollection);
            this.gprControls.Controls.Add(this.label1);
            this.gprControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gprControls.Location = new System.Drawing.Point(0, 522);
            this.gprControls.Name = "gprControls";
            this.gprControls.Size = new System.Drawing.Size(976, 86);
            this.gprControls.TabIndex = 23;
            // 
            // frmBuildingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(976, 611);
            this.Controls.Add(this.grpDoc);
            this.Controls.Add(this.gprControls);
            this.Controls.Add(this.grpMap);
            this.Name = "frmBuildingsView";
            this.Controls.SetChildIndex(this.grpMap, 0);
            this.Controls.SetChildIndex(this.gprControls, 0);
            this.Controls.SetChildIndex(this.grpDoc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grpDoc)).EndInit();
            this.grpDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMap)).EndInit();
            this.grpMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gprControls)).EndInit();
            this.gprControls.ResumeLayout(false);
            this.gprControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Forms.GroupBox grpDoc;
        private Windows.Forms.GroupBox grpMap;
        private Demo.WindowsForms.Map MainMap;
        private Manina.Windows.Forms.imageListView imageListView1;
        private Windows.Forms.Label label5;
        private Windows.Forms.Label label4;
        private Windows.Forms.Label label3;
        private Windows.Forms.Label label2;
        private Windows.Forms.Label label1;
        private Windows.Forms.Label label6;
        private Windows.Forms.Label lblCollection;
        private Windows.Forms.Label lblDiscription;
        private Windows.Forms.Label lblBuildingsCategory;
        private Windows.Forms.Label lblArea;
        private Windows.Forms.Label lblSubCollection;
        private Windows.Forms.Label lblName;
        private Windows.Forms.GroupBox gprControls;
    }
}
