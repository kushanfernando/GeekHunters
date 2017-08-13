using System.Configuration;

namespace GeekHunters.GRS.Services
{
    public class Util
    {
        public static string SqliteConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SqliteConnectionString"].ConnectionString;
            }
        }

        public static string ApplicationName
        {
            get
            {
                return ConfigurationManager.AppSettings["ApplicationName"];
            }
        }
    }
}
