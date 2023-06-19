using AutoMapper;
using Azure.Core;
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

        [HttpGet]
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
