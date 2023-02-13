using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
