using Microsoft.AspNetCore.Mvc;

namespace AdminLTE_011.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
