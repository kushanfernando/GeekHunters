using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunters.GRS.DataAccess
{
    [Table("Skill")]
    public class DbSkill
    {
        public DbSkill()
        {
            this.CandidateSkillCollection = new List<DbCandidateSkill>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DbCandidateSkill> CandidateSkillCollection { get; set; }
    }
}
