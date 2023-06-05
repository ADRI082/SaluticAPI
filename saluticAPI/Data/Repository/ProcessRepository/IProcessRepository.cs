using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.ProcessRepository
{
    public interface IProcessRepository
    {
        Task<List<ProcessEntity>> GetAllProcesses();

        Task<ProcessEntity> CreateProcess(ProcessEntity newProcess);

        Task<ProcessEntity> GetProcessById(int processId);

        Task DeleteProcess(ProcessEntity process);

        Task<List<ApplicantProcessEntity>> GetProcessApplicants(int processId);

        Task<ApplicantFiles> UploadFile(ApplicantFiles file);

        Task<ApplicantFiles> DownloadFile(int fileId);

        Task<ApplicantEntity> CreateApplicant(ApplicantEntity applicant);

        Task CreateApplicantProcess(ApplicantProcessEntity applicantProcess);
    }
}
