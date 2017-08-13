#region - References -
using GeekHunters.GRS.BusinessModels;
using GeekHunters.GRS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace GeekHunters.GRS.Services
{
    public class CandidateService : BaseService, ICandidateService
    {
        #region - Public Methods -
        
        public List<CandidateModel> GetAllCandidate(IEnumerable<int> skillIdCollection)
        {
            try
            {
                var query = this.grsDataContext.tblCandidate.AsQueryable();

                if (skillIdCollection != null && skillIdCollection.Any())
                {
                    query = query
                            .Where(candidate =>
                                    candidate
                                        .CandidateSkillCollection
                                        .Where(cs => skillIdCollection.Where(s => s == cs.SkillId).Any())
                                        .Any())
                            .AsQueryable();
                }

                return query.Select(this.Cast).ToList();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public CandidateModel RegisterCandidate(string firstName, string lastName, IEnumerable<int> skillsCollection)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(firstName))
                    throw new Exception("Invalid First Name");
                else if (string.IsNullOrWhiteSpace(lastName))
                    throw new Exception("Invalid Last Name");
                else
                {
                    this.grsDataContext.BeginTransaction();

                    var dbCandidate = new DbCandidate
                    {
                        Id = this.grsDataContext.tblCandidate.Any() ? this.grsDataContext.tblCandidate.Max(e => e.Id) + 1 : 1,
                        FirstName = firstName,
                        LastName = lastName,
                    };
                    this.grsDataContext.tblCandidate.Add(dbCandidate);

                    if (skillsCollection != null)
                    {
                        skillsCollection.ToList().ForEach(skillId =>
                        {
                            var dbSkill = this.grsDataContext.tblSkills.Where(e => e.Id == skillId).FirstOrDefault();

                            if (dbSkill == null)
                                throw new Exception("Invalid Skill ID");

                            var dbCandidateSkill = new DbCandidateSkill
                            {
                                CandidateId = dbCandidate.Id,
                                SkillId = dbSkill.Id,
                            };

                            this.grsDataContext.tblCandidateSkill.Add(dbCandidateSkill);
                        });
                    }

                    this.grsDataContext.SaveChanges();

                    this.grsDataContext.CommitTransaction();

                    return this.Cast(dbCandidate);
                }
            }
            catch (Exception exception)
            {
                this.grsDataContext.RollbackTransaction();
                throw;
            }
        }

        #endregion
    }
}
