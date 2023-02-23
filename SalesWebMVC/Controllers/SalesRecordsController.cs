using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesService _salesService;

        public SalesRecordsController(SalesService salesService)
        {
            _salesService = salesService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _salesService.ListAllAsync();
            
            return View(list);
        }

        public IActionResult SimpleSearch()
        {
            return View();
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
