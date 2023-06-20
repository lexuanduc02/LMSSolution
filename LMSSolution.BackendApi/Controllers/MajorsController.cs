using LMSSolution.Application.Majors;
using LMSSolution.ViewModels.Course;
using LMSSolution.ViewModels.Major;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private readonly IMajorService _majorService;

        public MajorsController(IMajorService majorService)
        {
            _majorService = majorService;
        }

        //https://localhost:<port>/users/paging?pageIndex=1&pagesize=10
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetMajorPagingRequest request)
        {
            var users = await _majorService.GetAllMajorPaging(request);
            return Ok(users.ResultObject);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] MajorCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _majorService.Create(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] MajorEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _majorService.Edit(request);

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

            var result = await _majorService.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMajor(int id)
        {
            var result = await _majorService.GetMajorById(id);

            return Ok(result);
        }

        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> GetMajorDetail(int id)
        {
            var result = await _majorService.GetMajorDetailById(id);

            return Ok(result);
        }
    }
}
