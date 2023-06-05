using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Process
{
    public class ProcessCreateModel
    {
        public DateTime CreatedDate { get; set; }

        public string ProcessName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; } = DateTime.MinValue;

        public int StatusId { get; set; }
    }
}
