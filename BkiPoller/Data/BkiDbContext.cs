using BkiPoller.Data.Model;
using BkiPoller.Data.Model.Bki;
using Microsoft.EntityFrameworkCore;

namespace BkiPoller.Data
{
    public class BkiDbContext : DbContext
    {
        public BkiDbContext(DbContextOptions<BkiDbContext> options) : base(options)
        {
        }

        public DbSet<Credit> Credits { get; set; }

        protected DbSet<EntityFrameworkCore.MemoryJoin.QueryModelClass> QueryData { get; set; }
    }
}