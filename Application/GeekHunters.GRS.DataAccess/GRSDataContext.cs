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
            this.connectionString = connectionString;
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

        #region - Public Properties -

        public DbSet<DbSkill> tblSkills { get; set; }

        public DbSet<DbCandidate> tblCandidate { get; set; }

        public DbSet<DbCandidateSkill> tblCandidateSkill { get; set; }

        #endregion

        #region - Protected Methods -

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbCandidateSkill>()
                .HasKey(c => new { c.CandidateId, c.SkillId });

            modelBuilder
                .Entity<DbCandidateSkill>()
                .HasOne(c => c.Candidate)
                .WithMany(r => r.CandidateSkillCollection)
                .HasForeignKey(c => c.CandidateId);

            modelBuilder
                .Entity<DbCandidateSkill>()
                .HasOne(c => c.Skill)
                .WithMany(r => r.CandidateSkillCollection)
                .HasForeignKey(c => c.SkillId);
        }

        #endregion
    }
}