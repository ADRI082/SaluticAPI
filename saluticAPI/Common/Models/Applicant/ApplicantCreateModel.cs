using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Applicant
{
    public class ApplicantCreateModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public string LinkedinURL { get; set; }
    }
}
