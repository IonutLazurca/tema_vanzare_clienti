using date.API.Models;
using Microsoft.EntityFrameworkCore;

namespace date.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ClientOrder> ClientOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientOrder>()
                .HasKey(c => new {c.ClientId, c.OrderId});
            modelBuilder.Entity<ClientOrder>()
                .HasOne(c => c.Client)
                .WithMany(o => o.ClientOrders)
                .HasForeignKey(f => f.ClientId);
            modelBuilder.Entity<ClientOrder>()
                .HasOne(c => c.Order)
                .WithMany(o => o.ClientOrders)
                .HasForeignKey(f => f.OrderId);
        }

        
    }
}