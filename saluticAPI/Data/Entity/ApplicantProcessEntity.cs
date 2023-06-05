using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("applicant_process")]
    public class ApplicantProcessEntity
    {
        [Column("applicant_id")]
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }

        [Column("process_id")]
        [ForeignKey("Process")]
        public int ProcessId { get; set; }

        [ForeignKey("ApplicantStatus")]
        [Column("applicant_status_id")]
        public int ApplicantStatusId { get; set; }

        [Column("applicant_included_date")]
        public DateTime ApplicantIncludedDate { get; set; }

        public virtual ProcessEntity Process { get;set; }
        
        public virtual ApplicantEntity Applicant { get;set; }

        public virtual ApplicantStatusEntity ApplicantStatus { get; set; }
    }
}
