namespace ShopYenSao.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; protected init; } = Guid.NewGuid();
    public DateTime Created { get; protected init; } = DateTime.UtcNow;
    public DateTime? Updated { get; protected set; }
}