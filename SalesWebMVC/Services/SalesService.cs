using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SalesService
    {
        private readonly SalesWebMVCContext _context;

        public SalesService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> ListAllAsync()
        {
            return await _context.SalesRecords
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
