namespace ShopYenSao.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    public ICategoryRepository CategoryRepository { get; }
    public ISubCategoryRepository SubCategoryRepository { get; }
    public IAccountRepository AccountRepository { get; }
    public IProductRepository ProductRepository { get; }
    
    Task<int> SaveAsync();

}