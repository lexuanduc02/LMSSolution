using LMSSolution.ApiIntegration.CreditClass;
using LMSSolution.ViewModels.CreditClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;

namespace LMSSolution.AdminApp.Controllers
{
    public class CreditClassController : Controller
    {
        private readonly ICreditClassApiClient _creditClassApiClient;

        public CreditClassController(ICreditClassApiClient creditClassApiClient)
        {
            _creditClassApiClient = creditClassApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? keyWord = null, int pageIndex = 1, int pageSize = 10, DateTime? startDate = null, DateTime? endDate = null)
        {
            var request = new GetCreditClassPagingRequest()
            {
                KeyWord = keyWord,
                StartDate = startDate,
                EndDate = endDate,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };

            var result = await _creditClassApiClient.GetAllCreditClassPaging(request);

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
    }
}
