using LMSSolution.Application.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet("GetByCourse/{id}")]
        public async Task<IActionResult> GetByCourse(int id)
        {
            var result = await _classService.GetClassByCourse(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
