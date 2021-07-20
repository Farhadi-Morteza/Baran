using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.DataGridView))]
    public class DataGridview : System.Windows.Forms.DataGridView
    {
        public DataGridview()
        {
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
           
            this.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundColor = System.Drawing.SystemColors.Control;

            this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            //this.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MultiSelect = false;
            this.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; ;
            this.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178))); ;
        }
    }
}
