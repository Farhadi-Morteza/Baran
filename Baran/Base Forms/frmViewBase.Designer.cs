namespace Baran.Base_Forms
{
    partial class frmViewBase
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewBase));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.grpBorderTop = new Baran.Windows.Forms.GroupBox();
            this.btnClose = new Baran.Windows.Forms.Button();
            this.lblLineB = new Baran.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grpBorderTop)).BeginInit();
            this.grpBorderTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBorderTop
            // 
            appearance1.BackColor = System.Drawing.Color.LightGray;
            this.grpBorderTop.Appearance = appearance1;
            this.grpBorderTop.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grpBorderTop.Controls.Add(this.btnClose);
            this.grpBorderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBorderTop.Location = new System.Drawing.Point(0, 0);
            this.grpBorderTop.Margin = new System.Windows.Forms.Padding(0);
            this.grpBorderTop.Name = "grpBorderTop";
            this.grpBorderTop.Size = new System.Drawing.Size(832, 25);
            this.grpBorderTop.TabIndex = 6;
            this.grpBorderTop.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkGray;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(792, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(39, 24);
            this.btnClose.TabIndex = 54;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLineB
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblLineB.Appearance = appearance3;
            this.lblLineB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLineB.Location = new System.Drawing.Point(0, 535);
            this.lblLineB.Name = "lblLineB";
            this.lblLineB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLineB.Size = new System.Drawing.Size(832, 3);
            this.lblLineB.TabIndex = 7;
            // 
            // frmViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(94)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(832, 538);
            this.Controls.Add(this.lblLineB);
            this.Controls.Add(this.grpBorderTop);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmViewBase_FormClosed);
            this.Load += new System.EventHandler(this.frmViewBase_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmViewBase_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmViewBase_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grpBorderTop)).EndInit();
            this.grpBorderTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Forms.GroupBox grpBorderTop;
        private Windows.Forms.Button btnClose;
        private Windows.Forms.Label lblLineB;

    }
}