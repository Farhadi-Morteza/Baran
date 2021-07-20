
namespace Baran.Classes.Common
{
    public class SqlHelper
    {
        System.Data.SqlClient.SqlConnection cn;

        public SqlHelper(string connectionString)
        {
            cn = new System.Data.SqlClient.SqlConnection(connectionString);
        }

        public bool IsConnecton
        {
            get
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                return true;
            }
        }
    }
}
