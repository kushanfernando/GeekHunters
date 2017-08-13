using GeekHunters.GRS.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunters.GRS.Services
{
    public interface ISkillsService
    {
        SkillModel AddSkill(string name);

        List<SkillModel> GetSkillCollection();
    }
}
