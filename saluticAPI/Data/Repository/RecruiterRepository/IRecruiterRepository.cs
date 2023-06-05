using Common.Models.Recruiter;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.RecruiterRepository
{
    public interface IRecruiterRepository
    {

        Task<RecruiterEntity> Login(RecruiterEntity recruiter);

    }
}
