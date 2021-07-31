namespace BaranDataAccess.Source
{


    public partial class dstSource
    {
        public static dstSource FieldTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Field_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Field_SelectTableAdapter();
            try
            {
                adapter.FillFieldTable(returnDst.spr_src_Field_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource FieldByIDTable(int fieldID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_FieldByID_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_FieldByID_SelectTableAdapter();
            try
            {
                adapter.FillFieldByIDTable(returnDst.spr_src_FieldByID_Select, fieldID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource FieldListTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Field_Lst_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Field_Lst_SelectTableAdapter();
            try
            {
                adapter.FillFeildListTable(returnDst.spr_src_Field_Lst_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource FieldViewTable(int fieldID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Field_Vew_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Field_Vew_SelectTableAdapter();
            try
            {
                adapter.FillFieldViewTable(returnDst.spr_src_Field_Vew_Select, fieldID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Water_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Water_SelectTableAdapter();
            try
            {
                adapter.FillWaterTable(returnDst.spr_src_Water_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterByIDTable(int waterID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterByID_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterByID_SelectTableAdapter();
            try
            {
                adapter.FillWaterByIDTable(returnDst.spr_src_WaterByID_Select, waterID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterByPartIDTable(int partID, int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Water_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Water_SelectTableAdapter();
            try
            {
                adapter.FillWaterByPartIDTable(returnDst.spr_src_Water_Select, partID, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterListTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Water_Lst_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Water_Lst_SelectTableAdapter();
            try
            {
                adapter.FillWaterListTable(returnDst.spr_src_Water_Lst_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterViewTable(int waterID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Water_Vew_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Water_Vew_SelectTableAdapter();
            try
            {
                adapter.FillWaterViewTable(returnDst.spr_src_Water_Vew_Select, waterID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterByUserIDCmbTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterByUserID_cmb_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterByUserID_cmb_SelectTableAdapter();
            try
            {
                adapter.FillWaterByUserIDCmbTable(returnDst.spr_src_WaterByUserID_cmb_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WarehouseTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Warehouse_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Warehouse_SelectTableAdapter();
            try
            {
                adapter.FillWarehouseTable(returnDst.spr_src_Warehouse_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WarehouseByIDTable(int warehouseID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WarehouseByID_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WarehouseByID_SelectTableAdapter();
            try
            {
                adapter.FillWarehouseByIDTable(returnDst.spr_src_WarehouseByID_Select, warehouseID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WarehouseListTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Warehouse_Lst_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Warehouse_Lst_SelectTableAdapter();
            try
            {
                adapter.FillWarehouseListTable(returnDst.spr_src_Warehouse_Lst_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WarehouseViewTable(int warehouseID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Warehouse_Vew_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Warehouse_Vew_SelectTableAdapter();
            try
            {
                adapter.FillWarehouseViewTable(returnDst.spr_src_Warehouse_Vew_Select, warehouseID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource MachineryTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Machinery_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Machinery_SelectTableAdapter();
            try
            {
                adapter.FillMachineryTable(returnDst.spr_src_Machinery_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource MachineryByIDTable(int machineryID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_MachineryByID_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_MachineryByID_SelectTableAdapter();
            try
            {
                adapter.FillMachineryByIDTable(returnDst.spr_src_MachineryByID_Select, machineryID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource MachineryByUserIDCmbTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_MachineryByUserID_cmb_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_MachineryByUserID_cmb_SelectTableAdapter();
            try
            {
                adapter.FillMachineryByUserIDCmbTable(returnDst.spr_src_MachineryByUserID_cmb_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource MachineryListTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Machinery_Lst_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Machinery_Lst_SelectTableAdapter();
            try
            {
                adapter.FillMachineryLstSelect(returnDst.spr_src_Machinery_Lst_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource MachineryViewTable(int machineryID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Machinery_Vew_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Machinery_Vew_SelectTableAdapter();
            try
            {
                adapter.FillMachineryViewTable(returnDst.spr_src_Machinery_Vew_Select, machineryID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource BuildingsTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Buildings_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Buildings_SelectTableAdapter();
            try
            {
                adapter.FillBuildingsTable(returnDst.spr_src_Buildings_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource BuildingsByIDTable(int buildingsID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_BuildingsByID_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_BuildingsByID_SelectTableAdapter();
            try
            {
                adapter.FillBuildingsByIDTable(returnDst.spr_src_BuildingsByID_Select, buildingsID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource BuildingsListTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Buildings_Lst_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Buildings_Lst_SelectTableAdapter();
            try
            {
                adapter.FillBuildingsListTable(returnDst.spr_src_Buildings_Lst_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource BuildingsViewTable(int buildingsID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_Buildings_Vew_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_Buildings_Vew_SelectTableAdapter();
            try
            {
                adapter.FillBuildingsViewTable(returnDst.spr_src_Buildings_Vew_Select, buildingsID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterStorageTable()
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterStorage_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterStorage_SelectTableAdapter();
            try
            {
                adapter.FillWaterStorageTable(returnDst.spr_src_WaterStorage_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterStorageListTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterStorage_Lst_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterStorage_Lst_SelectTableAdapter();
            try
            {
                adapter.FillWaterStorageListTable(returnDst.spr_src_WaterStorage_Lst_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterStorageByIDTable(int waterStorageID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterStorage_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterStorage_SelectTableAdapter();
            try
            {
                adapter.FillWaterStorageByID(returnDst.spr_src_WaterStorage_Select, waterStorageID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterStorageDTable(int waterStorageID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterStorageD_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterStorageD_SelectTableAdapter();
            try
            {
                adapter.FillWaterStorageDTable(returnDst.spr_src_WaterStorageD_Select, waterStorageID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterStorageAndDetailsTable()
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterStorageAndDetails_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterStorageAndDetails_SelectTableAdapter();
            try
            {
                adapter.FillWaterStorageAndDetailsTable(returnDst.spr_src_WaterStorageAndDetails_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterStorageAndDetailsByIDTable(int waterStorageID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterStorageAndDetails_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterStorageAndDetails_SelectTableAdapter();
            try
            {
                adapter.FillWaterStorageByIDTable(returnDst.spr_src_WaterStorageAndDetails_Select, waterStorageID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterStorageViewTable(int waterStorageID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterStorage_Vew_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterStorage_Vew_SelectTableAdapter();
            try
            {
                adapter.FillWaterStorageViewTable(returnDst.spr_src_WaterStorage_Vew_Select, waterStorageID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterStorageByUserIDCmbTable(int userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterStorageByUserID_cmb_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterStorageByUserID_cmb_SelectTableAdapter();
            try
            {
                adapter.FillWaterStorageByUserIDCmbTable(returnDst.spr_src_WaterStorageByUserID_cmb_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterTransmissionLineListTable(long userID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterTransmissionLine_Lst_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterTransmissionLine_Lst_SelectTableAdapter();
            try
            {
                adapter.FillWaterTransmissionLineListTable(returnDst.spr_src_WaterTransmissionLine_Lst_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterTransmissionLineTable()
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterTransmissionLine_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterTransmissionLine_SelectTableAdapter();
            try
            {
                adapter.FillWaterTransmissionLineTable(returnDst.spr_src_WaterTransmissionLine_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterTransmissionLineByIDTable(int waterTransmissionLineID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterTransmissionLineByID_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterTransmissionLineByID_SelectTableAdapter();
            try
            {
                adapter.FillWaterTransmissionLineByIDTable(returnDst.spr_src_WaterTransmissionLineByID_Select, waterTransmissionLineID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSource WaterTransmissionLineViewTable(int waterTransmissionLineID)
        {
            dstSource returnDst = new dstSource();
            dstSourceTableAdapters.spr_src_WaterTransmissionLine_Vew_SelectTableAdapter adapter =
                new dstSourceTableAdapters.spr_src_WaterTransmissionLine_Vew_SelectTableAdapter();
            try
            {
                adapter.FillWaterTransmissionLineViewTable(returnDst.spr_src_WaterTransmissionLine_Vew_Select, waterTransmissionLineID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

    }
}
