using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.AdminApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult TimeOut()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
    }
}
