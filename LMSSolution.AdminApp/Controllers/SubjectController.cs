using LMSSolution.ApiIntegration.Major;
using LMSSolution.ApiIntegration.Subject;
using LMSSolution.ViewModels.Subject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMSSolution.AdminApp.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectApiClient _subjectApiClient;
        private readonly IMajorApiClient _majorApiClient;

        public SubjectController(ISubjectApiClient subjectApiClient,
            IMajorApiClient majorApiClient)
        {
            _subjectApiClient = subjectApiClient;
            _majorApiClient = majorApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string keyWord = "", int pageIndex = 1, int pageSize = 10)
        {
            var pagingRequest = new GetSubjectPagingRequest()
            {
                KeyWord = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };

            var pageSizeSli = new List<SelectListItem>()
            {
                new SelectListItem{ Value = "10", Text = "10", Selected = pageSize == 10},
                new SelectListItem{ Value = "25", Text = "25", Selected = pageSize == 25},
                new SelectListItem{ Value = "50", Text = "50", Selected = pageSize == 50},
                new SelectListItem{ Value = "100", Text = "100", Selected = pageSize == 100},
            };

            ViewBag.PageSize = pageSizeSli;
            ViewBag.KeyWord = keyWord;

            var apiResult = await _subjectApiClient.GetAllSubjectPaging(pagingRequest);

            var data = apiResult.ResultObject;

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var majors = await _majorApiClient.GetAllMajor();

            ViewBag.MajorSli = majors.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectCreateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }

            var apiResult = await _subjectApiClient.Create(request);

            if(!apiResult.IsSuccess)
            {
                ModelState.AddModelError("", apiResult.Message);
                return View(request);
            }

            TempData["result"] = "Thêm mới thành công!";

            return RedirectToAction("Index", "Subject");
        }
    }
}
