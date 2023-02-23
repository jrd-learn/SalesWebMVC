using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using System.Diagnostics;

namespace SalesWebMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.ListAllAsync();
            return View(departments);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not provided." });
            }

            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not found." });
            }

            return View(department);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not provided." });
            }

            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not found." });
            }

            return View(department);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not provided." });
            }

            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not found." });
            }

            return View(department);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID missmatch." });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.UpdateAsync(department);
                    return RedirectToAction(nameof(Details), department);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return RedirectToAction(nameof(Error), new { message = $"Error: {e.Message}" });
                }
            }
            
            return View(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Department department)
        {
            if (id != department.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID missmatch." });
            }

            try
            {
                await _departmentService.DeleteAsync(department);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = $"Error: {e.Message}" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.CreateAsync(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return RedirectToAction(nameof(Error), new { message = $"Error: {e.Message}" });
                }
            }

            return View(department);
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
