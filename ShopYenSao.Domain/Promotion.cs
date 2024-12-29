using Microsoft.EntityFrameworkCore;

namespace ShopYenSao.Domain;

public class Promotion : BaseEntity
{
    [Precision(18, 2)]
    public decimal MinPrice { get; set; }
    [Precision(18, 2)]
    public decimal MaxPrice { get; set; }
    [Precision(18, 2)]
    public decimal AmountDecrease { get; set; }
    [Precision(18, 2)]
    public decimal PercentDiscount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}