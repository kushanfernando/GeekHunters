using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekHunters.GRS.BusinessModels;
using GeekHunters.GRS.DataAccess;

namespace GeekHunters.GRS.Services
{
    public class SkillsService : BaseService, ISkillsService
    {
        public SkillModel AddSkill(string name)
        {
            throw new NotImplementedException();
        }

        public List<SkillModel> GetSkillCollection()
        {
            return this.grsDataContext
                        .tblSkills
                        .Select(Cast)
                        .ToList();
        }
    }
}
