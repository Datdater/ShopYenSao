using Microsoft.AspNetCore.Identity;

namespace ShopYenSao.Domain;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}