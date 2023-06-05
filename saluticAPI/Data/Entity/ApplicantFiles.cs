using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("applicant_files")]
    public class ApplicantFiles
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("process_id")]
        public int ProcessId { get; set; }

        [Column("applicant_id")]
        public int ApplicantId { get; set; }

        [Column("file_name")]
        public string FileName { get; set; }

        [Column("file_data")]
        public byte[] FileData { get; set; }
    }
}
