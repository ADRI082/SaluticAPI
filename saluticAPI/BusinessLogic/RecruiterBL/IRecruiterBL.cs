using Common.Models.Recruiter;


namespace BusinessLogic.RecruiterBL
{
    public interface IRecruiterBL
    {
        Task<RecruiterModel> Login(RecruiterModel recruiter);
    }
}
