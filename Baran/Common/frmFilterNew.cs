using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;
using Baran.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;

namespace Baran.Common
{
    public partial class frmFilterNew : Baran.Common.frmCommonBaseForm
    {

    #region Constractor

        public frmFilterNew()
        {
            InitializeComponent(); 
        }

    #endregion // End Constractor ---------------------------------------------------------------------

        #region Variables

        Baran.Windows.Forms.UltraDropDown cmb = new UltraDropDown();

        private void cmb_RowSelected(object sender, Infragistics.Win.UltraWinGrid.RowSelectedEventArgs e)
        {

        }

        public enum enmPropertyType
        {
            NumericalType = 0
        ,
            StringType = 1
                ,
            DateType = 2
                ,
            OneDateType = 14
                ,
            OneDate_DatetimeType = 15
                ,
            FromDateTimeType = 3
                ,
            ToDateTimeType = 4
                ,
            TextEditorType = 5
                ,
            CurrencyType = 6
                ,
            DoubleType = 7
                ,
            integersType = 8
                ,
            DropdownYesNoType = 9
                ,
            YesNoOptionSetType = 10
                ,
            TrueFalseCheckboxType = 11
                ,
            TimeType = 12
                ,
            UltravalueList = 13
                ,
            FromDateType = 16
                , ToDateType = 17
        }

        public struct stcProperty
        {
            public string ProperyText;
            public string PropertyKey;
            public enmPropertyType ProperyType;
            public object ProperySelectedValue;
            public object ProperySelectedOperator;
            public string ProperySelectedOperatorText;
            public string ProperySelectedText;
            public DataTable PropertyCustomData;
            public int PropertyCustomDataIndex;
        }

        public stcProperty[] arrProperties;
        stcProperty[] arrCurrentProperties;
        private bool _FilterIsOn = false;

        #endregion

        #region Propertise

        public bool FilterIsOn
        {
            get
            {
                return _FilterIsOn;
            }
            set
            {
                _FilterIsOn = value;
            }
        }

        public stcProperty[] arrFilterProp
        {
            get
            {
                return arrCurrentProperties;
            }
            set
            {
                arrCurrentProperties = value;
            }
        }

        #endregion

        #region Grid

        private void InitializegrdFilter()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("FieldType", typeof(string));
            dt.Columns.Add("FieldOperator", typeof(object));
            dt.Columns.Add("FieldValue", typeof(object));

            // Set the data source of the grid to the table we created.
            this.grdFilter.DataSource = dt;
        }

        private void grdFilter_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // Turn on the Add New Box
            e.Layout.AddNewBox.Hidden = true;

            // Set the Style to DropDownList.
            e.Layout.Bands[0].Columns[1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            //e.Layout.Bands[0].Columns[1].EditorControl = cmb;
            e.Layout.Bands[0].Columns[0].Width = 200;
            e.Layout.Bands[0].Columns[1].Width = 200;
            e.Layout.Bands[0].Columns[2].Width = 200;

            e.Layout.Bands[0].Columns[0].Header.Caption = "متغییر";
            e.Layout.Bands[0].Columns[1].Header.Caption = "عملگر";
            e.Layout.Bands[0].Columns[2].Header.Caption = "مقدار";

            e.Layout.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Appearance.TextVAlign = VAlign.Middle;

            e.Layout.Bands[0].Columns[0].TabStop = false;
            e.Layout.Bands[0].Columns[0].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            // Always show any drop down or editor buttons the editor may have.
            e.Layout.Bands[0].Columns[1].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

            // Set the mask modes. This only effects columns that use EditorWithMask or derived editors.
            e.Layout.Bands[0].Columns[1].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
            e.Layout.Bands[0].Columns[1].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;

            // Set the mask modes. This only effects columns that use EditorWithMask or derived editors.
            e.Layout.Bands[0].Columns[2].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
            e.Layout.Bands[0].Columns[2].MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
        }

        private void UpdateGrid()
        {

            for (int i = 0; i <= arrCurrentProperties.Length - 1; i++)
            {
                // Add new row to band 0
                this.grdFilter.DisplayLayout.Bands[0].AddNew();

                this.grdFilter.Rows[i].Cells["FieldType"].Value = arrCurrentProperties[i].ProperyText;

                // Disable the first column in the first band
                this.grdFilter.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                DataTable table = PopulateDataTableWithItems(arrCurrentProperties[i].ProperyType);

                //cmb.DataSource = table;
                Baran.Windows.Forms.UltraDropDown cmb = new UltraDropDown();
                cmb.DataSource = table;

                this.grdFilter.Rows[i].Cells[1].ValueList = cmb;
                //this.grdFilter.Rows[i].Cells[1].ValueList.SelectedItemIndex = 1;
                //this.grdFilter.DisplayLayout.Bands[0].Columns[1].ValueList = this.GetFieldProperyValueList(arrCurrentProperties[i].ProperyType);

                //Baran.Windows.Forms.UltraDropDown cmbValue = new UltraDropDown();
                //Infragistics.Win.ValueList vlst = new ValueList();
                //vlst = this.GetFieldValueValueList(arrCurrentProperties[i].ProperyType);

                ValueList vlst = this.GetFieldValueValueList(arrCurrentProperties[i].ProperyType, arrCurrentProperties[i].PropertyKey);
                if (vlst.ValueListItems.Count > 0)
                {
                    string fieldType = vlst.ValueListItems[0].ToString();
                    int index = editorsValueList.FindStringExact(fieldType);

                    EmbeddableEditorBase editor = null;
                    if (index >= 0)
                        editor = (EmbeddableEditorBase)editorsValueList.ValueListItems[index].Tag;

                    this.grdFilter.Rows[i].Cells[2].Editor = editor;

                }

                // // Set Defult year and month value for date time value
                //if ((arrCurrentProperties[i].ProperyType == enmPropertyType.FromDateTimeType) || (arrCurrentProperties[i].ProperyType == enmPropertyType.ToDateTimeType) || (arrCurrentProperties[i].ProperyType == enmPropertyType.DateType))
                //{
                //    grdFilter.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, false, false);
                //    this.grdFilter.ActiveCell.Value = Baran.Classes.Singleton.CurrentDate.Instance.Year+ "/" + Baran.Classes.Singleton.CurrentDate.Instance.Month + "/00/" + "23:59";
                //}

            }

        }

        private Infragistics.Win.ValueList GetFieldProperyValueList(enmPropertyType prmPropertyType)
        {
            // Create the ValueList
            Infragistics.Win.ValueList list = new Infragistics.Win.ValueList();



            // Retrieve the DataTable
            DataTable table = PopulateDataTableWithItems(prmPropertyType);

            // Create a ValueListItem for each row in the DataTable
            foreach (DataRow row in table.Rows)
            {
                //list.ValueListItems.Add((string)row["OperatorValueColumn"], (string)row["OperatorDisplayColumn"], );
                list.ValueListItems.Add((string)row["OperatorValueColumn"], (string)row["OperatorDisplayColumn"]);
            }

            // Return the ValueList
            return list;


        }

        private ValueList editorsValueList = null;

        private Infragistics.Win.ValueList GetFieldValueValueList(enmPropertyType prmPropertyType, string prmPropertyKey)
        {

            //// If we have already created and initialized the editors value list then return it.
            //if (null != this.editorsValueList)
            //    return this.editorsValueList;

            EmbeddableEditorBase editor = null;
            Infragistics.Win.UltraWinEditors.DefaultEditorOwnerSettings editorSettings = null;
            ValueList valueList = null;

            // Following code creates different editors and stores them into a value list so
            // that we can easily access the editor based on the item selected from the
            // value list drop down. It uses Tag property of the ValueListItems to store
            // the editor.

            this.editorsValueList = new ValueList();

            switch (prmPropertyType)
            {
                case enmPropertyType.TextEditorType:
                    {
                        // Add an item for Text Editor.
                        editorSettings = new Infragistics.Win.UltraWinEditors.DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(string);
                        editor = new EditorWithText(new Infragistics.Win.UltraWinEditors.DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Text Editor").Tag = editor;
                        break;
                    }
                case enmPropertyType.CurrencyType:
                    {
                        // Add an item for editing currency.
                        editorSettings = new Infragistics.Win.UltraWinEditors.DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(decimal);
                        editor = new EditorWithMask(new Infragistics.Win.UltraWinEditors.DefaultEditorOwner(editorSettings));
                        editorSettings.MaskInput = "-nnn,nnn,nnn,nnn,nnn";
                        editorsValueList.ValueListItems.Add(editor, "Currency").Tag = editor;
                        break;
                    }
                case enmPropertyType.DoubleType:
                    {
                        // Add an item for editing doubles.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(double);
                        editorSettings.MaskInput = "-nnnnnnnn.nnnn";
                        editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Double").Tag = editor;
                        break;
                    }
                case enmPropertyType.integersType:
                    {
                        // Add an item for editing integers.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(int);
                        editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                        editorSettings.MaskInput = "nnnnnnnnn";
                        editorsValueList.ValueListItems.Add(editor, "Integer").Tag = editor;
                        break;
                    }
                case enmPropertyType.NumericalType:
                    {
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(long);
                        editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Numerical").Tag = editor;
                        break;
                    }
                case enmPropertyType.StringType:
                    {
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(string);
                        editorsValueList.ValueListItems.Add(editor, "").Tag = editor;
                        break;
                    }
                case enmPropertyType.DropdownYesNoType:
                    {
                        // Add an item that uses Yes/No drop down.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(bool);
                        valueList = new ValueList();
                        valueList.ValueListItems.Add(true, "Yes");
                        valueList.ValueListItems.Add(false, "No");
                        editorSettings.ValueList = valueList;
                        editor = new EditorWithCombo(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Drop-down Yes/No Options").Tag = editor;
                        break;
                    }
                case enmPropertyType.YesNoOptionSetType:
                    {
                        // Add an item that uses Yes/No Option Set.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(bool);
                        valueList = new ValueList();
                        valueList.ValueListItems.Add(true, "Yes");
                        valueList.ValueListItems.Add(false, "No");
                        editorSettings.ValueList = valueList;
                        editor = new OptionSetEditor(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Yes/No Option Set").Tag = editor;
                        break;
                    }
                case enmPropertyType.TrueFalseCheckboxType:
                    {
                        // Add an item that uses checkbox.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(bool);
                        editor = new CheckEditor(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "True/False Checkbox").Tag = editor;
                        break;
                    }
                case enmPropertyType.DateType:
                    {
                        // Add an item for editing date.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(string);
                        editorSettings.MaskInput = "yyyy/mm/dd";
                        editor = new DateTimeEditor(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Date").Tag = editor;
                        break;
                    }
                case enmPropertyType.OneDateType:
                    {
                        // Add an item for editing date.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(string);
                        editorSettings.MaskInput = "yyyy/mm/dd";
                        editorSettings.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        //editor = new DateTimeEditor(new DefaultEditorOwner(editorSettings));
                        editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Date").Tag = editor;
                        break;
                    }
                case enmPropertyType.OneDate_DatetimeType:
                    {
                        // Add an item for editing date.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(string);
                        editorSettings.MaskInput = "yyyy/mm/dd";
                        editorSettings.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        //editor = new DateTimeEditor(new DefaultEditorOwner(editorSettings));
                        editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Date").Tag = editor;
                        break;
                    }
                case enmPropertyType.FromDateTimeType:
                    {
                        // Add an item for editing date.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(string);
                        editorSettings.MaskInput = "yyyy/mm/dd hh:mm";
                        editorSettings.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        //editor = new DateTimeEditor(new DefaultEditorOwner(editorSettings));
                        editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Date").Tag = editor;
                        break;
                    }
                case enmPropertyType.ToDateTimeType:
                    {
                        // Add an item for editing date.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(string);
                        editorSettings.MaskInput = "yyyy/mm/dd hh:mm";
                        editorSettings.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        //editor = new DateTimeEditor(new DefaultEditorOwner(editorSettings));
                        editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "").Tag = editor;
                        break;
                    }
                case enmPropertyType.FromDateType:
                    {
                        // Add an item for editing date.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(string);
                        editorSettings.MaskInput = "yyyy/mm/dd";
                        editorSettings.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        //editor = new DateTimeEditor(new DefaultEditorOwner(editorSettings));
                        editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Date").Tag = editor;
                        break;
                    }
                case enmPropertyType.ToDateType:
                    {
                        // Add an item for editing date.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(string);
                        editorSettings.MaskInput = "yyyy/mm/dd";
                        editorSettings.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        editorSettings.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                        //editor = new DateTimeEditor(new DefaultEditorOwner(editorSettings));
                        editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "").Tag = editor;
                        break;
                    }
                case enmPropertyType.TimeType:
                    {
                        // Add an item for editing time.
                        editorSettings = new DefaultEditorOwnerSettings();
                        editorSettings.DataType = typeof(DateTime);
                        editorSettings.MaskInput = "hh:mm:ss tt";
                        editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Time").Tag = editor;
                        break;
                    }

                case enmPropertyType.UltravalueList:
                    {
                        editorSettings = new DefaultEditorOwnerSettings();
                        //Baran.Windows.Forms.UltraDropDown dropDown = new UltraDropDown();
                        Infragistics.Win.ValueList dropDown = new ValueList();

                        //dropDown = CreateUltraDropDown(prmPropertyKey);

                        editorSettings.ValueList = dropDown;
                        editorSettings.DataType = typeof(int);
                        editor = new EditorWithCombo(new DefaultEditorOwner(editorSettings));
                        editorsValueList.ValueListItems.Add(editor, "Drop-down using ValueList").Tag = editor;

                        //this.Controls.Add(dropDown);

                        ////dropDown.DisplayLayout.Override.CellAppearance.BackColor = Color.LightYellow;
                        ////dropDown.DisplayLayout.Override.CellAppearance.BackColor2 = Color.Yellow;
                        ////dropDown.DisplayLayout.Override.CellAppearance.BackGradientStyle = GradientStyle.ForwardDiagonal;

                        //editorSettings.ValueList = dropDown;
                        //editorSettings.DataType = typeof(int);
                        //editor = new EditorWithCombo(new DefaultEditorOwner(editorSettings));
                        //editorsValueList.ValueListItems.Add(editor, "Drop-down using UltraDropDown").Tag = editor;
                        break;
                    }
            }
            return this.editorsValueList;

        }

        //private Infragistics.Win.ValueList CreateUltraDropDown(string prmPropertyKey)
        //{
        //Infragistics.Win.ValueList Vlst = new ValueList(); 


        //if (prmPropertyKey == cnsFilterPropertiesKey.SafeOperationTypeName)
        //{
        //    BaranDataAccess.Safe.dstSafe SafeOperationTypeDst;
        //    SafeOperationTypeDst = Baran.Classes.Singleton.SafeOperationType.Instance.DstSafeOperationType;

        //    foreach (DataRow row in SafeOperationTypeDst.spr_Saf_SafeOperationType_Select.Rows)
        //        Vlst.ValueListItems.Add((int)row["SafeOperationTypeID"], (string)row["SafeOperationTypeName"]);
        //}

        //else if (prmPropertyKey == cnsFilterPropertiesKey.FactorCalculationType)
        //{
        //    //BaranDataAccess.Factors.dstFactors FactorCalcDst;
        //    //FactorCalcDst = Baran.Classes.Common.FactorCalculationType.Instance.DstFactorCalculationTypes;

        //    //foreach (DataRow row in FactorCalcDst.spr_Fac_FactorCalculationTypes_Select.Rows)
        //    //    Vlst.ValueListItems.Add((int)row["FactorCalculationTypeID"], (string)row["FactorCalculationType"]);
        //}

        //else if (prmPropertyKey == cnsFilterPropertiesKey.FactorOperationType)
        //{
        //    //BaranDataAccess.Factors.dstFactors FactorOptType;
        //    //FactorOptType = Baran.Classes.Common.FactorOperationTypes.Instance.DstFactorOperationType;

        //    //foreach (DataRow row in FactorOptType.spr_Fac_FactorOperationTypes_Select.Rows)
        //    //    Vlst.ValueListItems.Add((int)row["FactorOperationTypeID"], (string)row["FactorOperationTypeFA"]);
        //}

        //else if (prmPropertyKey == cnsFilterPropertiesKey.Persons)
        //{
        //    //BaranDataAccess.Persons.dstPersons PersonDst;
        //    //PersonDst = Baran.Classes.Singleton.Persons.Instance.DstPersons;

        //    //foreach (DataRow row in PersonDst.spr_Per_Persons_Select.Rows)
        //    //    Vlst.ValueListItems.Add((long)row["PersonID"], (string)row["PersonCompleteName"]);
        //}

        //else if (prmPropertyKey == cnsFilterPropertiesKey.Stores)
        //{
        //    //BaranDataAccess.Stores.dstStores StoresDst;
        //    //StoresDst = Baran.Classes.Singleton.Stores.Instance.DstStores;

        //    //foreach (DataRow row in StoresDst.spr_str_Stores_Select.Rows)
        //    //    Vlst.ValueListItems.Add((int)row["StoreID"], (string)row["StoreName"]);
        //}

        //else if (prmPropertyKey == cnsFilterPropertiesKey.Goods)
        //{
        //    //BaranDataAccess.Goods.dstGoods GoodsDst;
        //    //GoodsDst = Baran.Classes.Singleton.Goods.Instance.DstGoods;

        //    //foreach (DataRow row in GoodsDst.spr_Goo_Goods_Select.Rows)
        //    //    Vlst.ValueListItems.Add((long)row["GoodID"], (string)row["GoodName"]);
        //}

        //else if (prmPropertyKey == cnsFilterPropertiesKey.RecievePaymentTypeName)
        //{
        //    //BaranDataAccess.Safe.dstSafe SafeDst;
        //    //SafeDst = Baran.Classes.Singleton.RecievePaymentType.Instance.DstSafe;

        //    //foreach (DataRow row in SafeDst.spr_Saf_RecievePaymentTypes_Select.Rows)
        //    //    Vlst.ValueListItems.Add((int)row["RecievePaymentTypeID"], (string)row["RecievePaymentTypeName"]);
        //}

        //else if (prmPropertyKey == cnsFilterPropertiesKey.SafeReasonTypes)
        //{
        //    //BaranDataAccess.Safe.dstReasonTypes SafeReasonTypeDst;
        //    //SafeReasonTypeDst = Baran.Classes.Singleton.SafeReasonType.Instance.DstSafeReasonType;

        //    //foreach (DataRow row in SafeReasonTypeDst.spr_Saf_SafeReasonType_Select.Rows)
        //    //    Vlst.ValueListItems.Add((int)row["SafeReasonTypeID"], (string)row["SafeReasonTypeName"]);
        //}

        //else if (prmPropertyKey == cnsFilterPropertiesKey.Bank)
        //{
        //    //BaranDataAccess.Bank.dstBank BankDst;
        //    //BankDst = Baran.Classes.Singleton.Bank.Instance.DstBank;

        //    //foreach (DataRow row in BankDst.spr_Bnk_Bank_Select.Rows)
        //    //    Vlst.ValueListItems.Add((int)row["BankID"], (string)row["BankName"]);
        //}

        //return Vlst;
        //}

        private DataTable PopulateDataTableWithItems(enmPropertyType prmPropertyType)
        {
            // Create the DataTable
            DataTable table = new DataTable("OperatorItems");

            // Create the DataColumns
            table.Columns.Add("OperatorValueColumn");
            table.Columns.Add("OperatorDisplayColumn");


            switch (prmPropertyType)
            {
                case enmPropertyType.YesNoOptionSetType:
                    {
                        table.Rows.Add(new object[] { "مساوی با", "=" });
                        table.Rows.Add(new object[] { "نا مساوی با", "<>" });
                        break;
                    }
                case enmPropertyType.DateType:
                    {
                        table.Rows.Add(new object[] { "مساوی با", "=" });
                        table.Rows.Add(new object[] { "کوچکتر از", "<" });
                        table.Rows.Add(new object[] { "کوچکتر مساوی ", "<=" });
                        table.Rows.Add(new object[] { "بزرگتر از", ">" });
                        table.Rows.Add(new object[] { "بزرگتر مساوی", ">=" });
                        break;
                    }
                case enmPropertyType.integersType:
                    {
                        table.Rows.Add(new object[] { "مساوی با", "=" });
                        table.Rows.Add(new object[] { "کوچکتر از", "<" });
                        table.Rows.Add(new object[] { "کوچکتر مساوی ", "<=" });
                        table.Rows.Add(new object[] { "بزرگتر از", ">" });
                        table.Rows.Add(new object[] { "بزرگتر مساوی", ">=" });
                        break;
                    }
                case enmPropertyType.CurrencyType:
                    {
                        table.Rows.Add(new object[] { "مساوی با", "=" });
                        table.Rows.Add(new object[] { "کوچکتر از", "<" });
                        table.Rows.Add(new object[] { "کوچکتر مساوی ", "<=" });
                        table.Rows.Add(new object[] { "بزرگتر از", ">" });
                        table.Rows.Add(new object[] { "بزرگتر مساوی", ">=" });
                        break;
                    }
                case enmPropertyType.StringType:
                    {
                        table.Rows.Add(new object[] { "مساوی با", "=" });
                        table.Rows.Add(new object[] { "نا مساوی با", "<>" });
                        table.Rows.Add(new object[] { "شامل", "LIKE" });
                        table.Rows.Add(new object[] { "بغیر از", "NOT LIKE" });
                        break;
                    }
                case enmPropertyType.UltravalueList:
                    {
                        // Populate the DataRows
                        table.Rows.Add(new object[] { "مساوی با", "=" });
                        table.Rows.Add(new object[] { "نا مساوی با", "<>" });


                        break;
                    }
                case enmPropertyType.FromDateTimeType:
                    {
                        table.Rows.Add(new object[] { "بزرگتر مساوی", ">=" });
                        break;
                    }
                case enmPropertyType.ToDateTimeType:
                    {
                        table.Rows.Add(new object[] { "کوچکتر مساوی", "<=" });
                        break;
                    }
                case enmPropertyType.FromDateType:
                    {
                        table.Rows.Add(new object[] { "بزرگتر مساوی", ">=" });
                        break;
                    }
                case enmPropertyType.ToDateType:
                    {
                        table.Rows.Add(new object[] { "کوچکتر مساوی", "<=" });
                        break;
                    }
                case enmPropertyType.OneDateType:
                    {
                        table.Rows.Add(new object[] { "مساوی با", "=" });
                        break;
                    }
                case enmPropertyType.OneDate_DatetimeType:
                    {
                        table.Rows.Add(new object[] { "مساوی با", "=" });
                        break;
                    }

                case enmPropertyType.TrueFalseCheckboxType:
                    {
                        table.Rows.Add(new object[] { "مساوی با", "=" });
                        break;
                    }
            }


            // Return the DataTable
            return table;
        }

        public void CurrentChaildFormProperty(params string[] PropertiesKey)
        {
            arrCurrentProperties = new stcProperty[PropertiesKey.Length];
            this.SetarrProperties();

            for (int p = 0; p < PropertiesKey.Length; p++)
            {
                string propKey = PropertiesKey[p];
                for (int i = 0; i < arrProperties.Length; i++)
                {
                    if (arrProperties[i].PropertyKey == propKey)
                    {
                        arrCurrentProperties[p].PropertyKey = arrProperties[i].PropertyKey;
                        arrCurrentProperties[p].ProperyText = arrProperties[i].ProperyText;
                        arrCurrentProperties[p].ProperyType = arrProperties[i].ProperyType;
                    }

                }
            }
        }

        public void SetarrProperties()
        {
            arrProperties = new stcProperty[29];

            arrProperties[0].PropertyKey = cnsFilterPropertiesKey.DocumentNumber;
            arrProperties[0].ProperyText = cnsFilterPropertiesName.DocumentNumber;
            arrProperties[0].ProperyType = enmPropertyType.integersType;

            //arrProperties[1].PropertyKey = cnsFilterPropertiesKey.Amount;
            //arrProperties[1].ProperyText = cnsFilterPropertiesName.Amount;
            //arrProperties[1].ProperyType = enmPropertyType.CurrencyType;

            //arrProperties[2].PropertyKey = cnsFilterPropertiesKey.FactorNumber;
            //arrProperties[2].ProperyText = cnsFilterPropertiesName.FactorNumber;
            //arrProperties[2].ProperyType = enmPropertyType.integersType;

            //arrProperties[3].PropertyKey = cnsFilterPropertiesKey.SafeOperationTypeName;
            //arrProperties[3].ProperyText = cnsFilterPropertiesName.SafeOperationTypeName;
            //arrProperties[3].ProperyType = enmPropertyType.UltravalueList;

            arrProperties[4].PropertyKey = cnsFilterPropertiesKey.FactorCalculationType;
            arrProperties[4].ProperyText = cnsFilterPropertiesName.FactorCalculationType;
            arrProperties[4].ProperyType = enmPropertyType.UltravalueList;

            arrProperties[5].PropertyKey = cnsFilterPropertiesKey.FactorOperationType;
            arrProperties[5].ProperyText = cnsFilterPropertiesName.FactorOperationType;
            arrProperties[5].ProperyType = enmPropertyType.UltravalueList;

            arrProperties[6].PropertyKey = cnsFilterPropertiesKey.Persons;
            arrProperties[6].ProperyText = cnsFilterPropertiesName.Persons;
            arrProperties[6].ProperyType = enmPropertyType.UltravalueList;

            arrProperties[7].PropertyKey = cnsFilterPropertiesKey.Stores;
            arrProperties[7].ProperyText = cnsFilterPropertiesName.Stores;
            arrProperties[7].ProperyType = enmPropertyType.UltravalueList;

            arrProperties[8].PropertyKey = cnsFilterPropertiesKey.FromDateTime;
            arrProperties[8].ProperyText = cnsFilterPropertiesName.FromDateTime;
            arrProperties[8].ProperyType = enmPropertyType.FromDateTimeType;

            arrProperties[9].PropertyKey = cnsFilterPropertiesKey.ToDateTime;
            arrProperties[9].ProperyText = cnsFilterPropertiesName.ToDateTime;
            arrProperties[9].ProperyType = enmPropertyType.ToDateTimeType;

            arrProperties[10].PropertyKey = cnsFilterPropertiesKey.Goods;
            arrProperties[10].ProperyText = cnsFilterPropertiesName.Goods;
            arrProperties[10].ProperyType = enmPropertyType.UltravalueList;

            arrProperties[11].PropertyKey = cnsFilterPropertiesKey.GoodCode;
            arrProperties[11].ProperyText = cnsFilterPropertiesName.GoodCode;
            arrProperties[11].ProperyType = enmPropertyType.integersType;

            arrProperties[12].PropertyKey = cnsFilterPropertiesKey.RecievePaymentTypeName;
            arrProperties[12].ProperyText = cnsFilterPropertiesName.RecievePaymentTypeName;
            arrProperties[12].ProperyType = enmPropertyType.UltravalueList;

            arrProperties[13].PropertyKey = cnsFilterPropertiesKey.SafeReasonTypes;
            arrProperties[13].ProperyText = cnsFilterPropertiesName.SafeReasonTypes;
            arrProperties[13].ProperyType = enmPropertyType.UltravalueList;

            arrProperties[14].PropertyKey = cnsFilterPropertiesKey.OneDate;
            arrProperties[14].ProperyText = cnsFilterPropertiesName.OneDate;
            arrProperties[14].ProperyType = enmPropertyType.OneDateType;

            arrProperties[15].PropertyKey = cnsFilterPropertiesKey.PersonalCheques;
            arrProperties[15].ProperyText = cnsFilterPropertiesName.PersonalCheques;
            arrProperties[15].ProperyType = enmPropertyType.TrueFalseCheckboxType;

            arrProperties[16].PropertyKey = cnsFilterPropertiesKey.CostumerCheques;
            arrProperties[16].ProperyText = cnsFilterPropertiesName.CostumerCheques;
            arrProperties[16].ProperyType = enmPropertyType.TrueFalseCheckboxType;

            arrProperties[17].PropertyKey = cnsFilterPropertiesKey.Bank;
            arrProperties[17].ProperyText = cnsFilterPropertiesName.Bank;
            arrProperties[17].ProperyType = enmPropertyType.UltravalueList;

            arrProperties[18].PropertyKey = cnsFilterPropertiesKey.ChequeNumber;
            arrProperties[18].ProperyText = cnsFilterPropertiesName.ChequeNumber;
            arrProperties[18].ProperyType = enmPropertyType.integersType;

            arrProperties[19].PropertyKey = cnsFilterPropertiesKey.MatureDate;
            arrProperties[19].ProperyText = cnsFilterPropertiesName.MatureDate;
            arrProperties[19].ProperyType = enmPropertyType.OneDateType;



            arrProperties[20].PropertyKey = cnsFilterPropertiesKey.ChequeCashed;
            arrProperties[20].ProperyText = cnsFilterPropertiesName.ChequeCashed;
            arrProperties[20].ProperyType = enmPropertyType.TrueFalseCheckboxType;

            arrProperties[21].PropertyKey = cnsFilterPropertiesKey.ChequeHandedOver;
            arrProperties[21].ProperyText = cnsFilterPropertiesName.ChequeHandedOver;
            arrProperties[21].ProperyType = enmPropertyType.TrueFalseCheckboxType;

            arrProperties[22].PropertyKey = cnsFilterPropertiesKey.ChequeCollected;
            arrProperties[22].ProperyText = cnsFilterPropertiesName.ChequeCollected;
            arrProperties[22].ProperyType = enmPropertyType.TrueFalseCheckboxType;

            arrProperties[23].PropertyKey = cnsFilterPropertiesKey.ChequeProtested;
            arrProperties[23].ProperyText = cnsFilterPropertiesName.ChequeProtested;
            arrProperties[23].ProperyType = enmPropertyType.TrueFalseCheckboxType;

            arrProperties[24].PropertyKey = cnsFilterPropertiesKey.ChequeSpended;
            arrProperties[24].ProperyText = cnsFilterPropertiesName.ChequeSpended;
            arrProperties[24].ProperyType = enmPropertyType.TrueFalseCheckboxType;

            arrProperties[25].PropertyKey = cnsFilterPropertiesKey.ChequeRollBacked;
            arrProperties[25].ProperyText = cnsFilterPropertiesName.ChequeRollBacked;
            arrProperties[25].ProperyType = enmPropertyType.TrueFalseCheckboxType;

            arrProperties[26].PropertyKey = cnsFilterPropertiesKey.OneDate_DatetimeType;
            arrProperties[26].ProperyText = cnsFilterPropertiesName.OneDate_DatetimeType;
            arrProperties[26].ProperyType = enmPropertyType.OneDate_DatetimeType;

            arrProperties[27].PropertyKey = cnsFilterPropertiesKey.FromDate;
            arrProperties[27].ProperyText = cnsFilterPropertiesName.FromDate;
            arrProperties[27].ProperyType = enmPropertyType.FromDateType;

            arrProperties[28].PropertyKey = cnsFilterPropertiesKey.ToDate;
            arrProperties[28].ProperyText = cnsFilterPropertiesName.ToDate;
            arrProperties[28].ProperyType = enmPropertyType.ToDateType;
        }

        private void grdFilter_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if ("FieldOperator".Equals(e.Cell.Column.Key))
            {
                //for (int i = 0; i <= arrCurrentProperties.Length - 1; i++)
                //{
                int i = e.Cell.Row.Index;

                ValueList OperatorList = this.GetFieldProperyValueList(arrCurrentProperties[i].ProperyType);

                int intIndex = OperatorList.FindStringExact(e.Cell.Row.Cells[1].Text);
                int intOperatorItemIndex = (((Infragistics.Win.UltraWinGrid.UltraGridCell)(e.Cell.Row.Cells.All[1])).ValueList.SelectedItemIndex);
                string strOperatorSQL = OperatorList.ValueListItems.All[intOperatorItemIndex].ToString();
                string strOperatorText = OperatorList.ValueListItems[intOperatorItemIndex].DataValue.ToString();

                arrCurrentProperties[i].ProperySelectedOperator = strOperatorSQL;
                arrCurrentProperties[i].ProperySelectedOperatorText = strOperatorText;

                if (intIndex >= 0)
                {
                    // If the city belongs to the selected state then reset the fore color
                    // of the city from red to the default color.
                    e.Cell.Row.Cells["FieldValue"].Appearance.ResetForeColor();
                }
                else
                {
                    // If the city doesn't belong to the selected state then set the fore color
                    // of the city to Red.
                    e.Cell.Row.Cells["FieldValue"].Appearance.ForeColor = Color.Blue;
                }
                //}
            }
        }

        #endregion

        #region Methods

        private void CloseForm()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void Confim()
        {

            FilterIsOn = false;

            btnOK.Focus();

            for (int i = 0; i <= grdFilter.Rows.Count - 1; i++)
            {
                //DataGridViewRow dgrdRow = new DataGridViewRow();
                //dgrdRow  = grdFilter.Rows[i];


                var objValue = grdFilter.Rows[i].Cells[2].Value;
                string ObjText = grdFilter.Rows[i].Cells[2].Text;

                if (objValue.ToString() == string.Empty)
                {
                    arrCurrentProperties[i].ProperySelectedValue = null; // string.Empty;
                    continue;
                }
                else
                    FilterIsOn = true;


                switch (arrCurrentProperties[i].ProperyType)
                {
                    case enmPropertyType.ToDateTimeType:
                    case enmPropertyType.OneDateType:
                    case enmPropertyType.FromDateTimeType:
                    case enmPropertyType.FromDateType:
                    case enmPropertyType.ToDateType:
                        {

                            DateTime dt = FarsiLibrary.Utils.PersianDateConverter.ToGregorianDateTime(objValue.ToString());
                            string strdt = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            objValue = " CONVERT(DATETIME, '" + strdt + "', 102)";

                            break;
                        }
                    case enmPropertyType.OneDate_DatetimeType:
                        {
                            objValue = PublicMethods.ShamsiToMiladi(objValue.ToString());
                            break;
                        }

                    //        case enmPropertyType.TextEditorType:
                    //            {
                    //                objValue = objValue.ToString().Replace("'", string.Empty); //for preventing injection
                    //                objValue = objValue.ToString().Replace("-", string.Empty); //for preventing injection
                    //                break;
                    //            }
                    //        case enmPropertyType.CurrencyType:
                    //            {
                    //                // Add an item for editing currency.
                    //                editorSettings = new Infragistics.Win.UltraWinEditors.DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(decimal);
                    //                editor = new EditorWithMask(new Infragistics.Win.UltraWinEditors.DefaultEditorOwner(editorSettings));
                    //                editorSettings.MaskInput = "-nnn,nnn,nnn,nnn,nnn";
                    //                editorsValueList.ValueListItems.Add(editor, "Currency").Tag = editor;
                    //                break;
                    //            }
                    //        case enmPropertyType.DoubleType:
                    //            {
                    //                // Add an item for editing doubles.
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(double);
                    //                editorSettings.MaskInput = "-nnnnnnnn.nnnn";
                    //                editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                    //                editorsValueList.ValueListItems.Add(editor, "Double").Tag = editor;
                    //                break;
                    //            }
                    //        case enmPropertyType.integersType:
                    //            {
                    //                // Add an item for editing integers.
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(int);
                    //                editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                    //                editorSettings.MaskInput = "nnnnnnnnn";
                    //                editorsValueList.ValueListItems.Add(editor, "Integer").Tag = editor;
                    //                break;
                    //            }
                    //        case enmPropertyType.StringType:
                    //            {
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(string);
                    //                editorsValueList.ValueListItems.Add(editor, "").Tag = editor;
                    //                break;
                    //            }
                    //        case enmPropertyType.DropdownYesNoType:
                    //            {
                    //                // Add an item that uses Yes/No drop down.
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(bool);
                    //                valueList = new ValueList();
                    //                valueList.ValueListItems.Add(true, "Yes");
                    //                valueList.ValueListItems.Add(false, "No");
                    //                editorSettings.ValueList = valueList;
                    //                editor = new EditorWithCombo(new DefaultEditorOwner(editorSettings));
                    //                editorsValueList.ValueListItems.Add(editor, "Drop-down Yes/No Options").Tag = editor;
                    //                break;
                    //            }
                    //        case enmPropertyType.YesNoOptionSetType:
                    //            {
                    //                // Add an item that uses Yes/No Option Set.
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(bool);
                    //                valueList = new ValueList();
                    //                valueList.ValueListItems.Add(true, "Yes");
                    //                valueList.ValueListItems.Add(false, "No");
                    //                editorSettings.ValueList = valueList;
                    //                editor = new OptionSetEditor(new DefaultEditorOwner(editorSettings));
                    //                editorsValueList.ValueListItems.Add(editor, "Yes/No Option Set").Tag = editor;
                    //                break;
                    //            }
                    //        case enmPropertyType.TrueFalseCheckboxType:
                    //            {
                    //                // Add an item that uses checkbox.
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(bool);
                    //                editor = new CheckEditor(new DefaultEditorOwner(editorSettings));
                    //                editorsValueList.ValueListItems.Add(editor, "True/False Checkbox").Tag = editor;
                    //                break;
                    //            }
                    //        case enmPropertyType.DateType:
                    //            {
                    //                // Add an item for editing date.
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(string);
                    //                editorSettings.MaskInput = "yyyy/mm/dd";
                    //                editor = new DateTimeEditor(new DefaultEditorOwner(editorSettings));
                    //                editorsValueList.ValueListItems.Add(editor, "Date").Tag = editor;
                    //                break;
                    //            }
                    //        case enmPropertyType.FromDateTimeType:
                    //            {
                    //                // Add an item for editing date.
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(string);
                    //                editorSettings.MaskInput = "yyyy/mm/dd hh:ss";
                    //                editor = new DateTimeEditor(new DefaultEditorOwner(editorSettings));
                    //                editorsValueList.ValueListItems.Add(editor, "Date").Tag = editor;
                    //                break;
                    //            }
                    //        case enmPropertyType.ToDateTimeType:
                    //            {
                    //                // Add an item for editing date.
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(string);
                    //                editorSettings.MaskInput = "nnnn/nn/nn nn:nn";
                    //                editor = new DateTimeEditor(new DefaultEditorOwner(editorSettings));
                    //                editorsValueList.ValueListItems.Add(editor, "").Tag = editor;
                    //                break;
                    //            }
                    //        case enmPropertyType.TimeType:
                    //            {
                    //                // Add an item for editing time.
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                editorSettings.DataType = typeof(DateTime);
                    //                editorSettings.MaskInput = "hh:mm:ss tt";
                    //                editor = new EditorWithMask(new DefaultEditorOwner(editorSettings));
                    //                editorsValueList.ValueListItems.Add(editor, "Time").Tag = editor;
                    //                break;
                    //            }

                    //        case enmPropertyType.UltravalueList:
                    //            {
                    //                editorSettings = new DefaultEditorOwnerSettings();
                    //                //Baran.Windows.Forms.UltraDropDown dropDown = new UltraDropDown();
                    //                Infragistics.Win.ValueList dropDown = new ValueList();

                    //                dropDown = CreateUltraDropDown(prmPropertyKey);

                    //                editorSettings.ValueList = dropDown;
                    //                editorSettings.DataType = typeof(int);
                    //                editor = new EditorWithCombo(new DefaultEditorOwner(editorSettings));
                    //                editorsValueList.ValueListItems.Add(editor, "Drop-down using ValueList").Tag = editor;

                    //                //this.Controls.Add(dropDown);

                    //                ////dropDown.DisplayLayout.Override.CellAppearance.BackColor = Color.LightYellow;
                    //                ////dropDown.DisplayLayout.Override.CellAppearance.BackColor2 = Color.Yellow;
                    //                ////dropDown.DisplayLayout.Override.CellAppearance.BackGradientStyle = GradientStyle.ForwardDiagonal;

                    //                //editorSettings.ValueList = dropDown;
                    //                //editorSettings.DataType = typeof(int);
                    //                //editor = new EditorWithCombo(new DefaultEditorOwner(editorSettings));
                    //                //editorsValueList.ValueListItems.Add(editor, "Drop-down using UltraDropDown").Tag = editor;
                    //                break;
                    //            }






                    //        case enmPropertyType.NumericalType:
                    //            {
                    //                long Num;
                    //                bool isnum = Int64.TryParse(objValue.ToString(), out Num);
                    //                if ((isnum == false))
                    //                {
                    //                    MessageBox.Show(("The property " + (arrCurrentProperties[i].ProperyText + " has invalid value.")));
                    //                    return;
                    //                }
                    //                break;
                    //            }

                    //        case enmPropertyType.DateType:
                    //            {
                    //                DateTime Date;
                    //                bool isDate = DateTime.TryParse(objValue.ToString(), out Date);
                    //                MessageBox.Show("The property " + arrCurrentProperties[i].ProperyText + " has invalid value.");
                    //                break;
                    //            }

                    //        case enmPropertyType.StringType:
                    //            {
                    //                objValue = objValue.ToString().Replace("'", string.Empty); //for preventing injection
                    //                objValue = objValue.ToString().Replace("-", string.Empty); //for preventing injection
                    //                break;
                    //            }

                    //        case enmPropertyType.TrueFalseCheckboxType:
                    //            {
                    //                //if (objValue == arrCurrentProperties[i].PropertyValueTextTrue)
                    //                //    objValue = true;
                    //                //else
                    //                //    objValue = false;

                    //                break;
                    //            }

                    //        case enmPropertyType.UltravalueList:
                    //            {
                    //                break;
                    //            }
                }

                arrCurrentProperties[i].ProperySelectedValue = objValue;
                arrCurrentProperties[i].ProperySelectedText = ObjText;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ClearList()
        {
            int intRowCount = grdFilter.Rows.Count;
            for (int i = 0; i <= intRowCount - 1; i++)
            {
                grdFilter.Rows[0].Delete();
            }

            for (int i = 0; i <= arrCurrentProperties.Length - 1; i++)
            {
                arrCurrentProperties[i].ProperySelectedValue = string.Empty;
                arrCurrentProperties[i].ProperySelectedOperator = string.Empty;
            }


            this.UpdateGrid();
        }

        private void SetControlsImage()
        {
            try
            {
                btnOK.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Check16));
                btnCancle.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.delete16));
                btnClear.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.clear16));
                pictureBox1.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.filter));
            }
            catch
            {

                throw;
            }
        }

        #endregion // End Methods -------------------------------------------------------------------------

        #region Events
        private void frmFilterNew_Load(object sender, EventArgs e)
        {
            this.InitializegrdFilter();
            this.UpdateGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Confim();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.CloseForm();
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.CloseForm();
        }

        private void mnuConfirm_Click(object sender, EventArgs e)
        {
            this.Confim();
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            this.ClearList();
        }
        #endregion // End Events --------------------------------------------------------------------------

    }

}
