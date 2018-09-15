using Crawler.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Crawler.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }

        public ApplicationDbContext()
        { }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<UriBetsToParse> UrisBetsToParse { get; set; }
    }
}
