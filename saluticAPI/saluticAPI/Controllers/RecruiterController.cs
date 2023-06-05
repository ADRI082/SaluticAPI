using BusinessLogic.RecruiterBL;
using Common.Models.Recruiter;
using Microsoft.AspNetCore.Mvc;

namespace saluticAPI.Controllers
{
    [Route("api/recruiter")]
    public class RecruiterController : Controller
    {
        private readonly IRecruiterBL RecruiterBL;

        public RecruiterController(IRecruiterBL recruiterBL)
        {
            RecruiterBL = recruiterBL;
        }

       
        [HttpPost("login")]
        public async Task<ActionResult<RecruiterModel>> GetRecruiter([FromBody] RecruiterModel recruiter)
        {
            var result = await RecruiterBL.Login(recruiter);

           return result != null ? result : NotFound();
        }
    }
}
