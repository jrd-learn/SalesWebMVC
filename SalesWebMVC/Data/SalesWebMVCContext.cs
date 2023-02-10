using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SalesWebMVCContext : DbContext
    {
        public SalesWebMVCContext(DbContextOptions<SalesWebMVCContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Seller> Sellers { get; set;}
        public DbSet<SalesRecord> SalesRecords { get; set; }
    }
}
