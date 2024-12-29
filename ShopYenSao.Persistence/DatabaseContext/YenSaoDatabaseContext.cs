using Microsoft.EntityFrameworkCore;
using ShopYenSao.Domain;
using ShopYenSao.Persistence.Configurations;

namespace ShopYenSao.Persistence.DatabaseContext;

public class YenSaoDatabaseContext : DbContext
{
    public YenSaoDatabaseContext(DbContextOptions<YenSaoDatabaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubCategoryConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}