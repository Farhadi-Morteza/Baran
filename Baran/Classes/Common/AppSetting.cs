
namespace Baran.Classes.Common
{
    public class AppSetting
    {
        System.Configuration.Configuration config;

        public AppSetting()
        {
            config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
        }

        public string GetConnectionStrion(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        public void SaveConnectionStrin(string key, string Value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = Value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            config.Save(System.Configuration.ConfigurationSaveMode.Modified);
        }


    }
}
