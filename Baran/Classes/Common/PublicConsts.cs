using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Classes.Common
{
    class PublicConsts
    {
    }

    #region cnsFilterPropertiesKey

    public static class cnsFilterPropertiesKey
    {
        public static readonly string FromDateTime = "FromDateTime";
        public static readonly string ToDateTime = "ToDateTime";
        public static readonly string FromDate = "FromDate";
        public static readonly string ToDate = "ToDate";
        public static readonly string Date = "Date";
        public static readonly string OneDate = "OneDate";
        public static readonly string OneDate_DatetimeType = "OneDate_DatetimeType";
        public static readonly string DocumentNumber = "DocumentNumber";

        public static readonly string Collection = "Collection";
        public static readonly string Subcollection = "Subcollection";
        public static readonly string Part = "Part";


        public static readonly string SafeReasonTypes = "SafeReasonTypes";
        public static readonly string RecievePaymentTypeName = "RecievePaymentTypeName";
        public static readonly string FactorCalculationType = "FactorCalculationType";
        public static readonly string FactorOperationType = "FactorOperationType";
        public static readonly string Persons = "Persons";
        public static readonly string Stores = "Stores";
        public static readonly string Goods = "Goods";
        public static readonly string GoodCode = "GoodCode";
        public static readonly string PersonalCheques = "PersonalCheques";
        public static readonly string CostumerCheques = "CostumerCheques";
        public static readonly string Bank = "Bank";
        public static readonly string ChequeNumber = "ChequeNumber";
        public static readonly string MatureDate = "MatureDate";

        public static readonly string ChequeCashed = "ChequeCashed";
        public static readonly string ChequeHandedOver = "ChequeHandedOver";
        public static readonly string ChequeCollected = "ChequeCollected";
        public static readonly string ChequeProtested = "ChequeProtested";
        public static readonly string ChequeSpended = "ChequeSpended";
        public static readonly string ChequeRollBacked = "ChequeRollBacked";
    }
    #endregion

    #region cnsFilterPropertiesName
    public static class cnsFilterPropertiesName
    {
        public static readonly string FromDateTime = "از تاریخ";
        public static readonly string ToDateTime = "تا تاریخ";
        public static readonly string FromDate = "از تاریخ";
        public static readonly string ToDate = "تا تاریخ";
        public static readonly string Date = "تاریخ";
        public static readonly string OneDate = "تاریخ";
        public static readonly string OneDate_DatetimeType = "تاریخ";
        public static readonly string DocumentNumber = "شماره سند";
        public static readonly string Amount = "مبلغ";
        public static readonly string FactorNumber = "شماره فاکتور";
        public static readonly string SafeOperationTypeName = "نوع عملیات";
        public static readonly string FactorCalculationType = "نوع عملیات";
        public static readonly string FactorOperationType = "نوع فاکتور";
        public static readonly string Persons = "طرف حساب";
        public static readonly string Stores = "انبار";
        public static readonly string Goods = "کالا";
        public static readonly string GoodCode = "کد کالا";
        public static readonly string RecievePaymentTypeName = "نوع تراکنش";
        public static readonly string SafeReasonTypes = "عنوان کل";
        public static readonly string PersonalCheques = "چک های حسابهای شخصی";
        public static readonly string CostumerCheques = "چک های دریافتی از مشتریان";
        public static readonly string Bank = "بانک";
        public static readonly string ChequeNumber = "شماره چک";
        public static readonly string MatureDate = "تاریخ سررسید چک";

        public static readonly string ChequeCashed = "چک ها نقد شده";
        public static readonly string ChequeHandedOver = "چک های واگذار شده";
        public static readonly string ChequeCollected = "چک های وصولی";
        public static readonly string ChequeProtested = "چک های واخواستی";
        public static readonly string ChequeSpended = "چک های خرج شده";
        public static readonly string ChequeRollBacked = "چک های برگردانده شده";
    }
    #endregion

    #region cnsToolStripButton
    public static class cnsToolStripButton
    {
        public static readonly string Cancel            = "toolStripButtonCancel";
        public static readonly string Save              = "toolStripButtonSave";
        public static readonly string Delete            = "toolStripButtonDelete";
        public static readonly string Change            = "toolStripButtonChange";
        public static readonly string New               = "toolStripButtonNew";
        public static readonly string Clear             = "toolStripButtonClear";
        public static readonly string Refresh           = "toolStripButtonRefresh";
        public static readonly string Filter            = "toolStripButtonFilter";
        public static readonly string Print             = "toolStripButtonPrint";
        public static readonly string Confirm           = "toolStripButtonConfirm";
        public static readonly string ButoonLast        = "toolStripButtonLast";
        public static readonly string ButoonNext        = "toolStripButtonNext"; 
        public static readonly string DocumentNumber    = "DocumentNumber";
        public static readonly string NumberOfRecords   = "toolStripTextBoxNumberOfRecords"; 
        public static readonly string Buttonprevious    = "toolStripButtonprevious";
        public static readonly string ButtonFirstRecord = "toolStripButtonFirstRecord";
        public static readonly string ProgressBar       = "toolStripButtonProgressBar";
        public static readonly string Export            = "toolStripButtonExport";
        public static readonly string Exit              = "toolStripButtonExit";
        public static readonly string Detail            = "toolStripButtonDetail";

    }
    #endregion

    #region cnsMenustripItems
    public static class cnsMenustripItems
    {
        public static readonly string Cancel    = "tolMenuItemCansel";
        public static readonly string Save      = "tolMenuItemSave";
        public static readonly string Delete    = "tolMenuItemDelete";
        public static readonly string Change    = "tolMenuItemChange";
        public static readonly string New       = "tolMenuItemNew";
        public static readonly string Clear     = "tolMenuItemClear";
        public static readonly string Refresh   = "tolMenuItemRefresh";
        public static readonly string Filter    = "tolMenuItemFilter";
        public static readonly string Print     = "tolMenuItemPrint";
        public static readonly string Confirm   = "tolMenuItemConfirm";

        public static readonly string Cash = "tolMenuItemCash";
        public static readonly string Cheque = "tolMenuItemCheque";
        public static readonly string Pos = "tolMenuItemPos";

        public static readonly string Export = "tolMenuItemExport";
        public static readonly string Detail = "tolMenuItemDetail";


    }
    #endregion

    #region cnsFormItemID
    public static class cnsFormItemID
    {
        public static readonly int ChequeReceive            = 33;
        public static readonly int ChequePayment            = 36;
        public static readonly int Receive                  = 10;
        public static readonly int Payment                  = 14;
        public static readonly int SalesFactor              = 4;
        public static readonly int BuyFactor                = 2;
        public static readonly int BuyReturnFactor          = 6;
        public static readonly int SalesReturnFactor        = 9;
        public static readonly int BuyProforma              = 128;
        public static readonly int CominStore               = 131;
        public static readonly int SaleProforma             = 129;
        public static readonly int OutofStore               = 130;

        public static readonly int BackFromBuy              = 58;
        public static readonly int BackFromSale             = 59;
        public static readonly int BuyFactorsList           = 60;
        public static readonly int SaleFactorsList          = 61;
        public static readonly int BuyFactorsDailyReport    = 77;
        public static readonly int SaleFactorsDailyReport   = 79;
        public static readonly int FactorSettings           = 109;
        public static readonly int OfficialBuyInvoice       = 138;
        public static readonly int OfficialSalesInvoice     = 139;

        public static readonly int StorePartitions          = 37;
        public static readonly int StorePartitionsList      = 38;
        public static readonly int StorePartitionsAmend     = 39;
        public static readonly int Stores                   = 40;
        public static readonly int StoresList               = 41;
        public static readonly int StoresAmend              = 42;
        public static readonly int GoodsGroup               = 48;
        public static readonly int UserAmend                = 29;
        public static readonly int Users                    = 19;
        public static readonly int GoodsList                = 48;
        public static readonly int Goods                    = 17;
        public static readonly int GoodAmend                = 100;
        public static readonly int GoodsKarteksList         =64;
        public static readonly int Persons                  = 15;
        public static readonly int PersonAmend              = 57;
        public static readonly int PersonGroups             = 74;
        public static readonly int PersonsList              = 27;

        public static readonly int SafeRecieveChart         = 66;
        public static readonly int SafePaymentChart         = 67;

        public static readonly int GoodQuantityChart        = 65;
        public static readonly int GoodPriceChart           = 68;

        public static readonly int ChequeList               = 81;
        public static readonly int ChequeCashed             = 82;
        public static readonly int ChequeHandOvered         = 83;
        public static readonly int ChequeCollected          = 84;
        public static readonly int ChequeProtested          = 85;
        public static readonly int ChequeRollBalcked        = 86;
        public static readonly int ChequeAmend              = 98;

        public static readonly int Partner                  = 93;
        public static readonly int PartnerList              = 94;
        public static readonly int BankAccount              = 89;
        public static readonly int BankAccountList          = 90;
        public static readonly int Bank                     = 91;
        public static readonly int BankList                 = 92;

        public static readonly int CashAmend                = 111;
        public static readonly int PosAmend                 = 113;

        public static readonly int InComeList               = 114;
        public static readonly int InCome                   = 115;
        public static readonly int CostList                 = 116;
        public static readonly int Cost                     = 117;
        public static readonly int AssetList                = 119;
        public static readonly int Asset                    = 120;
        public static readonly int OtherList                = 121;
        public static readonly int Other                    = 122;

        public static readonly int PersonAccountBalanceDetails = 123;
        public static readonly int PosDeviceList            = 124;
        public static readonly int PosDevice                = 125;
        public static readonly int ChequeDocumetnRecieved   = 106;
        public static readonly int ChequeDocumetnPayment    = 107;

        public static readonly int ElectronicAmend          = 134;
        public static readonly int FundRecived              = 140;
        public static readonly int FundPayment              = 141;
        public static readonly int frmSandoghTransaction    = 132;
        public static readonly int frmProductFormula        = 144;
        public static readonly int frmProductPackage        = 146;
        public static readonly int frmProductOverhead       = 148;
        public static readonly int frmGoodKarteks           = 151;
        public static readonly int frmProductionOrder       = 150;
        
    }
    #endregion

    #region cnsPictureMessageType
    public static class cnsPictureMessageType
    {
        public static readonly int Success = 1;
        public static readonly int Error = 2;
        public static readonly int Information = 3;
        public static readonly int Warning = 4;
    }
    #endregion

    public static class cnsPictureMessagePosition
    {
        public static readonly int Right = 1;
        public static readonly int Left = 2;
    }

    #region cnsPictureName
    public static class cnsPictureName
    {
        public static readonly string Exit = "Exit.png";
        public static readonly string picSuccess16 = "Success16.png";
        public static readonly string picError16 = "Error16.png";
        public static readonly string picInformation16 = "Information16.png";
        public static readonly string picWarning16 = "Warning16.png";
        public static readonly string ProgressBar = "ProgressBar.gif";
        public static readonly string Calandar = "Calandar.png";
        public static readonly string Calandar16 = "Calandar16.png";
        public static readonly string Cancel = "Cancel.png";
        public static readonly string Cancel16 = "Cancel16.png";
        public static readonly string Check16 = "Check16.png";
        public static readonly string Check = "Check.png";
        public static readonly string clear = "clear.png";
        public static readonly string clear16 = "clear16.png";
        public static readonly string clock = "clock.png";
        public static readonly string clock16 = "clock16.png";
        public static readonly string Close = "Close.png";
        public static readonly string Close16 = "Close16.png";
        public static readonly string delete = "delete.png";
        public static readonly string delete16 = "delete16.png";
        public static readonly string End = "End.png";
        public static readonly string End16 = "End16.png";
        public static readonly string filter = "filter.png";
        public static readonly string filter16 = "filter16.png";
        public static readonly string First = "First.png";
        public static readonly string First16 = "First16.png";
        public static readonly string New = "New.png";
        public static readonly string New16 = "New16.png";
        public static readonly string Next = "Next.png";
        public static readonly string Next16 = "Next16.png";
        public static readonly string Previous = "Previous.png";
        public static readonly string Previous16 = "Previous16.png";
        public static readonly string printer = "printer.png";
        public static readonly string printer16 = "printer16.png";
        public static readonly string refresh = "refresh.png";
        public static readonly string refresh16 = "refresh16.png";
        public static readonly string Change = "replace.png";
        public static readonly string Change16 = "replace16.png";
        public static readonly string Save = "Save.png";
        public static readonly string Save16 = "Save16.png";
        public static readonly string User = "User.png";
        public static readonly string User16 = "User16.png";
        public static readonly string Login = "Login.png";
        public static readonly string Building = "Building.png";
        public static readonly string Building16 = "Building16.png";
        public static readonly string Calculator = "Calculator.png";
        public static readonly string Calculator16 = "Calculator16.png";
        public static readonly string Electronic32 = "Electronic32.png";
        public static readonly string Electronic16 = "Electronic16.png";
        public static readonly string Cash16 = "Cash16.png";
        public static readonly string Cheque16 = "Cheque16.png";
        public static readonly string maximize16 = "maximize16.png";
        public static readonly string minimize16 = "minimize16.png";
        public static readonly string minimize = "minimize.png";
        public static readonly string ExportExcel = "ExportExcel.png";
        public static readonly string ExportExcel16 = "ExportExcel16.png";
        public static readonly string Export = "Export.png";
        public static readonly string Export16 = "Export16.png";
        public static readonly string Zoom = "Zoom.png";
        public static readonly string Zoom16 = "Zoom16.png";
        public static readonly string PrintPreView = "PrintPreView.png";
        public static readonly string PrintPreView16 = "PrintPreView16.png";
        public static readonly string ShowPass = "ShowPass.png";
        public static readonly string HiddenPass = "HiddenPass.png";
        public static readonly string UserName = "UserName.png";
        public static readonly string Password= "Password.png";
        public static readonly string Map64 = "map.png";
        public static readonly string Doc = "Doc.png";
        public static readonly string Doc16 = "Doc16.png";
        public static readonly string Crops = "Crops.png";
        public static readonly string Field = "Field.png";
        public static readonly string Detail = "Detail.png";
        public static readonly string Detail16 = "Detail16.png";

        public static readonly string PartMarker = "PartMarker.png";
        public static readonly string FieldMarker = "FieldMarker.png";
        public static readonly string LandMarker = "LandMarker.png";
        public static readonly string BuildingMarker = "BuildingMarker.png";
        public static readonly string WarehouseMarker = "WarehouseMarker.png";
        public static readonly string WaterMarker = "WaterMarker.png";
        public static readonly string WaterStorageMarker = "WaterStorageMarker.png";
        public static readonly string WaterTransmissionLineMarker = "WaterTransmissionLineMarker.png";

        public static readonly string TreeMarker = "TreeMarker.png";
        public static readonly string WaterWell = "WaterWell.png";
        public static readonly string AddMarker = "AddMarker.png";
    }
    #endregion

    #region cnsFilterActioon
    public static class cnsFilterActioon
    {
        public static readonly int WithoutFilter = 1;
        public static readonly int OnFilter = 2;
        public static readonly int WithoutFilter2 = 3;
        public static readonly int OnFilter2 = 4;
    }
    #endregion

    #region cnsReportSetting
    public static class cnsReportSetting
    {
        public static readonly int A4 = 1;
        public static readonly int A5 = 2;
        public static readonly int A6 = 3;
        public static readonly int Automatic = 4;
    }
    #endregion

    #region cnsReportName
    public static class cnsReportName
    {
        public static readonly string CrFactor = "CrFactor";
        public static readonly string CrFactorA5 = "CrFactorA5";
        public static readonly string CrFactorA6 = "CrFactorA6"; 
    }
    #endregion

    #region cnsUnitConverters
    public static class cnsUnitConverters
    {
        public static readonly double InchPerMillimeter = 25.4d;
        public static readonly double MillimeterPerTWIPS = 56.6929133858d;
    }
    #endregion

    #region PageMarginPrint  mm
    public static class cnsPageMarginPrint
    {
        public static readonly int TopMargin = 2;
        public static readonly int LeftMargin = 5;
    }
    #endregion

    #region MeasurementCategory
    public static class cnsMeasurementCategory
    {
        public static readonly int Pieces = 1;
        public static readonly int Weight = 2;
        public static readonly int Volume = 3;
        public static readonly int Length = 4;
    }
#endregion

    #region MeasurementCategory
    public static class cnschildBaseButtonsName
    {
        public static readonly string Cancel = "grpCancel";
        public static readonly string Save = "grpSave";
        public static readonly string Change = "grpChange";
        public static readonly string Clear = "grpClear";
        public static readonly string Delete = "grpDelete";
        public static readonly string Doc = "grpDoc";
        public static readonly string Print = "grpPrint";
        public static readonly string Refresh = "grpRefresh";
    }
    #endregion

    #region FormType
    public static class cnsFormType
    {
        public static readonly int New = 1;
        public static readonly int Change = 2;
        public static readonly int Other = 3;
    }
    #endregion

    #region MaxRowCountOngrdDoc
    public static class cnsgrdDoc
    {
        public static readonly int MaxRowCount = 3;
        public static readonly int Margin = 35;
    }
    #endregion

    #region Person Category
    public static class cnsPersonCategory
    {
        public static readonly int Manager = 1;
        public static readonly int Worker = 2;
        public static readonly int Expert = 3;
    }
    #endregion

    #region Task Category
    public static class cnsTaskCategory
    {
        public static readonly int ChemicalAnalysis = 1;
        public static readonly int Fertilizer = 2;
        public static readonly int Protection = 5;
        public static readonly int Irrigation = 9;

    }
    #endregion

    public static class ColumnKey
    {
        public static readonly string RowID = "RowID";
        public static readonly string New = "New";
        public static readonly string Delete = "Delete";
        public static readonly string Update = "Update";
        public static readonly string Detail = "Detail";
    }

}
