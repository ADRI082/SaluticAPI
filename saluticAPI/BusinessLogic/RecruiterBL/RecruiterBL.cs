using AutoMapper;
using Common.Models.Recruiter;
using Data.Entity;
using Data.Repository.RecruiterRepository;

namespace BusinessLogic.RecruiterBL
{
    public class RecruiterBL : IRecruiterBL
    {
        private readonly IMapper AutoMapper;
        private readonly IRecruiterRepository RecruiterRepository;

        public RecruiterBL(IMapper automapper, IRecruiterRepository recruiterRepository)
        {
            AutoMapper = automapper;
            RecruiterRepository = recruiterRepository;
        }

        public async Task<RecruiterModel> Login(RecruiterModel recruiter)
        {
            var entity = AutoMapper.Map<RecruiterEntity>(recruiter);

             recruiter = AutoMapper.Map<RecruiterModel>(await RecruiterRepository.Login(entity));

            return recruiter;
        }
    }
}
