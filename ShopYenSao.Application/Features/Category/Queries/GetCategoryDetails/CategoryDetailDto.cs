namespace ShopYenSao.Application.Features.Category.Queries.GetCategoryDetails;

public class CategoryDetailDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<Domain.SubCategory>? SubCategories { get; set; }
}