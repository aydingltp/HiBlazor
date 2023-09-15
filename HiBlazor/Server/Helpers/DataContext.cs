using HiBlazor.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HiBlazor.Server.Helpers
{

    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Teklif> Teklifs { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
