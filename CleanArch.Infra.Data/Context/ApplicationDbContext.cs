using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //  Optando por organização do arquivo utilzando desta forma não será necessário criar
            //  -builder.ApplyConfiguration(new CategoryConfiguration));
            //  -builder.ApplyConfiguration(new ProductConfiguration));
            //  o ApplyConfigurationFromAssembly vasculha os arquivos que estão na EntitiesConfiguration
            //  que herdem de IEntityTypeConfiguration...
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
