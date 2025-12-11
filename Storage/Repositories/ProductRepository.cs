using Storage.Context;
using Storage.Models;
using System.Linq.Expressions;

namespace Storage.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

       
    }
}
