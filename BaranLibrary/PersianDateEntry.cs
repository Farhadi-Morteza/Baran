using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaranLibrary
{
    public partial class PersianDateEntry : UserControl
    {
        private bool readOnly = false;
        public bool ReadOnly
        {
            get
            {
                return readOnly;
            }
            set
            {
                readOnly = value;
            }
        }
        public void Clear()
        {
            txtDay.Text = string.Empty;
            txtMonth.Text = string.Empty;
            txtYear.Text = string.Empty;
        }
        private DateTime? enteredDate;
        public DateTime? EnteredDate
        {
            get
            {
                return enteredDate;
            }
            set
            {
                enteredDate = value;
            }
        }
        public PersianDateEntry()
        {
            InitializeComponent();
            if (ReadOnly == true)
            {
                txtDay.ReadOnly = true;
                txtMonth.ReadOnly = true;
                txtYear.ReadOnly = true;
            }
            txtDay.Text = FarsiLibrary.Utils.PersianDate.Now.Day.ToString();
            txtMonth.Text = FarsiLibrary.Utils.PersianDate.Now.Month.ToString();
            txtYear.Text = FarsiLibrary.Utils.PersianDate.Now.Year.ToString();
        }
        public void SetasReadOnly()
        {
            txtDay.ReadOnly = true;
            txtMonth.ReadOnly = true;
            txtYear.ReadOnly = true;
            ReadOnly = true;
        }
        public void SetasEditable()
        {
            txtDay.ReadOnly = false;
            txtMonth.ReadOnly = false;
            txtYear.ReadOnly = false;
            ReadOnly = false;
        }
        public int? Day
        {
            get
            {
                return int.Parse(txtDay.Text);
            }
            set
            {
                txtDay.Text = value.ToString();
            }
        }
        public int? Month
        {
            get
            {
                return int.Parse(txtMonth.Text);
            }
            set
            {
                txtMonth.Text = value.ToString();
            }
        }
        public int? Year
        {
            get
            {
                return int.Parse(txtYear.Text);
            }
            set
            {
                txtYear.Text = value.ToString();
            }
        }
        private void PersianDateEntry_Load(object sender, EventArgs e)
        {

        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtYear_Leave(object sender, EventArgs e)
        {
            //int day;
            //int month;
            //int year;
            //int intYearAdjuster;
            //if (txtDay.Text == string.Empty)
            //{
            //    MessageBox.Show(BaranLibraryResources.txtDayIsEmpty);
            //    txtDay.Focus();
            //    return;
            //}
            //if (txtMonth.Text == string.Empty)
            //{
            //    MessageBox.Show(BaranLibraryResources.txtMonthIsEmpty);
            //    txtMonth.Focus();
            //    return;
            //}
            //if (txtYear.Text == string.Empty)
            //{
            //    MessageBox.Show(BaranLibraryResources.txtYearIsEmpty);
            //    txtYear.Focus();
            //    return;
            //}
            //try
            //{
            //   day = int.Parse(txtDay.Text.Trim());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(BaranLibraryResources.txtDayIsNotInteger);
            //    txtDay.Focus();
            //    return;
            //}
            //try
            //{
            //    month = int.Parse(txtMonth.Text.Trim());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(BaranLibraryResources.txtMonthIsNotInteger);
            //    txtMonth.Focus();
            //    return;
            //}
            //try
            //{
            //    year = int.Parse(txtYear.Text.Trim());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(BaranLibraryResources.txtYearIsNotInteger);
            //    txtYear.Focus();
            //    return;
            //}
            //if (day < 1 || day > 31)
            //{
            //    MessageBox.Show("روز باید عددی بین یک تا سی ویک باشد");
            //    txtDay.Focus();
            //    return;
            //}
            //if (month < 1 || month > 12)
            //{
            //    MessageBox.Show("ماه باید عددی بین یک تا دوازده باشد");
            //    txtMonth.Focus();
            //    return;
            //}
            //if (year < 1 || year > 9999)
            //{
            //    MessageBox.Show("سال را اشتباه وترد کرده اید");
            //    txtYear.Focus();
            //    return;
            //}
            //else if (year >=00 && year <= 99)
            //{
            //    FarsiLibrary.Utils.PersianDate dteTemp = FarsiLibrary.Utils.PersianDate.Now;
            //    intYearAdjuster = dteTemp.Year;
            //    intYearAdjuster = ((int)(intYearAdjuster / 100));
            //    intYearAdjuster = intYearAdjuster * 100;
            //    intYearAdjuster += year;
            //    year = intYearAdjuster;
            //}
            //FarsiLibrary.Utils.PersianDate enterdPersianDate = new FarsiLibrary.Utils.PersianDate(year, month, day);
            //EnteredDate = FarsiLibrary.Utils.PersianDateConverter.ToGregorianDateTime(enterdPersianDate);
        }
        private void PersianDateEntry_Leave(object sender, EventArgs e)
        {
            int day;
            int month;
            int year;
            int intYearAdjuster;
            if (txtDay.Text == string.Empty)
            {
                MessageBox.Show(BaranLibraryResources.txtDayIsEmpty);
                txtDay.Focus();
                return;
            }
            if (txtMonth.Text == string.Empty)
            {
                MessageBox.Show(BaranLibraryResources.txtMonthIsEmpty);
                txtMonth.Focus();
                return;
            }
            if (txtYear.Text == string.Empty)
            {
                MessageBox.Show(BaranLibraryResources.txtYearIsEmpty);
                txtYear.Focus();
                return;
            }
            try
            {
                day = int.Parse(txtDay.Text.Trim());
            }
            catch
            {
                MessageBox.Show(BaranLibraryResources.txtDayIsNotInteger);
                txtDay.Focus();
                return;
            }
            try
            {
                month = int.Parse(txtMonth.Text.Trim());
            }
            catch
            {
                MessageBox.Show(BaranLibraryResources.txtMonthIsNotInteger);
                txtMonth.Focus();
                return;
            }
            try
            {
                year = int.Parse(txtYear.Text.Trim());
            }
            catch
            {
                MessageBox.Show(BaranLibraryResources.txtYearIsNotInteger);
                txtYear.Focus();
                return;
            }
            if (day < 1 || day > 31)
            {
                MessageBox.Show("روز باید عددی بین یک تا سی ویک باشد");
                txtDay.Focus();
                return;
            }
            if (month < 1 || month > 12)
            {
                MessageBox.Show("ماه باید عددی بین یک تا دوازده باشد");
                txtMonth.Focus();
                return;
            }
            if (year < 1 || year > 9999)
            {
                MessageBox.Show("سال را اشتباه وارد کرده اید");
                txtYear.Focus();
                return;
            }
            else if (year >= 00 && year <= 99)
            {
                FarsiLibrary.Utils.PersianDate dteTemp = FarsiLibrary.Utils.PersianDate.Now;
                intYearAdjuster = dteTemp.Year;
                intYearAdjuster = ((int)(intYearAdjuster / 100));
                intYearAdjuster = intYearAdjuster * 100;
                intYearAdjuster += year;
                year = intYearAdjuster;
            }
            
            FarsiLibrary.Utils.PersianDate enterdPersianDate = new FarsiLibrary.Utils.PersianDate(year, month, day);
            EnteredDate = FarsiLibrary.Utils.PersianDateConverter.ToGregorianDateTime(enterdPersianDate);
        
        }

    }
}
