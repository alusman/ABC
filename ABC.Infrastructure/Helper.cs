using System.Configuration;

namespace ABC.Infrastructure
{
    public static class Helper
    {
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
