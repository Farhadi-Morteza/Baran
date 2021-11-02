namespace BaranDataAccess.Task
{


    public partial class dstTask
    {
        public static dstTask TaskCategoryCmbTable()
        {
            dstTask returnDst = new dstTask();
            dstTaskTableAdapters.spr_tsk_TaskCategori_Cmb_SelectTableAdapter adapter =
                new dstTaskTableAdapters.spr_tsk_TaskCategori_Cmb_SelectTableAdapter();
            try
            {
                adapter.FillTaskCategoryCmbTable(returnDst.spr_tsk_TaskCategori_Cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstTask TaskSubCategoryCmbTable()
        {
            dstTask returnDst = new dstTask();
            dstTaskTableAdapters.spr_tsk_TaskSubCategori_Cmb_SelectTableAdapter adapter =
                new dstTaskTableAdapters.spr_tsk_TaskSubCategori_Cmb_SelectTableAdapter();
            try
            {
                adapter.FillTaskSubCategoryCmbTable(returnDst.spr_tsk_TaskSubCategori_Cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstTask TaskSubCategoryByTaskCategoryIDCmbTable(int taskCategoryID)
        {
            dstTask returnDst = new dstTask();
            dstTaskTableAdapters.spr_tsk_TaskSubCategori_Cmb_SelectTableAdapter adapter =
                new dstTaskTableAdapters.spr_tsk_TaskSubCategori_Cmb_SelectTableAdapter();
            try
            {
                adapter.FillTaskSubCategoryByTaskCategoryIDTable(returnDst.spr_tsk_TaskSubCategori_Cmb_Select, taskCategoryID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstTask TaskCmbTable()
        {
            dstTask returnDst = new dstTask();
            dstTaskTableAdapters.spr_tsk_Task_cmb_SelectTableAdapter adapter =
                new dstTaskTableAdapters.spr_tsk_Task_cmb_SelectTableAdapter();
            try
            {
                adapter.FillTaskCmbTable(returnDst.spr_tsk_Task_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstTask TasklistCmbTable()
        {
            dstTask returnDst = new dstTask();
            dstTaskTableAdapters.spr_tsk_Tasklist_cmb_SelectTableAdapter adapter =
                new dstTaskTableAdapters.spr_tsk_Tasklist_cmb_SelectTableAdapter();
            try
            {
                adapter.FillTasklistCmbTable(returnDst.spr_tsk_Tasklist_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstTask TasklistCropCmbByCropIDTable(int cropID)
        {
            dstTask returnDst = new dstTask();
            dstTaskTableAdapters.spr_tsk_TasklistCrop_cmb_ByCropID_SelectTableAdapter adapter =
                new dstTaskTableAdapters.spr_tsk_TasklistCrop_cmb_ByCropID_SelectTableAdapter();
            try
            {
                adapter.FillTasklistCropcmbByCropIDTable(returnDst.spr_tsk_TasklistCrop_cmb_ByCropID_Select, cropID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }
    }
}
