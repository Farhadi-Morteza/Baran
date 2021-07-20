using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Linq;
using System.IO;
using Baran.Classes.Common;

namespace Baran.Common
{
    public partial class frmFilter : Baran.Base_Forms.frmChildBase
    {
        
        #region Constractor
            public frmFilter()
            {
                InitializeComponent();
            }
        #endregion

        #region Variables
            
            public enum enmPropertyType
            {
                  NumericalType = 0
                , StringType = 1
                , DateType = 2
                , BooleanType = 3
                , CustomType = 4
            }

            public struct stcProperty
            {
                public string ProperyText ;
                public string PropertyKey;
                public enmPropertyType ProperyType ;
                public string PropertyValueTextTrue ;// it's for Boolean Only as: Yes 
                public string PropertyValueTextFalse ; // it's for Boolean Only as: No 
                public object ProperySelectedValue ;
                public object ProperySelectedOperator ;
                public DataTable PropertyCustomData ;
                public int PropertyCustomDataIndex ;
            }

            private struct stcOperator
            {
                public string OperatorDesc ;
                public string OperatorSQL ;
            }

            stcOperator[] P_arr_Operatores = new stcOperator[8];
            public stcProperty[] arrProperties;
            stcProperty[] arrCurrentProperties ;
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


       
        public  void SetarrProperties()
        {

            arrProperties = new stcProperty[10];

            arrProperties[0].PropertyKey = cnsFilterPropertiesKey.DocumentNumber;
            arrProperties[0].ProperyText = cnsFilterPropertiesName.DocumentNumber;
            arrProperties[0].ProperyType = enmPropertyType.StringType;

            //arrProperties[1].PropertyKey = cnsFilterPropertiesKey.Amount;
            //arrProperties[1].ProperyText = cnsFilterPropertiesName.Amount;
            //arrProperties[1].ProperyType = enmPropertyType.NumericalType;

            //arrProperties[2].PropertyKey = cnsFilterPropertiesKey.FactorNumber;
            //arrProperties[2].ProperyText = cnsFilterPropertiesName.FactorNumber;
            //arrProperties[2].ProperyType = enmPropertyType.StringType;

            //arrProperties[3].PropertyKey = cnsFilterPropertiesKey.SafeOperationTypeName;
            //arrProperties[3].ProperyText = cnsFilterPropertiesName.SafeOperationTypeName;
            //arrProperties[3].ProperyType = enmPropertyType.CustomType;

            arrProperties[4].PropertyKey = cnsFilterPropertiesKey.FactorCalculationType;
            arrProperties[4].ProperyText = cnsFilterPropertiesName.FactorCalculationType;
            arrProperties[4].ProperyType = enmPropertyType.CustomType;

            arrProperties[5].PropertyKey = cnsFilterPropertiesKey.FactorOperationType;
            arrProperties[5].ProperyText = cnsFilterPropertiesName.FactorOperationType;
            arrProperties[5].ProperyType = enmPropertyType.CustomType;

            arrProperties[6].PropertyKey = cnsFilterPropertiesKey.Persons;
            arrProperties[6].ProperyText = cnsFilterPropertiesName.Persons;
            arrProperties[6].ProperyType = enmPropertyType.CustomType;

            arrProperties[7].PropertyKey = cnsFilterPropertiesKey.Stores;
            arrProperties[7].ProperyText = cnsFilterPropertiesName.Stores;
            arrProperties[7].ProperyType = enmPropertyType.CustomType;

            arrProperties[8].PropertyKey = cnsFilterPropertiesKey.FromDate;
            arrProperties[8].ProperyText = cnsFilterPropertiesName.FromDate;
            arrProperties[8].ProperyType = enmPropertyType.DateType;

            arrProperties[9].PropertyKey = cnsFilterPropertiesKey.ToDate;
            arrProperties[9].ProperyText = cnsFilterPropertiesName.ToDate;
            arrProperties[9].ProperyType = enmPropertyType.DateType;

                     
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

        #region Methods

            private void UpdateGrid()
            {
                //grdFilter.Rows.Clear();

                for (int i = 0; i <= arrCurrentProperties.GetLength(0) - 1; i++)
                {
                    DataGridViewRow dgrdRow = new DataGridViewRow();
                    DataGridViewTextBoxCell CellProperty = new DataGridViewTextBoxCell();

                    CellProperty.Value = arrCurrentProperties[i].ProperyText;
                    dgrdRow.Cells.Add(CellProperty);
                    CellProperty.ReadOnly = true;

                    DataGridViewComboBoxCell CellOperator = new DataGridViewComboBoxCell();
                    CellOperator = this.CreateTheComboItems(arrCurrentProperties[i].ProperyType);
                    dgrdRow.Cells.Add(CellOperator);

                    if (arrCurrentProperties[i].ProperySelectedOperator != null && (arrCurrentProperties[i].ProperySelectedOperator).ToString() != string.Empty )
                    {
                        object objCurrentOperator = arrCurrentProperties[i].ProperySelectedOperator;

                        var lnqOperator = (from le in P_arr_Operatores where le.OperatorSQL == objCurrentOperator.ToString() select le).ToArray();
                        CellOperator.Value = lnqOperator[0].OperatorDesc;
                    }
                    switch (arrCurrentProperties[i].ProperyType)
                    {
                        case enmPropertyType.BooleanType:
                            {
                                DataGridViewComboBoxCell CellValue = new DataGridViewComboBoxCell();
                                CellValue.Items.Add(string.Empty);
                                CellValue.Items.Add(arrCurrentProperties[i].PropertyValueTextTrue);
                                CellValue.Items.Add(arrCurrentProperties[i].PropertyValueTextFalse);

                                dgrdRow.Cells.Add(CellValue);

                                if ((arrCurrentProperties[i].ProperySelectedValue).ToString() == string.Empty)
                                    CellValue.Value = arrCurrentProperties[i].PropertyValueTextTrue;
                                else
                                    CellValue.Value = arrCurrentProperties[i].PropertyValueTextFalse;

                                break;
                            }

                        case enmPropertyType.DateType:
                            {
                                            //Dim CellValue As New CalendarCell()
                                            //dgrdRow.Cells.Add(CellValue)

                                            //If P_Poperties(i).ProperySelectedValue IsNot Nothing Then
                                            //    CellValue.Value = CDate(P_Poperties(i).ProperySelectedValue)
                                            //End If

                                DataGridViewTextBoxCell CellValue = new DataGridViewTextBoxCell();
                                dgrdRow.Cells.Add(CellValue);
                                //DataGridViewTextBoxCell CellValue = new DataGridViewTextBoxCell();
                                //CellValue.Style.Format = "####/##/##";
                                //dgrdRow.DefaultCellStyle.Format = "d";
                                //dgrdRow.Cells[1].Style.Format = "d";
                                break;
                            }
                        case enmPropertyType.NumericalType:
                            {
                                DataGridViewTextBoxCell CellValue = new DataGridViewTextBoxCell();
                                dgrdRow.Cells.Add(CellValue);

                                if ((arrCurrentProperties[i].ProperySelectedValue).ToString() != string.Empty)
                                    CellValue.Value = Convert.ToInt32(arrCurrentProperties[i].ProperySelectedValue);

                                break;
                            }

                        case enmPropertyType.StringType:
                            {
                                DataGridViewTextBoxCell CellValue = new DataGridViewTextBoxCell();
                                dgrdRow.Cells.Add(CellValue);

                                if (arrCurrentProperties[i].ProperySelectedValue != null)
                                    CellValue.Value = arrCurrentProperties[i].ProperySelectedValue.ToString().Replace("%", string.Empty);


                                break;
                            }

                        case enmPropertyType.CustomType:
                            {
                                DataGridViewComboBoxCell CellValue = new DataGridViewComboBoxCell();
                                CellValue.Items.Add(string.Empty);

                                //for (int j = 0; j <= arrCurrentProperties[i].PropertyCustomData.Rows.Count - 1; j++)
                                //{
                                //    CellValue.Items.Add(arrCurrentProperties[i].PropertyCustomData.Rows[j].ItemArray[arrCurrentProperties[i].PropertyCustomDataIndex]);

                                //}
                                //CellValue = this.CreateTheValueComboItems( arrCurrentProperties[i].PropertyKey);
                                dgrdRow.Cells.Add(CellValue);
                                    break;
                            }
                    }

                    //grdFilter.Rows.Add(dgrdRow);
                }

            }
       
            private DataGridViewComboBoxCell CreateTheComboItems (enmPropertyType OenmPropertyType)
            {
                DataGridViewComboBoxCell TheComboCell = new DataGridViewComboBoxCell();

                switch (OenmPropertyType)
                {
                    case enmPropertyType.BooleanType:
                        {
                            TheComboCell.Items.Add(P_arr_Operatores[0].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[1].OperatorDesc);
                            TheComboCell.Value = P_arr_Operatores[0].OperatorDesc;
                            break;
                        }
                    case enmPropertyType.DateType:
                        {
                            TheComboCell.Items.Add(P_arr_Operatores[0].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[2].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[3].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[4].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[5].OperatorDesc);
                            TheComboCell.Value = P_arr_Operatores[0].OperatorDesc;
                            break;
                        }
                    case enmPropertyType.NumericalType:
                        {
                            TheComboCell.Items.Add(P_arr_Operatores[0].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[2].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[3].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[4].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[5].OperatorDesc);
                            TheComboCell.Value = P_arr_Operatores[0].OperatorDesc;
                            break;
                        }
                    case enmPropertyType.StringType:
                        {
                            TheComboCell.Items.Add(P_arr_Operatores[0].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[1].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[6].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[7].OperatorDesc);
                            TheComboCell.Value = P_arr_Operatores[6].OperatorDesc;
                            break;
                        }
                    case enmPropertyType.CustomType:
                        {

                            TheComboCell.Items.Add(P_arr_Operatores[0].OperatorDesc);
                            TheComboCell.Items.Add(P_arr_Operatores[1].OperatorDesc);
                            TheComboCell.Value = P_arr_Operatores[0].OperatorDesc;

                            break;
                        }
                     
                }
                return TheComboCell;
            }

            //private DataGridViewComboBoxCell CreateTheValueComboItems(string prmPropertyKey)
            //{
            ////DataGridViewComboBoxCell TheComboCell = new DataGridViewComboBoxCell();
            //    //BaranDataAccess.Safe.dstReasonTypes ReasonTypeDst;
            //    //ReasonTypeDst = BaranDataAccess.Safe.dstReasonTypes.GetSafeReasonType();

            //    //if (prmPropertyKey == cnsFilterPropertiesKey.SafeOperationTypeName)
            //    //{
            //    //    TheComboCell.DataSource = ReasonTypeDst.spr_Saf_SafeReasonType_Select;
            //    //    TheComboCell.ValueMember = ReasonTypeDst.spr_Saf_SafeReasonType_Select.SafeReasonTypeIDColumn.ColumnName;
            //    //    TheComboCell.DisplayMember = ReasonTypeDst.spr_Saf_SafeReasonType_Select.SafeReasonTypeNameColumn.ColumnName;

            //    //}

            //    //else if (prmPropertyKey == cnsFilterPropertiesKey.FactorCalculationType)
            //    //{
            //    //    //BaranDataAccess.Factors.dstFactors FactorCalcDst;
            //    //    //FactorCalcDst = Baran.Classes.Common.FactorCalculationType.Instance.DstFactorCalculationTypes;

            //    //    //TheComboCell.DataSource = FactorCalcDst.spr_Fac_FactorCalculationTypes_Select;
            //    //    //TheComboCell.ValueMember = FactorCalcDst.spr_Fac_FactorCalculationTypes_Select.FactorCalculationTypeIDColumn.ColumnName;
            //    //    //TheComboCell.DisplayMember = FactorCalcDst.spr_Fac_FactorCalculationTypes_Select.FactorCalculationTypeColumn.ColumnName;
            //    //}

            //    else if (prmPropertyKey == cnsFilterPropertiesKey.FactorOperationType)
            //    {
            //        //BaranDataAccess.Factors.dstFactors FactorOptType;
            //        //FactorOptType = Baran.Classes.Common.FactorOperationTypes.Instance.DstFactorOperationType;

            //        //TheComboCell.DataSource = FactorOptType.spr_Fac_FactorOperationTypes_Select;
            //        //TheComboCell.ValueMember = FactorOptType.spr_Fac_FactorOperationTypes_Select.FactorOperationTypeIDColumn.ColumnName;
            //        //TheComboCell.DisplayMember = FactorOptType.spr_Fac_FactorOperationTypes_Select.FactorOperationTypeFAColumn.ColumnName;
            //    }

            //    else if (prmPropertyKey == cnsFilterPropertiesKey.Persons)
            //    {
            //        //BaranDataAccess.Persons.dstPersons PersonDst;
            //        //PersonDst = Baran.Classes.Singleton.Persons.Instance.DstPersons;

            //        //TheComboCell.DataSource = PersonDst.spr_Per_Persons_Select;
            //        //TheComboCell.ValueMember = PersonDst.spr_Per_Persons_Select.PersonIDColumn.ColumnName;
            //        //TheComboCell.DisplayMember = PersonDst.spr_Per_Persons_Select.PersonCompleteNameColumn.ColumnName;
            //    }

            //    else if (prmPropertyKey == cnsFilterPropertiesKey.Stores)
            //    {
            //        //BaranDataAccess.Stores.dstStores StoresDst;
            //        //StoresDst = Baran.Classes.Singleton.Stores.Instance.DstStores;

            //        //TheComboCell.DataSource = StoresDst.spr_str_Stores_Select;
            //        //TheComboCell.ValueMember = StoresDst.spr_str_Stores_Select.StoreIDColumn.ColumnName;
            //        //TheComboCell.DisplayMember = StoresDst.spr_str_Stores_Select.StoreNameColumn.ColumnName;
            //    }
            //    return TheComboCell;
            //}

            private void frmFilter_Load(object sender, EventArgs e)
            {

                P_arr_Operatores[0].OperatorDesc = "برابر";
                P_arr_Operatores[0].OperatorSQL = "=";

                P_arr_Operatores[1].OperatorDesc = "نا برار";
                P_arr_Operatores[1].OperatorSQL = "<>";

                P_arr_Operatores[2].OperatorDesc = "کوچکتر از";
                P_arr_Operatores[2].OperatorSQL = "<";

                P_arr_Operatores[3].OperatorDesc = "کوچکتر مساوی با";
                P_arr_Operatores[3].OperatorSQL = "<=";

                P_arr_Operatores[4].OperatorDesc = "بزرگتر از";
                P_arr_Operatores[4].OperatorSQL = ">";

                P_arr_Operatores[5].OperatorDesc = "بزرگتر مساوی با";
                P_arr_Operatores[5].OperatorSQL = ">=";

                P_arr_Operatores[6].OperatorDesc = "شامل";
                P_arr_Operatores[6].OperatorSQL = "LIKE";

                P_arr_Operatores[7].OperatorDesc = "غیر از";
                P_arr_Operatores[7].OperatorSQL = "NOT LIKE";

                this.UpdateGrid();

            }

        #endregion

            private void btnCancle_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            private void btnClear_Click(object sender, EventArgs e)
            {

                for (int i = 0; i <= arrCurrentProperties.Length - 1; i++)
                {
                    arrCurrentProperties[i].ProperySelectedValue = string.Empty;
                    arrCurrentProperties[i].ProperySelectedOperator = string.Empty;
                }

                this.UpdateGrid();

            }

            private void btnOK_Click(object sender, EventArgs e)
            {
                FilterIsOn = false;

                for (int i = 0; i <= grdFilter.Rows.Count - 1; i++)
                {
                    DataGridViewRow dgrdRow = new DataGridViewRow();
                    //dgrdRow = grdFilter.Rows[i];

                    object objValue = dgrdRow.Cells[2].Value;

                    if (objValue == null)
                    {
                        arrCurrentProperties[i].ProperySelectedValue = null; // string.Empty;
                        continue;
                    }
                    else
                        FilterIsOn = true;


                    switch (arrCurrentProperties[i].ProperyType)
                    {

                        case enmPropertyType.NumericalType:
                            {
                                long Num;
                                bool isnum = Int64.TryParse(objValue.ToString(), out Num);
                                if ((isnum == false)) 
                                   {
                                        MessageBox.Show(("The property " + (arrCurrentProperties[i].ProperyText + " has invalid value.")));
                                        return;
                                    }
                                break;
                            }

                        case enmPropertyType.DateType:
                            {
                                DateTime Date;
                                bool isDate = DateTime.TryParse(objValue.ToString(), out Date);
                                MessageBox.Show("The property " + arrCurrentProperties[i].ProperyText + " has invalid value.");
                                break;
                            }

                        case enmPropertyType.StringType:
                            {
                                objValue = objValue.ToString().Replace("'", string.Empty); //for preventing injection
                                objValue = objValue.ToString().Replace("-", string.Empty); //for preventing injection
                                break;
                            }

                        case enmPropertyType.BooleanType:
                            {
                                if(objValue.ToString() == arrCurrentProperties[i].PropertyValueTextTrue)
                                    objValue = true;
                                else
                                    objValue = false;

                                break;
                            }

                        case enmPropertyType.CustomType:
                            {
                                break;
                            }
                    }

                    var lnqOperator = (from le in P_arr_Operatores where le.OperatorDesc == dgrdRow.Cells[1].Value.ToString() select le ).ToArray();

                    arrCurrentProperties[i].ProperySelectedOperator = lnqOperator[0].OperatorSQL; //OperatorSQL

                    if((arrCurrentProperties[i].ProperySelectedOperator.ToString().Trim() == "LIKE" ) || (arrCurrentProperties[i].ProperySelectedOperator.ToString().Trim() == "NOT LIKE"))
                    {
                        objValue = "%" + objValue + "%";
                    }

                    arrCurrentProperties[i].ProperySelectedValue = objValue;
                }

                DialogResult = DialogResult.OK;
                this.Close();

            }

        #region Events

        #endregion

    }
}
