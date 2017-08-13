using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunters.GRS.DataAccess
{
    [Table("CandidateSkill")]
    public class DbCandidateSkill
    {
        [Key]
        public int CandidateId { get; set; }

        [Key]
        public int SkillId { get; set; }

        [ForeignKey("CandidateId")]
        public virtual DbCandidate Candidate { get; set; }

        [ForeignKey("SkillId")]
        public virtual DbSkill Skill { get; set; }
    }
}
