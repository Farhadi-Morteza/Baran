namespace Baran.Base_Forms
{
    partial class frmProductionBase
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.grpHeader = new Baran.Windows.Forms.GroupBox();
            this.lblLine1 = new Baran.Windows.Forms.Label();
            this.grpMessage = new Baran.Windows.Forms.GroupBox();
            this.lblMessage = new Baran.Windows.Forms.Label();
            this.tmrTimer = new BaranLibrary.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpHeader
            // 
            this.grpHeader.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grpHeader.Controls.Add(this.lblLine1);
            this.grpHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpHeader.Location = new System.Drawing.Point(0, 0);
            this.grpHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(885, 85);
            this.grpHeader.TabIndex = 0;
            // 
            // lblLine1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(188)))), ((int)(((byte)(66)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblLine1.Appearance = appearance1;
            this.lblLine1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLine1.Location = new System.Drawing.Point(1, 80);
            this.lblLine1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLine1.Size = new System.Drawing.Size(883, 4);
            this.lblLine1.TabIndex = 0;
            // 
            // grpMessage
            // 
            this.grpMessage.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grpMessage.Controls.Add(this.lblMessage);
            this.grpMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMessage.Location = new System.Drawing.Point(0, 85);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(885, 30);
            this.grpMessage.TabIndex = 1;
            // 
            // lblMessage
            // 
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblMessage.Appearance = appearance2;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Location = new System.Drawing.Point(1, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMessage.Size = new System.Drawing.Size(883, 29);
            this.lblMessage.TabIndex = 0;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Enabled = true;
            this.tmrTimer.Interval = 30000;
            // 
            // frmProductionBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(885, 555);
            this.Controls.Add(this.grpMessage);
            this.Controls.Add(this.grpHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductionBase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production";
            this.Load += new System.EventHandler(this.frmProductionBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Forms.GroupBox grpHeader;
        private Windows.Forms.Label lblLine1;
        private Windows.Forms.GroupBox grpMessage;
        private Windows.Forms.Label lblMessage;
        private BaranLibrary.Timer tmrTimer;
    }
}