using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SaluticContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public SaluticContext(DbContextOptions<SaluticContext> options) : base(options) 
        { 
        }

        public DbSet<RecruiterEntity> Recruiters { get; set; }
        public DbSet<ProcessEntity> Processes { get; set; }
        public DbSet<ProcessStatusEntity> ProcessStatus { get; set; }
        public DbSet<ApplicantEntity> Applicants { get; set; }
        public DbSet<ApplicantProcessEntity> ApplicantProcesses { get; set; }
        public DbSet<ApplicantStatusEntity> ApplicantStatus { get; set; }
        public DbSet<RecruiterProcessEntity> RecruiterProcess { get; set; }
        public DbSet<ApplicantFiles> ApplicantFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("salutic");

            modelBuilder.Entity<ApplicantProcessEntity>().HasKey(ap => new { ap.ApplicantId, ap.ProcessId });
            modelBuilder.Entity<RecruiterProcessEntity>().HasKey(rp => new { rp.RecruiterId, rp.ProcessId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}
