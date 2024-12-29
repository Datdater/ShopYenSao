using Microsoft.EntityFrameworkCore;

namespace ShopYenSao.Domain;

public class Account : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Precision(18, 2)]
    public decimal Points { get; set; }
    
}