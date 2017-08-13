using GeekHunters.GRS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunters.GRS.Services
{
    public abstract class BaseService
    {
        protected GRSDataContext grsDataContext;

        public BaseService()
        {
            this.grsDataContext = new GRSDataContext(Util.SqliteConnectionString);
        }
    }
}
