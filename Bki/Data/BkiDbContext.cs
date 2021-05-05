using Bki.Models;
using Microsoft.EntityFrameworkCore;

namespace Bki.Data
{
    public class BkiDbContext : DbContext
    {
        public BkiDbContext(DbContextOptions<BkiDbContext> options) : base(options)
        {
        }

        public DbSet<LoanRequest> LoanRequests { get; set; }
    }
}
