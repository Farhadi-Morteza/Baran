namespace BaranDataAccess.Common 
{
    
    
    public partial class dstImages 
    {
        public static void InsertImage(byte[] Img, int itemID)
        {
            dstImagesTableAdapters.InsertImageTableAdapter adapter =
                new BaranDataAccess.Common.dstImagesTableAdapters.InsertImageTableAdapter();

            try
            {
                adapter.spr_Cmn_InsertImageIntoTable_Update(Img, itemID);
            }
            catch
            {
            }
        }

    }
}
