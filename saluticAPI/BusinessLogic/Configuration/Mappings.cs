using AutoMapper;
using Common.Models.Applicant;
using Common.Models.File;
using Common.Models.Process;
using Common.Models.Recruiter;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Configuration
{
    public class Mappings : Profile
    {
        public Mappings() {

            CreateMap<RecruiterModel, RecruiterEntity>();

            CreateMap<RecruiterEntity, RecruiterModel>();

            CreateMap<ProcessEntity, ProcessModel>()
                .ForMember(d => d.Status, a => a.MapFrom(s => s.ProcessStatus.StatusName));

            CreateMap<ProcessCreateModel, ProcessEntity>();

            CreateMap<ApplicantEntity, ApplicantModel>();

            CreateMap<ApplicantFiles, FileModel>();

            CreateMap<ApplicantCreateModel, ApplicantEntity>();
        }
    }
}
