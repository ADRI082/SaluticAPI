using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("process")]
    public class ProcessEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("process_name")]
        public string ProcessName { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; } = DateTime.MinValue;

        [Column("status_id")]
        [ForeignKey("ProcessStatus")]
        public int StatusId { get; set; }

        public virtual ProcessStatusEntity ProcessStatus { get; set; }

        public virtual RecruiterProcessEntity RecruiterProcess { get; set; }

    }
}
