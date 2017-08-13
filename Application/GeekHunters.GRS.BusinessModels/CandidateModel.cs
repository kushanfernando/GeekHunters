using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunters.GRS.BusinessModels
{
    public class CandidateModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<SkillModel> SkillCollection { get; set; }
    }
}
