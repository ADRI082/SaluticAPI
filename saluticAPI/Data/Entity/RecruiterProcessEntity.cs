using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("recruiter_process")]
    public class RecruiterProcessEntity
    {
        [Column("recruiter_id")]
        [ForeignKey("Recruiter")]
        public int RecruiterId { get; set; }

        [Column("process_id")]
        [ForeignKey("Process")]
        public int ProcessId { get; set; }

        public virtual RecruiterEntity Recruiter { get; set; }

        public virtual ProcessEntity Process { get; set; }
    }
}
