using LMSSolution.ApiIntegration.Subject;
using LMSSolution.ApiIntegration.System.Teacher;
using LMSSolution.Data.Entities;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.System.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMSSolution.AdminApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherApiClient _teacherApiClient;
        private readonly ISubjectApiClient _subjectApiClient;

        public TeacherController(ITeacherApiClient teacherApiClient,
            ISubjectApiClient subjectApiClient)
        {
            _teacherApiClient = teacherApiClient;
            _subjectApiClient = subjectApiClient;
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var subjects = await _subjectApiClient.GetAllSubject();
            ViewBag.SubjectSli = subjects.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateRequest request)
        {
            var subjects = await _subjectApiClient.GetAllSubject();
            ViewBag.SubjectSli = subjects.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            });

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var apiResult = await _teacherApiClient.Create(request);

            if (!apiResult.IsSuccess)
            {
                ModelState.AddModelError("", apiResult.Message);
                return View(request);
            }

            TempData["result"] = "Thêm mới thành công!";

            return RedirectToAction("Index", "Teacher");
        }
    }
}
