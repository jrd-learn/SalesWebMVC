using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models.ViewModels;
using System.Diagnostics;

namespace SalesWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Salles Web MVC App from C# Course";
            ViewData["CourseName"] = "C# COMPLETO Programação Orientada a Objetos";
            ViewData["CourseURL"] = "https://www.udemy.com/course/programacao-orientada-a-objetos-csharp";
            ViewData["Teacher"] = "Nelio Alves";
            ViewData["Student"] = "Walter B. Durand Jr.";
            ViewData["GitHub"] = "https://github.com/jrd-learn/SalesWebMVC";
            ViewData["Linkedin"] = "https://www.linkedin.com/in/walter-b-durand-jr-014bb4181";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}