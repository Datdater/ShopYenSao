using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopYenSao.Identity.Configuration;
using ShopYenSao.Identity.Models;

namespace ShopYenSao.Identity.DbContext;

public class YenSaoIdentityDatabaseContext : IdentityDbContext<ApplicationUser>
{
    public YenSaoIdentityDatabaseContext(DbContextOptions<YenSaoIdentityDatabaseContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new UserRolesConfiguration());
    }
}