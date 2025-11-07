using Storage.Context;

namespace Storage.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private ICategoryRepository _categoryRepo;

    private IProductRepository _productRepo;

    public AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public ICategoryRepository CategoryRepository
    {
        get
        {
            return _categoryRepo = _categoryRepo ?? new CategoryRepository(_context);
        }
    }

    public IProductRepository ProductRepository
    {
        get
        {
            return _productRepo = _productRepo ?? new ProductRepository(_context);
        }
    }

   

    public void Commit()
    {
        _context.SaveChanges();
    }
}
