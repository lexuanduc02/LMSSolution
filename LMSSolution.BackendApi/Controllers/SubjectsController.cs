using LMSSolution.Application.Subjects;
using LMSSolution.ViewModels.Major;
using LMSSolution.ViewModels.Subject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        //https://localhost:<port>/users/paging?pageIndex=1&pagesize=10
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetSubjectPagingRequest request)
        {
            var users = await _subjectService.GetAllSubjectPaging(request);
            return Ok(users.ResultObject);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SubjectCreateRequest request)
        {  
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _subjectService.Create(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] SubjectEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _subjectService.Edit(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _subjectService.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMajor(int id)
        {
            var result = await _subjectService.GetSubjectById(id);

            return Ok(result);
        }

        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> GetMajorDetail(int id)
        {
            var result = await _subjectService.GetSubjectDetailById(id);

            return Ok(result);
        }
    }
}
