using Storage.DTOs;

namespace Storage.Services;

public interface IProductService 
{
    IEnumerable<ProductDTO> GetAll();
    ProductDTO GetByName(string name);
    ProductDTO GetById(int id);
    ProductDTO Create(ProductDTO productDTO);
    ProductDTO Update(int id, ProductDTO productDTO);
    ProductDTO Delete(int id);
}
