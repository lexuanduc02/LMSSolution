using LMSSolution.Application.CreditClasses;
using LMSSolution.Application.Subjects;
using LMSSolution.Application.Systems.Users.Teachers;
using LMSSolution.ViewModels.Course;
using LMSSolution.ViewModels.CreditClass;
using LMSSolution.ViewModels.Major;
using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditClassesController : ControllerBase
    {
        private readonly ICreditClassService _creditClassService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;

        public CreditClassesController(ICreditClassService creditClassService, 
            ISubjectService subjectService, 
            ITeacherService teacherService)
        {
            _creditClassService = creditClassService;
            _subjectService = subjectService;
            _teacherService = teacherService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreditClassCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _creditClassService.Create(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        } 

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetCreditClassPagingRequest request)
        {
            var result = await _creditClassService.GetAllCreditClassPaging(request);
            return Ok(result.ResultObject);
        }

        [HttpPost("TeachingAssign")]
        public async Task<IActionResult> TeachingAssign([FromBody] TeachingAssignRequest request)
        {
            var result = await _creditClassService.TeachingAssign(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
