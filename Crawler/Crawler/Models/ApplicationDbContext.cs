using Crawler.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Crawler.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<UriBetsToParse> UrlsBetsToParse { get; set; }
    }
}
