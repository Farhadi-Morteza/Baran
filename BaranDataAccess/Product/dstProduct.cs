namespace BaranDataAccess.Product
{


    public partial class dstProduct
    {
        public static dstProduct FertilizerCategoryCmbTable()
        {
            dstProduct returnDst = new dstProduct();
            dstProductTableAdapters.spr_src_FertilizerCategory_cmb_SelectTableAdapter adapter =
                new dstProductTableAdapters.spr_src_FertilizerCategory_cmb_SelectTableAdapter();
            try
            {
                adapter.FillFertilizerCategoryCmbTable(returnDst.spr_src_FertilizerCategory_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstProduct PesticideCategoryCmbTable()
        {
            dstProduct returnDst = new dstProduct();
            dstProductTableAdapters.spr_src_PesticideCategory_cmb_SelectTableAdapter adapter =
                new dstProductTableAdapters.spr_src_PesticideCategory_cmb_SelectTableAdapter();
            try
            {
                adapter.FillPesticideCategoryTable(returnDst.spr_src_PesticideCategory_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstProduct PersonCategoryCmbTable()
        {
            dstProduct returnDst = new dstProduct();
            dstProductTableAdapters.spr_src_PersonCategory_cmb_SelectTableAdapter adapter =
                new dstProductTableAdapters.spr_src_PersonCategory_cmb_SelectTableAdapter();
            try
            {
                adapter.FillPersonCategoryCmbTable(returnDst.spr_src_PersonCategory_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstProduct PersonByPersosnCategoryCmbTable(int? personCategoryID, int userID)
        {
            dstProduct returnDst = new dstProduct();
            dstProductTableAdapters.spr_src_PersonByPersonCategoriID_Cmb_SelectTableAdapter adapter =
                new dstProductTableAdapters.spr_src_PersonByPersonCategoriID_Cmb_SelectTableAdapter();
            try
            {
                adapter.FillPersonByPersonCategoryIDCmbTable(returnDst.spr_src_PersonByPersonCategoriID_Cmb_Select, personCategoryID, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstProduct ChemicalAnalysCategoryCmbTable()
        {
            dstProduct returnDst = new dstProduct();
            dstProductTableAdapters.spr_src_ChemicalAnalysCategory_cmb_SelectTableAdapter adapter =
                new dstProductTableAdapters.spr_src_ChemicalAnalysCategory_cmb_SelectTableAdapter();
            try
            {
                adapter.FillChemicalAnalysCategoryTable(returnDst.spr_src_ChemicalAnalysCategory_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstProduct TreeTypeCmdTable()
        {
            dstProduct returnDst = new dstProduct();
            dstProductTableAdapters.spr_src_TreeType_Cmd_SelectTableAdapter adapter =
                new dstProductTableAdapters.spr_src_TreeType_Cmd_SelectTableAdapter();
            try
            {
                adapter.FillTreeTypeCmdTable(returnDst.spr_src_TreeType_Cmd_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstProduct FertilizerElementTable(int fertilizerID)
        {
            dstProduct returnDst = new dstProduct();

            dstProductTableAdapters.spr_src_FertilizerElement_selectTableAdapter adapter =
                new dstProductTableAdapters.spr_src_FertilizerElement_selectTableAdapter();
            try
            {
                adapter.FillFertilizerElementTable(returnDst.spr_src_FertilizerElement_select, fertilizerID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstProduct FertilizerCmdLstTable()
        {
            dstProduct returnDst = new dstProduct();
            dstProductTableAdapters.spr_src_Fertilizer_cmbLst_SelectTableAdapter adapter =
                new dstProductTableAdapters.spr_src_Fertilizer_cmbLst_SelectTableAdapter();
            try
            {
                adapter.FillFertilizerCmdLstTable(returnDst.spr_src_Fertilizer_cmbLst_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }
    }
}
