using HiBlazor.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<User> Users { get; set; }

        public DbSet<HiBlazor.Shared.Entity.Reservation> Reservation { get; set; } = default!;
    }
}
