using Data.Context;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.RecruiterRepository
{
    public class RecruiterRepository : IRecruiterRepository
    {
        private SaluticContext DbContext { get; set; }

        public RecruiterRepository(SaluticContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<RecruiterEntity> Login(RecruiterEntity recruiter)
        {
            var entity = await DbContext.Recruiters.FirstOrDefaultAsync(r => (r.Email == recruiter.Email || r.Username == recruiter.Username) && r.Password == recruiter.Password);

            return entity;
        }
    }
}
