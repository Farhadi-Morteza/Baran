namespace BaranDataAccess.Map
{


    public partial class dstLocation
    {
        public static dstLocation LocationTable()
        {
            dstLocation returnDst = new dstLocation();
            dstLocationTableAdapters.spr_geo_Location_SelectTableAdapter adapter =
                new dstLocationTableAdapters.spr_geo_Location_SelectTableAdapter();

            try
            {
                adapter.FillLocationTable(returnDst.spr_geo_Location_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstLocation LocationByIDTable(int? fieldID, int? buildingID, int? warehouseID, int? waterStorageID, int? waterID, int? waterTransmissionLineID, int? partID)
        {
            dstLocation returnDst = new dstLocation();
            dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter adapter =
                new dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter();

            try
            {
                adapter.FillLocationByIDTable(returnDst.spr_geo_LocationByID_Select, fieldID, buildingID, warehouseID, waterStorageID, waterID, waterTransmissionLineID, partID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }
    }
}
