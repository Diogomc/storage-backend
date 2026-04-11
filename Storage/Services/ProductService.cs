using Storage.DTOs;
using Storage.DTOs.Mappings;
using Storage.Models;
using Storage.Repositories;
using Storage.Strategies.NearToExpired;

namespace Storage.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return _uow.ProductRepository.GetAll().ToProductDTOList();
        }

        public ProductDTO GetByName(string name)
        {
            var product = _uow.ProductRepository.GetAll()
                .FirstOrDefault(p => p.ProductName == name);

            if (product is null)
                throw new KeyNotFoundException("Product is not found");

            return product.ToProductDTO();
        }

        public ProductDTO GetById(int id)
        {
            var product = _uow.ProductRepository.GetById(p => p.ProductId == id);

            if (product is null)
                throw new KeyNotFoundException("Product is not found");

            return product.ToProductDTO();
        }   
        
        public ProductDTO Create(ProductDTO productDTO)
        {
            var product = productDTO.ToProduct();

            var created = _uow.ProductRepository.Create(product);
            _uow.Commit();

            return created.ToProductDTO();
        }
        public ProductDTO Update(int id, ProductDTO productDTO)
        {
          
            var product = productDTO.ToProduct();
            var edited = _uow.ProductRepository.Update(product);
            _uow.Commit();

            return edited.ToProductDTO();

        }
        public ProductDTO Delete(int id)
        {
            var product = _uow.ProductRepository.GetById(p => p.ProductId == id);
            if (product == null)
                throw new KeyNotFoundException("Product not found");

            var deleted = _uow.ProductRepository.Delete(product);
            _uow.Commit();
            return deleted.ToProductDTO();

        }

     
    }
}
