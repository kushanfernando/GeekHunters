#region - References -
using GeekHunters.GRS.BusinessModels;
using System.Collections.Generic; 
#endregion

namespace GeekHunters.GRS.Services
{
    public interface ICandidateService
    {
        CandidateModel RegisterCandidate(string firstName, string lastName, IEnumerable<int> skillsCollection);
        
        List<CandidateModel> GetAllCandidate(IEnumerable<int> skillIdCollection);
    }
}
