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
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Route>()
                .HasData(
                    new Route
                    {
                        RouteId = 1,
                        DestinationName = "Ga Bến Thành",
                        Price = 15000,
                        IsActive = true,
                    },
                    new Route
                    {
                        RouteId = 2,
                        DestinationName = "Ga Nhà hát Thành phố",
                        Price = 15000,
                        IsActive = true,
                    },
                    new Route
                    {
                        RouteId = 3,
                        DestinationName = "Ga Ba Son",
                        Price = 15000,
                        IsActive = true,
                    },
                    new Route
                    {
                        RouteId = 4,
                        DestinationName = "Ga Tân Cảng",
                        Price = 20000,
                        IsActive = true,
                    },
                    new Route
                    {
                        RouteId = 5,
                        DestinationName = "Ga Suối Tiên",
                        Price = 25000,
                        IsActive = true,
                    }
                );
        }
    }
}
