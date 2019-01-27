using Microsoft.EntityFrameworkCore;

namespace BetService.Models
{
    public class BetDbContext : DbContext
    {
        public BetDbContext(DbContextOptions<BetDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bet> BetItems { get; set; }
    }
}
