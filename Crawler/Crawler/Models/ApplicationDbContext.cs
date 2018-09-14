﻿using Crawler.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Crawler.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Bet> Bets { get; set; }
    }
}