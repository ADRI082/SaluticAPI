using Data.Context;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.ProcessRepository
{
    public class ProcessRepository : IProcessRepository
    {
        private SaluticContext DbContext { get; set; }

        public ProcessRepository(SaluticContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<ProcessEntity>> GetAllProcesses()
        {
            var entities = await DbContext.Processes
                                          .Include(p => p.ProcessStatus)
                                          .ToListAsync();

            return entities;
        }

        public async Task<ProcessEntity> CreateProcess(ProcessEntity newProcess)
        {
            var entity = await DbContext.AddAsync(newProcess);

            await DbContext.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task<ProcessEntity> GetProcessById(int processId)
        {
            var entity = await DbContext.Processes
                                        .Include(p => p.ProcessStatus)
                                        .FirstOrDefaultAsync(p => p.Id == processId);

            return entity;
        }

        public async Task DeleteProcess(ProcessEntity process)
        {
            DbContext.Remove(process);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<ApplicantProcessEntity>> GetProcessApplicants(int processId)
        {
            var entities = await DbContext.ApplicantProcesses
                                          .Include(a => a.Applicant)
                                          .Where(p => p.ProcessId == processId)
                                          .ToListAsync();
            return entities;
        }

        public async Task<ApplicantFiles> UploadFile(ApplicantFiles file)
        {
            var entity = await DbContext.ApplicantFiles.AddAsync(file);

            await DbContext.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task<ApplicantFiles> DownloadFile(int fileId)
        {
            var entity = await DbContext.ApplicantFiles.FirstOrDefaultAsync(f => f.Id == fileId);

            return entity;
        }

        public async Task<ApplicantEntity> CreateApplicant(ApplicantEntity applicant)
        {
            var entity = await DbContext.Applicants.AddAsync(applicant);

            await DbContext.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task CreateApplicantProcess(ApplicantProcessEntity applicantProcess)
        {
            await DbContext.AddAsync(applicantProcess);

            await DbContext.SaveChangesAsync();
        }
    }
}
