namespace Baran.Common
{
    partial class frmImageListView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageListView));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rotateCCWToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rotateCWToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.thumbnailsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.galleryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.paneToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.detailsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.columnsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.rendererToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.renderertoolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.thumbnailSizeToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.x48ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x96ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x120ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x150ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCacheToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAlltoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveSelectedItemstoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.imageListView1 = new Manina.Windows.Forms.imageListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanelStatus = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelMouse = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelFiles = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelImageType = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelImageSize = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelZoom = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).BeginInit();
            this.grpButons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelImageType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelImageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnChange
            // 
            this.btnChange.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnDoc
            // 
            this.btnDoc.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            //
            // 
            // btnCancle
            // 
            this.btnCancle.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // grpHeader
            // 
            this.grpHeader.Visible = false;
            // 
            // grpButons
            // 
            this.grpButons.Visible = false;
            // 
            // grpMessage
            // 
            this.grpMessage.Visible = false;
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.statusBar);
            this.grpMain.Controls.Add(this.imageListView1);
            this.grpMain.Controls.Add(this.toolStrip);
            this.grpMain.Controls.SetChildIndex(this.toolStrip, 0);
            this.grpMain.Controls.SetChildIndex(this.imageListView1, 0);
            this.grpMain.Controls.SetChildIndex(this.statusBar, 0);
            // 
            // lblCaption
            // 
            this.lblCaption.Text = "Image View";
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.removeToolStripButton,
            this.removeAllToolStripButton,
            this.toolStripSeparator1,
            this.rotateCCWToolStripButton,
            this.rotateCWToolStripButton,
            this.toolStripSeparator5,
            this.thumbnailsToolStripButton,
            this.galleryToolStripButton,
            this.paneToolStripButton,
            this.detailsToolStripButton,
            this.toolStripSeparator2,
            this.columnsToolStripButton,
            this.toolStripSeparator4,
            this.rendererToolStripLabel,
            this.renderertoolStripComboBox,
            this.toolStripSeparator3,
            this.thumbnailSizeToolStripDropDownButton,
            this.clearCacheToolStripButton,
            this.SaveAlltoolStripButton,
            this.SaveSelectedItemstoolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(1, 29);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip.Size = new System.Drawing.Size(851, 29);
            this.toolStrip.TabIndex = 53;
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.addToolStripButton.Text = "Add Files...";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // removeToolStripButton
            // 
            this.removeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripButton.Image")));
            this.removeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolStripButton.Name = "removeToolStripButton";
            this.removeToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.removeToolStripButton.Text = "Remove Selected Files";
            this.removeToolStripButton.Click += new System.EventHandler(this.removeToolStripButton_Click);
            // 
            // removeAllToolStripButton
            // 
            this.removeAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeAllToolStripButton.Image")));
            this.removeAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeAllToolStripButton.Name = "removeAllToolStripButton";
            this.removeAllToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.removeAllToolStripButton.Text = "Remove All Files";
            this.removeAllToolStripButton.Click += new System.EventHandler(this.removeAllToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // rotateCCWToolStripButton
            // 
            this.rotateCCWToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateCCWToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateCCWToolStripButton.Image")));
            this.rotateCCWToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateCCWToolStripButton.Name = "rotateCCWToolStripButton";
            this.rotateCCWToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.rotateCCWToolStripButton.Text = "Rotate Counter-clockwise";
            this.rotateCCWToolStripButton.Click += new System.EventHandler(this.rotateCCWToolStripButton_Click);
            // 
            // rotateCWToolStripButton
            // 
            this.rotateCWToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateCWToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateCWToolStripButton.Image")));
            this.rotateCWToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateCWToolStripButton.Name = "rotateCWToolStripButton";
            this.rotateCWToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.rotateCWToolStripButton.Text = "Rotate Clockwise";
            this.rotateCWToolStripButton.Click += new System.EventHandler(this.rotateCWToolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // thumbnailsToolStripButton
            // 
            this.thumbnailsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.thumbnailsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("thumbnailsToolStripButton.Image")));
            this.thumbnailsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.thumbnailsToolStripButton.Name = "thumbnailsToolStripButton";
            this.thumbnailsToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.thumbnailsToolStripButton.Text = "Thumbnails";
            this.thumbnailsToolStripButton.Click += new System.EventHandler(this.thumbnailsToolStripButton_Click);
            // 
            // galleryToolStripButton
            // 
            this.galleryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.galleryToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("galleryToolStripButton.Image")));
            this.galleryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.galleryToolStripButton.Name = "galleryToolStripButton";
            this.galleryToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.galleryToolStripButton.Text = "Gallery";
            this.galleryToolStripButton.Click += new System.EventHandler(this.galleryToolStripButton_Click);
            // 
            // paneToolStripButton
            // 
            this.paneToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.paneToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("paneToolStripButton.Image")));
            this.paneToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paneToolStripButton.Name = "paneToolStripButton";
            this.paneToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.paneToolStripButton.Text = "Pane";
            this.paneToolStripButton.Click += new System.EventHandler(this.paneToolStripButton_Click);
            // 
            // detailsToolStripButton
            // 
            this.detailsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.detailsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("detailsToolStripButton.Image")));
            this.detailsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.detailsToolStripButton.Name = "detailsToolStripButton";
            this.detailsToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.detailsToolStripButton.Text = "Details";
            this.detailsToolStripButton.Click += new System.EventHandler(this.detailsToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // columnsToolStripButton
            // 
            this.columnsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.columnsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("columnsToolStripButton.Image")));
            this.columnsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.columnsToolStripButton.Name = "columnsToolStripButton";
            this.columnsToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.columnsToolStripButton.Text = "Choose Columns...";
            this.columnsToolStripButton.Click += new System.EventHandler(this.columnsToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // rendererToolStripLabel
            // 
            this.rendererToolStripLabel.ForeColor = System.Drawing.Color.White;
            this.rendererToolStripLabel.Name = "rendererToolStripLabel";
            this.rendererToolStripLabel.Size = new System.Drawing.Size(77, 26);
            this.rendererToolStripLabel.Text = "Renderer:";
            // 
            // renderertoolStripComboBox
            // 
            this.renderertoolStripComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(94)))), ((int)(((byte)(112)))));
            this.renderertoolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.renderertoolStripComboBox.ForeColor = System.Drawing.Color.White;
            this.renderertoolStripComboBox.Name = "renderertoolStripComboBox";
            this.renderertoolStripComboBox.Size = new System.Drawing.Size(121, 29);
            this.renderertoolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.renderertoolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // thumbnailSizeToolStripDropDownButton
            // 
            this.thumbnailSizeToolStripDropDownButton.BackColor = System.Drawing.Color.Transparent;
            this.thumbnailSizeToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.thumbnailSizeToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x48ToolStripMenuItem,
            this.x96ToolStripMenuItem,
            this.x120ToolStripMenuItem,
            this.x150ToolStripMenuItem,
            this.x200ToolStripMenuItem});
            this.thumbnailSizeToolStripDropDownButton.ForeColor = System.Drawing.Color.White;
            this.thumbnailSizeToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("thumbnailSizeToolStripDropDownButton.Image")));
            this.thumbnailSizeToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.thumbnailSizeToolStripDropDownButton.Name = "thumbnailSizeToolStripDropDownButton";
            this.thumbnailSizeToolStripDropDownButton.Size = new System.Drawing.Size(129, 26);
            this.thumbnailSizeToolStripDropDownButton.Text = "Thumbnail Size";
            // 
            // x48ToolStripMenuItem
            // 
            this.x48ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.x48ToolStripMenuItem.Name = "x48ToolStripMenuItem";
            this.x48ToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.x48ToolStripMenuItem.Text = "48 x 48";
            this.x48ToolStripMenuItem.Click += new System.EventHandler(this.x48ToolStripMenuItem_Click);
            // 
            // x96ToolStripMenuItem
            // 
            this.x96ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.x96ToolStripMenuItem.Name = "x96ToolStripMenuItem";
            this.x96ToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.x96ToolStripMenuItem.Text = "96 x 96";
            this.x96ToolStripMenuItem.Click += new System.EventHandler(this.x96ToolStripMenuItem_Click);
            // 
            // x120ToolStripMenuItem
            // 
            this.x120ToolStripMenuItem.Name = "x120ToolStripMenuItem";
            this.x120ToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.x120ToolStripMenuItem.Text = "120 x120";
            this.x120ToolStripMenuItem.Click += new System.EventHandler(this.x120ToolStripMenuItem_Click);
            // 
            // x150ToolStripMenuItem
            // 
            this.x150ToolStripMenuItem.Name = "x150ToolStripMenuItem";
            this.x150ToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.x150ToolStripMenuItem.Text = "150 x150";
            this.x150ToolStripMenuItem.Click += new System.EventHandler(this.x150ToolStripMenuItem_Click);
            // 
            // x200ToolStripMenuItem
            // 
            this.x200ToolStripMenuItem.Name = "x200ToolStripMenuItem";
            this.x200ToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.x200ToolStripMenuItem.Text = "200 x 200";
            this.x200ToolStripMenuItem.Click += new System.EventHandler(this.x200ToolStripMenuItem_Click);
            // 
            // clearCacheToolStripButton
            // 
            this.clearCacheToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearCacheToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearCacheToolStripButton.Image")));
            this.clearCacheToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearCacheToolStripButton.Name = "clearCacheToolStripButton";
            this.clearCacheToolStripButton.Size = new System.Drawing.Size(23, 26);
            this.clearCacheToolStripButton.Text = "Clear Thumbnail Cache";
            this.clearCacheToolStripButton.Click += new System.EventHandler(this.clearCacheToolStripButton_Click);
            // 
            // SaveAlltoolStripButton
            // 
            this.SaveAlltoolStripButton.ForeColor = System.Drawing.Color.White;
            this.SaveAlltoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveAlltoolStripButton.Image")));
            this.SaveAlltoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAlltoolStripButton.Name = "SaveAlltoolStripButton";
            this.SaveAlltoolStripButton.Size = new System.Drawing.Size(139, 26);
            this.SaveAlltoolStripButton.Text = "Save All Images";
            this.SaveAlltoolStripButton.Click += new System.EventHandler(this.SaveAlltoolStripButton_Click);
            // 
            // SaveSelectedItemstoolStripButton
            // 
            this.SaveSelectedItemstoolStripButton.ForeColor = System.Drawing.Color.White;
            this.SaveSelectedItemstoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveSelectedItemstoolStripButton.Image")));
            this.SaveSelectedItemstoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveSelectedItemstoolStripButton.Name = "SaveSelectedItemstoolStripButton";
            this.SaveSelectedItemstoolStripButton.Size = new System.Drawing.Size(179, 25);
            this.SaveSelectedItemstoolStripButton.Text = "Save Selected Images";
            this.SaveSelectedItemstoolStripButton.Click += new System.EventHandler(this.SaveSelectedItemstoolStripButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = resources.GetString("openFileDialog.Filter");
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.ShowReadOnly = true;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.LightGray;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 494);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip.Size = new System.Drawing.Size(853, 26);
            this.statusStrip.TabIndex = 6;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(53, 21);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 2000;
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
            this.imageListView1.Location = new System.Drawing.Point(1, 58);
            this.imageListView1.Name = "imageListView1";
            this.imageListView1.Size = new System.Drawing.Size(851, 329);
            this.imageListView1.TabIndex = 54;
            this.imageListView1.Text = "";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 30);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(1, 367);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanelStatus,
            this.statusBarPanelMouse,
            this.statusBarPanelFiles,
            this.statusBarPanelImageType,
            this.statusBarPanelImageSize,
            this.statusBarPanelZoom});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(851, 20);
            this.statusBar.TabIndex = 55;
            this.statusBar.Text = "Ready";
            // 
            // statusBarPanelStatus
            // 
            this.statusBarPanelStatus.Name = "statusBarPanelStatus";
            this.statusBarPanelStatus.Text = "Ready";
            this.statusBarPanelStatus.Width = 10;
            // 
            // statusBarPanelMouse
            // 
            this.statusBarPanelMouse.Name = "statusBarPanelMouse";
            // 
            // statusBarPanelFiles
            // 
            this.statusBarPanelFiles.Name = "statusBarPanelFiles";
            this.statusBarPanelFiles.Text = "-no file(s)-";
            // 
            // statusBarPanelImageType
            // 
            this.statusBarPanelImageType.Name = "statusBarPanelImageType";
            this.statusBarPanelImageType.Text = "-none-";
            this.statusBarPanelImageType.Width = 200;
            // 
            // statusBarPanelImageSize
            // 
            this.statusBarPanelImageSize.Name = "statusBarPanelImageSize";
            // 
            // statusBarPanelZoom
            // 
            this.statusBarPanelZoom.Name = "statusBarPanelZoom";
            // 
            // frmImageListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(853, 587);
            this.Controls.Add(this.statusStrip);
            this.FormCaption = "Image View";
            this.Name = "frmImageListView";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmImageListView_Paint);
            this.Controls.SetChildIndex(this.grpButons, 0);
            this.Controls.SetChildIndex(this.grpHeader, 0);
            this.Controls.SetChildIndex(this.grpMessage, 0);
            this.Controls.SetChildIndex(this.grpMain, 0);
            this.Controls.SetChildIndex(this.statusStrip, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).EndInit();
            this.grpButons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelImageType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelImageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.ToolStripButton removeAllToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton rotateCCWToolStripButton;
        private System.Windows.Forms.ToolStripButton rotateCWToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton thumbnailsToolStripButton;
        private System.Windows.Forms.ToolStripButton galleryToolStripButton;
        private System.Windows.Forms.ToolStripButton paneToolStripButton;
        private System.Windows.Forms.ToolStripButton detailsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton columnsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel rendererToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox renderertoolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton thumbnailSizeToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem x48ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x96ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x120ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x150ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton clearCacheToolStripButton;
        private Manina.Windows.Forms.imageListView imageListView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel statusBarPanelStatus;
        private System.Windows.Forms.StatusBarPanel statusBarPanelMouse;
        private System.Windows.Forms.StatusBarPanel statusBarPanelFiles;
        private System.Windows.Forms.StatusBarPanel statusBarPanelImageType;
        private System.Windows.Forms.StatusBarPanel statusBarPanelImageSize;
        private System.Windows.Forms.StatusBarPanel statusBarPanelZoom;
        private System.Windows.Forms.ToolStripButton SaveAlltoolStripButton;
        private System.Windows.Forms.ToolStripButton SaveSelectedItemstoolStripButton;
    }
}
