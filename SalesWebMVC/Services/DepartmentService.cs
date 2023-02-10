using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> ListAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateAsync(Department department)
        {
            _context.Update(department);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Department department)
        {
            _context.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Department department)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();
        }
    }
}