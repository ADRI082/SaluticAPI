using AutoMapper;
using Common.Definitions;
using Common.Models.Applicant;
using Common.Models.File;
using Common.Models.Process;
using Data.Entity;
using Data.Repository;
using Data.Repository.ProcessRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ProcessBL
{
    public class ProcessBL : IProcessBL
    {
        private readonly IMapper AutoMapper;
        private readonly IProcessRepository ProcessRepository;

        public ProcessBL(IMapper automapper, IProcessRepository processRepository)
        {
            AutoMapper = automapper;
            ProcessRepository = processRepository;
        }

        public async Task<List<ProcessModel>> GetAllProcesses()
        {
            return AutoMapper.Map<List<ProcessModel>>(await ProcessRepository.GetAllProcesses());
        }


        public async Task<ProcessModel> CreateProcess(ProcessCreateModel newProcess)
        {
            var processEntity = new ProcessEntity();

            try
            {
                var newProcessEntity = AutoMapper.Map<ProcessEntity>(newProcess);

                var createdProcess = await ProcessRepository.CreateProcess(newProcessEntity);

                processEntity = await ProcessRepository.GetProcessById(createdProcess.Id);

            }catch(ArgumentNullException ex)
            {
                throw ex;
            }
            
            return AutoMapper.Map<ProcessModel>(processEntity);
        }

        public async Task DeleteProcess(int processId)
        {
            try
            {
                var entity = await ProcessRepository.GetProcessById(processId);

                if (entity == null)
                    throw new Exception("The entity was not found");

                await ProcessRepository.DeleteProcess(entity);

            }catch(Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<List<ApplicantModel>> GetProcessApplicants(int processId)
        {
            var entities = await ProcessRepository.GetProcessApplicants(processId);

            var applicants = entities.Select(a => a.Applicant).ToList();

            return AutoMapper.Map<List<ApplicantModel>>(applicants);
        }

        public async Task<FileModel> UploadFile(int applicantId, int processId, IFormFile file)
        {
            try
            {
                if (applicantId == 0 || processId == 0)
                    throw new Exception("Applicant or process id is 0");

                MemoryStream stream = new MemoryStream();

                file.CopyTo(stream);

                stream.Position = 0;

                var fileEntity = new ApplicantFiles()
                {
                    ApplicantId = applicantId,
                    ProcessId = processId,
                    FileName = file.FileName,
                    FileData = stream.ToArray()
                };

                fileEntity = await ProcessRepository.UploadFile(fileEntity);

                return AutoMapper.Map<FileModel>(fileEntity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FileModel> DownloadFile(int fileId)
        {
            var fileEntity = await ProcessRepository.DownloadFile(fileId);

            return AutoMapper.Map<FileModel>(fileEntity);
        }

        public async Task<ApplicantModel> CreateApplicant(int processId, ApplicantCreateModel newApplicant)
        {
            try
            {
                var process = await ProcessRepository.GetProcessById(processId);

                if (process == null)
                    throw new Exception("Process not found");

                var applicantEntity = AutoMapper.Map<ApplicantEntity>(newApplicant);

                applicantEntity = await ProcessRepository.CreateApplicant(applicantEntity);

                var applicantProcessEntity = new ApplicantProcessEntity()
                {
                    ApplicantId = applicantEntity.Id,
                    ProcessId = processId,
                    ApplicantStatusId = Constants.INCLUDED_IN_PROCESS,
                    ApplicantIncludedDate = DateTime.Now
                };

                await ProcessRepository.CreateApplicantProcess(applicantProcessEntity);

                return AutoMapper.Map<ApplicantModel>(applicantEntity);
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
