namespace ShopYenSao.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    public ICategoryRepository CategoryRepository { get; }
    public ISubCategoryRepository SubCategoryRepository { get; }
    Task<int> SaveAsync();

}