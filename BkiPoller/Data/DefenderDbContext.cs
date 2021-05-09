using BkiPoller.Data.Model;
using BkiPoller.Data.Model.Defender;
using Microsoft.EntityFrameworkCore;

namespace BkiPoller.Data
{
    public class DefenderDbContext : DbContext
    {
        public DefenderDbContext(DbContextOptions<DefenderDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<CreditRequest> CreditRequests { get; set; }

        public DbSet<UserLastPolling> UsersLastPolling { get; set; }
    }
}