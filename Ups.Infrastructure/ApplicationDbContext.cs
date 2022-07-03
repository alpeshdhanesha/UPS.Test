using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using USP.Model;

namespace UPS.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {

        protected readonly IConfiguration configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnectionString"));
        }

        public DbSet<UserDto> Users { get; set; }

    }
}
