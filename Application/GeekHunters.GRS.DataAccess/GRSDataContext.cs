#region - References -
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage; 
#endregion

namespace GeekHunters.GRS.DataAccess
{
    public class GRSDataContext : DbContext
    {
        #region - Private Properties -

        private IDbContextTransaction transaction;

        private string connectionString;

        #endregion

        #region - Constructor -

        public GRSDataContext(string connectionString)
            : base()
        {

        }

        #endregion

        #region - Public Methods -

        public void BeginTransaction()
        {
            if (this.transaction != null)
                RollbackTransaction();
            this.transaction = this.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (this.transaction != null)
            {
                this.transaction.Commit();
                this.transaction.Dispose();
                this.transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction.Dispose();
                this.transaction = null;
            }
        }

        #endregion

        #region - Protected Methods -

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(this.connectionString);
        }

        #endregion
    }
}
