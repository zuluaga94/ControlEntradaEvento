using Microsoft.EntityFrameworkCore;
using EventControl.Shared.Entities;



namespace EventControl.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<EventTicket> eventTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EventTicket>().HasIndex("Id").IsUnique();
        }
    }
}

