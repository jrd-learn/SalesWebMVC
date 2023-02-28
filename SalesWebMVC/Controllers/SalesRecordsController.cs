using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using System.Diagnostics;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        
        public async Task<IActionResult> SimpleSearch(DateTime minDate, DateTime maxDate)
        {
            if (minDate > maxDate)
            {
                return RedirectToAction(nameof(Error), new { message = "Min date can not be lesser than max date." });
            }

            ViewData["minDate"] = minDate.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime minDate, DateTime maxDate)
        {
            if (minDate > maxDate)
            {
                return RedirectToAction(nameof(Error), new { message = "Min date can not be lesser than max date." });
            }

            ViewData["minDate"] = minDate.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.ToString("yyyy-MM-dd");

            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);

            return View(result);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
