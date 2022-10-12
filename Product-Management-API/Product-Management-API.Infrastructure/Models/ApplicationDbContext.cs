using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management_API.Infrastructure.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string path = Directory.GetCurrentDirectory();

                IConfigurationBuilder builder =
                    new ConfigurationBuilder()
                        .SetBasePath(path)
                        .AddJsonFile("appsettings.json");

                IConfigurationRoot config = builder.Build();

                string connectionString = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
