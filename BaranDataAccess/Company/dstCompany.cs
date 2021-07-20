namespace BaranDataAccess.Company {
    
    
    public partial class dstCompany 
    {
        public static dstCompany CompanyCategoryTable()
        {
            dstCompany returnDst = new dstCompany();
            dstCompanyTableAdapters.spr_src_CompanyCategory_SelectTableAdapter adapter =
                new dstCompanyTableAdapters.spr_src_CompanyCategory_SelectTableAdapter();
            try
            {
                adapter.FillCompanyCategoryTable(returnDst.spr_src_CompanyCategory_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCompany CompanyTable(long userID)
        {
            dstCompany returnDst = new dstCompany();
            dstCompanyTableAdapters.spr_src_Company_SelectTableAdapter adapter =
                new dstCompanyTableAdapters.spr_src_Company_SelectTableAdapter();
            try
            {
                adapter.FillCompanyTable(returnDst.spr_src_Company_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCompany CollectionTable(long userID)
        {
            dstCompany returnDst = new dstCompany();
            dstCompanyTableAdapters.spr_src_Collection_SelectTableAdapter adapter =
                new dstCompanyTableAdapters.spr_src_Collection_SelectTableAdapter();
            try
            {
                adapter.FillCollectionTable(returnDst.spr_src_Collection_Select, userID);
            }
            catch 
            {

                returnDst = null;
            }
            return returnDst;
        }

        public static dstCompany SubcollectionTable(long userID)
        {
            dstCompany returnDst = new dstCompany();
            dstCompanyTableAdapters.spr_src_Subcollection_SelectTableAdapter adapter =
                new dstCompanyTableAdapters.spr_src_Subcollection_SelectTableAdapter();
            try
            {
                adapter.FillSubcollectionTable(returnDst.spr_src_Subcollection_Select, userID);
            }
            catch 
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCompany PartTable(long userID)
        {
            dstCompany returnDst = new dstCompany();
            dstCompanyTableAdapters.spr_src_Part_SelectTableAdapter adapter =
                new dstCompanyTableAdapters.spr_src_Part_SelectTableAdapter();
            try
            {
                adapter.FillPartTable(returnDst.spr_src_Part_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }
    }

    }

