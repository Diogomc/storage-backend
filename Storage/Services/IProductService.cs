using Storage.DTOs;

namespace Storage.Services;

public interface IProductService 
{
    IEnumerable<ProductDTO> GetAll();
    ProductDTO GetById(int id);
    int GetTotalQuantity();
    IEnumerable<ProductDTO> GetExpiredProducts();
    IEnumerable<ProductDTO> GetCloseToExpiration();
    IEnumerable<ProductDTO> GetCloseExpirationPerishables();
    decimal GetTotalValue();
    ProductDTO Create(ProductDTO productDTO);
    ProductDTO Update(int id, ProductDTO productDTO);
    ProductDTO Delete(int id);
}
