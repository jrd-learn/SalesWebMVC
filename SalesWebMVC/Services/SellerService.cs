using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> ListAllAsync()
        {
            return await _context.Sellers.Include(x => x.Department).ToListAsync();
        }
        public async Task<Seller> GetByIdAsync(int id)
        {
            return await _context.Sellers.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task UpdateAsync(Seller seller)
        {
            if (!_context.Sellers.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("ID not found");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new(e.Message);
            }
            
        }
        public async Task DeleteAsync(Seller seller)
        {
            _context.Remove(seller);
            await _context.SaveChangesAsync();
        }
        public async Task CreateAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }
    }
}
