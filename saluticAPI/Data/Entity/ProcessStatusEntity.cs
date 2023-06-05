using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("process_status")]
    public class ProcessStatusEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("status_name")]
        public string StatusName { get; set; }
    }
}
