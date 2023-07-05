using AutoMapper;
using LMSSolution.Application.Courses;
using LMSSolution.ViewModels.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
        }

        //https://localhost:<port>/users/paging?pageIndex=1&pagesize=10
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetCoursePagingRequest request)
        {
            var users = await _courseService.GetAllCoursePaging(request);
            return Ok(users.ResultObject);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CourseCreateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseService.Create(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] CourseEditRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseService.Edit(request);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseService.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var result = await _courseService.GetCourseById(id);

            return Ok(result);
        }

        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> GetCourseDetail(int id)
        {
            var result = await _courseService.GetCourseDetailById(id);

            return Ok(result);
        }
    }
}
