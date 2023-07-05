using AutoMapper;
using Azure.Core;
using LMSSolution.ApiIntegration.Course;
using LMSSolution.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMSSolution.AdminApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseApiClient _courseApiClient;

        public CourseController(ICourseApiClient courseApiClient)
        {
            _courseApiClient = courseApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string keyWord = "", int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetCoursePagingRequest()
            {
                KeyWord = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var result = await _courseApiClient.GetCoursesPaging(request);

            var pageSizeSli = new List<SelectListItem>()
            {
                new SelectListItem{ Value = "10", Text = "10", Selected = pageSize == 10},
                new SelectListItem{ Value = "25", Text = "25", Selected = pageSize == 25},
                new SelectListItem{ Value = "50", Text = "50", Selected = pageSize == 50},
                new SelectListItem{ Value = "100", Text = "100", Selected = pageSize == 100},
            };

            ViewBag.PageSize = pageSizeSli;
            ViewBag.KeyWord = keyWord;

            if (TempData["result"] != null)
            {
                ViewBag.ResultMessage = TempData["result"];
            }

            var data = result.ResultObject;

            return View(data);
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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _courseApiClient.GetCourse(id);

            if(result.IsSuccess)
            {
                var course = result.ResultObject;
                var deleteRequest = new CourseDeleteRequest()
                {
                    Id = course.Id,
                    Name = course.Name,
                };

                return View(deleteRequest);
            }

            return RedirectToAction("Error404", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CourseDeleteRequest request)
        {
            var result = await _courseApiClient.Delete(request);

            if(!result.IsSuccess) 
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }

            TempData["result"] = "Xóa thành công!";
            return RedirectToAction("Index", "Course");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _courseApiClient.GetCourseDetailById(id);

            if (!result.IsSuccess)
            {
                return RedirectToAction("Error404", "Error");
            }

            return View(result.ResultObject);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var apiResult = await _courseApiClient.GetCourse(id);

            if(!apiResult.IsSuccess)
            {
                return RedirectToAction("Error404", "Error"); ;
            }

            var course = apiResult.ResultObject;

            var editRequest = new CourseEditRequest()
            { 
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
            };


            return View(editRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CourseEditRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }

            var apiResult = await _courseApiClient.Update(request);

            if(!apiResult.IsSuccess)
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
                return View(request);
            }

            TempData["result"] = "Cập nhật thành công!";
            return RedirectToAction("Index", "Course");
        }
    }
}
