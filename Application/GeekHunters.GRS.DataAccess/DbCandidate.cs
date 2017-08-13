using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunters.GRS.DataAccess
{
    [Table("Candidate")]
    public class DbCandidate
    {
        public DbCandidate()
        {
            this.CandidateSkillCollection = new List<DbCandidateSkill>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<DbCandidateSkill> CandidateSkillCollection { get; set; }
    }
}
