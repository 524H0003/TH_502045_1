using Microsoft.EntityFrameworkCore;

namespace TH_502045_1.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options) { }

        public DbSet<Route> Routes { get; set; }
        public DbSet<TicketOrder> TicketOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.RouteId);
                entity.Property(e => e.DestinationName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<TicketOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.PaymentMethod).IsRequired();
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");

                entity.HasOne(d => d.Route).WithMany().HasForeignKey(d => d.RouteId);
            });
        }
    }
}
