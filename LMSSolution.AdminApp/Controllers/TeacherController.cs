using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.AdminApp.Controllers
{
    public class TeacherController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
