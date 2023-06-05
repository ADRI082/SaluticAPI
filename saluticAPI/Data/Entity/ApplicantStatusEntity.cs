using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("applicant_status")]
    public class ApplicantStatusEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("status_name")]
        public string StatusName { get; set; }
    }
}
