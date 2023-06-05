using BusinessLogic.ProcessBL;
using Common.Models.Applicant;
using Common.Models.File;
using Common.Models.Process;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Runtime.CompilerServices;
using System.Web;

namespace saluticAPI.Controllers
{
    [Route("api/Process")]
    public class ProcessController : Controller
    {
        private readonly IProcessBL ProcessBL;

        public ProcessController(IProcessBL processBL) 
        {
            ProcessBL = processBL;
        }

        [HttpGet]
        public async Task<List<ProcessModel>> GetProcesses()
        {
            return await ProcessBL.GetAllProcesses();
        }

        [HttpPost]
        public async Task<ProcessModel> CreateProcess([FromBody]ProcessCreateModel newProcess)
        {
            var process = await ProcessBL.CreateProcess(newProcess);

            return process;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProcess(int id)
        {
            await ProcessBL.DeleteProcess(id);

            return Ok();
        }

        [HttpGet("{id}/applicants")]
        public async Task<List<ApplicantModel>> GetProcessApplicants(int id)
        {
            var result = await ProcessBL.GetProcessApplicants(id);

            return result;
        }

        [HttpPost("{applicantId}/{processId}/upload")]
        public async Task<FileModel> UploadFile(int applicantId, int processId, IFormFile file)
        {
            var result = await ProcessBL.UploadFile(applicantId, processId, file);

            return result;
        }

        [HttpGet("{fileId}/download")]
        public async Task<IActionResult> DownloadFile(int fileId)
        {
            var file = await ProcessBL.DownloadFile(fileId);

            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(file.FileName, out contentType);
            
            return File(file.FileData, contentType, file.FileName);
        }

        [HttpPost("{id}/applicant")]
        public async Task<ApplicantModel> AddApplicant(int id, [FromBody] ApplicantCreateModel newApplicant)
        {
           var result = await ProcessBL.CreateApplicant(id, newApplicant);

            return result;
        }
    }
}
