namespace BaranLibrary
{
    partial class PersianDateEntry
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtYear = new Baran.Windows.Forms.TextBox();
            this.txtMonth = new Baran.Windows.Forms.TextBox();
            this.txtDay = new Baran.Windows.Forms.TextBox();
            this.lblYear = new Baran.Windows.Forms.Label();
            this.lblMonth = new Baran.Windows.Forms.Label();
            this.lblDay = new Baran.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(3, 3);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtYear.Size = new System.Drawing.Size(34, 20);
            this.txtYear.TabIndex = 5;
            this.txtYear.UnformattedText = null;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            this.txtYear.Leave += new System.EventHandler(this.txtYear_Leave);
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(79, 3);
            this.txtMonth.MaxLength = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMonth.Size = new System.Drawing.Size(22, 20);
            this.txtMonth.TabIndex = 4;
            this.txtMonth.UnformattedText = null;
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(138, 3);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDay.Size = new System.Drawing.Size(26, 20);
            this.txtDay.TabIndex = 3;
            this.txtDay.UnformattedText = null;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(43, 6);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(30, 13);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "سال:";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(107, 6);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(25, 13);
            this.lblMonth.TabIndex = 1;
            this.lblMonth.Text = "ماه:";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(170, 6);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(26, 13);
            this.lblDay.TabIndex = 0;
            this.lblDay.Text = "روز:";
            // 
            // PersianDateEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblDay);
            this.Name = "PersianDateEntry";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(195, 24);
            this.Load += new System.EventHandler(this.PersianDateEntry_Load);
            this.Leave += new System.EventHandler(this.PersianDateEntry_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Baran.Windows.Forms.Label lblDay;
        private Baran.Windows.Forms.Label lblMonth;
        private Baran.Windows.Forms.Label lblYear;
        private Baran.Windows.Forms.TextBox txtDay;
        private Baran.Windows.Forms.TextBox txtMonth;
        private Baran.Windows.Forms.TextBox txtYear;
    }
}
