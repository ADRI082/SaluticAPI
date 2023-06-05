using Common.Models.Applicant;
using Common.Models.File;
using Common.Models.Process;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.ProcessBL
{
    public interface IProcessBL
    {
        Task<List<ProcessModel>> GetAllProcesses();

        Task<ProcessModel> CreateProcess(ProcessCreateModel newProcess);

        Task DeleteProcess(int processId);

        Task<List<ApplicantModel>> GetProcessApplicants(int processId);

        Task<FileModel> UploadFile(int applicantId, int processId, IFormFile file);

        Task<FileModel> DownloadFile(int fileId);

        Task<ApplicantModel> CreateApplicant(int processId, ApplicantCreateModel newApplicant);

        Task Example();
    }
}
