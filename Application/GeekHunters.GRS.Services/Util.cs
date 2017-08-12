using System.Configuration;

namespace GeekHunters.GRS.Services
{
    public class Util
    {
        public static string DatabasePath
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabasePath"];
            }
        }
    }
}
