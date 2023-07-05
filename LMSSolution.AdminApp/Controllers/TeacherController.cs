using LMSSolution.ApiIntegration.System.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.AdminApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherApiClient _teacherApiClient;

        public TeacherController(ITeacherApiClient teacherApiClient)
        {
            _teacherApiClient = teacherApiClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await _teacherApiClient.GetTeacherDetailById(id);

            if (!result.IsSuccess)
            {
                return RedirectToAction("Error404", "Error");
            }

            return View(result.ResultObject);
        }
    }
}
