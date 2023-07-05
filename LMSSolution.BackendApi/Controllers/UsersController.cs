using LMSSolution.Application.Systems.Users.Teachers;
using LMSSolution.ViewModels.System.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public UsersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("teacher/create")]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _teacherService.Create(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("teacher/all")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var teachers = await _teacherService.GetAllTeacher();
            return Ok(teachers.ResultObject);
        }

        [HttpGet("teacher/paging")]
        public async Task<IActionResult> GetAllTeacherPaging([FromQuery] GetTeacherPagingRequest request)
        {
            var teachers = await _teacherService.GetAllTeacherPaging(request);
            return Ok(teachers.ResultObject);
        }

        [HttpGet("teacher/detail/{id}")]
        public async Task<IActionResult> GetTeacherDetail(Guid id)
        {
            var result = await _teacherService.GetTeacherDetailById(id);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _teacherService.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
