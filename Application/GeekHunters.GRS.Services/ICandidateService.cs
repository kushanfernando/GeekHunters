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
        CandidateModel RegisterCandidate(string firstName, string lastName, IEnumerable<int> skillsCollection);

        void AddCandidateSkill(int candidateID, int skillID);

        List<CandidateModel> GetAllCandidate(IEnumerable<int> skillIdCollection);
    }
}
