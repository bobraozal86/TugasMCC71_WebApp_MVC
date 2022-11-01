using Microsoft.AspNetCore.Mvc;

namespace Tugas4MCC71.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Forbidden()
        {
            return View();
        }
        public IActionResult UnAuthorized()
        {
            return View();
        }
    }
}
