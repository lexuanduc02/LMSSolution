using LMSSolution.ApiIntegration.Course;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.AdminApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseApiClient _courseApiClient;

        public CourseController(ICourseApiClient courseApiClient)
        {
            _courseApiClient = courseApiClient;
        }

        public async Task<IActionResult> Index(string keyWord = "", int pageIndex = 1, int pageSize = 20)
        {
            var request = new GetCoursePagingRequest()
            {
                KeyWord = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var result = await _courseApiClient.GetCoursesPaging(request);

            ViewBag.KeyWord = keyWord;

            if (TempData["result"] != null)
            {
                ViewBag.ResultMessage = TempData["result"];
            }

            return View(result.ResultObject);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _courseApiClient.Create(request);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }

            TempData["result"] = "Thêm mới thành công!";

            return RedirectToAction("Index", "Course");
        }
    }
}
