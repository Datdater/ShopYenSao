using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopYenSao.Domain;
using ShopYenSao.Identity.Models;
using ShopYenSao.Persistence.Configurations;

namespace ShopYenSao.Persistence.DatabaseContext;

public class YenSaoDatabaseContext : IdentityDbContext<ApplicationUser>
{
    public YenSaoDatabaseContext(DbContextOptions<YenSaoDatabaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(YenSaoDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}