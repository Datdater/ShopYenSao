using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopYenSao.Domain;

namespace ShopYenSao.Persistence.Configurations;

public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.CategoryId).IsRequired();
    }
}