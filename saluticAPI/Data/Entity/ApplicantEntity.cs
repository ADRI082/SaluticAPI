using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("applicant")]
    public class ApplicantEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("linkedin_url")]
        public string? LinkedinURL { get; set; }

        public virtual ApplicantProcessEntity ApplicantProcess { get; set; }
    }
}
