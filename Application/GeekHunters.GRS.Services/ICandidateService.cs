using GeekHunters.GRS.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunters.GRS.Services
{
    public interface ICandidateService
    {
        CandicateModel RegisterCandidate(string firstName, string lastName);

        void AddCandidateSkill(int candidateID, int skillID);

        List<CandicateModel> GetAllCandidate(CandidateFilter filter);
    }
}
