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

        public DbSet<Event> Event { get; set; }

        public DbSet<BetCategory> BetCategory { get; set; }

        public DbSet<Competition> Competition { get; set; }

        public DbSet<Sport> Sport { get; set; }
    }
}
