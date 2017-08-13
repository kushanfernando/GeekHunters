using GeekHunters.GRS.BusinessModels;
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
            this.grsDataContext.Database.EnsureCreated();
        }

        protected CandidateModel Cast(DbCandidate dbCandidate)
        {
            return new CandidateModel
            {
                Id = dbCandidate.Id,
                FirstName = dbCandidate.FirstName,
                LastName = dbCandidate.LastName,
                SkillCollection = this.grsDataContext
                                    .tblCandidateSkill
                                    .Where(e => e.CandidateId == dbCandidate.Id)
                                    .Select(candidateSkill => this.Cast(this.grsDataContext.tblSkills.Where(e => e.Id == candidateSkill.SkillId).FirstOrDefault()))
                                    .ToList()
            };
        }
        
        protected SkillModel Cast(DbSkill dbSkill)
        {
            return new SkillModel
            {
                ID = dbSkill.Id,
                Name = dbSkill.Name,
            };
        }
    }
}
