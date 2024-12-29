namespace ShopYenSao.Domain;

public class SubCategory : BaseEntity
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}