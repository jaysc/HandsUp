using Microsoft.EntityFrameworkCore;
using HandsUp.Shared.Models;

namespace HandsUp.Server
{
    public class HandsUpContext : DbContext
    {
        public HandsUpContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<HandsUpEvent> HandsUpEvents { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HandsUpEvent>().ToTable("HandsUpEvent");
        }
    }
}