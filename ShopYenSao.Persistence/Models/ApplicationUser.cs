using Microsoft.AspNetCore.Identity;
using ShopYenSao.Domain;

namespace ShopYenSao.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public Guid AccountId { get; set; }
    public virtual Account Account { get; set; }
}