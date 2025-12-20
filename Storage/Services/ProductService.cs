using Microsoft.AspNetCore.Http.HttpResults;
using Storage.DTOs;
using Storage.DTOs.Mappings;
using Storage.Repositories;
using System;
using System.Globalization;

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

        public ProductDTO GetById(int id)
        {
            var product = _uow.ProductRepository.GetById(p => p.ProductId == id);

            if (product is null)
                throw new KeyNotFoundException("Product not found");

            return product.ToProductDTO();
        }

        public IEnumerable<ProductDTO> GetCloseExpirationPerishables()
        {
            var today = DateTime.Today;

                 return _uow.ProductRepository.GetAll()
                .Where(p => p.IsPerishable == true)
                .Where(p => p.ExpirationDate > today && p.ExpirationDate <= today.AddDays(5))
                .Select(p => new ProductDTO
                {
                    ProductName = p.ProductName,
                    ExpirationDate = p.ExpirationDate.ToString("dd/MM/yyyy")
                }).ToList();

        }

        public IEnumerable<ProductDTO> GetCloseToExpiration()
        {
            var today = DateTime.Today;

            var closeExpiration = _uow.ProductRepository.GetAll()
                .Where(p => p.IsPerishable == false)
                .Where(p => p.ExpirationDate > today && p.ExpirationDate <= today.AddDays(20));

            return closeExpiration.ToProductDTOList();
        }

        public IEnumerable<ProductDTO> GetExpiredProducts()
        {
            var today = DateTime.Today;
            var products = _uow.ProductRepository.GetAll()
                      .Where(p => p.ExpirationDate < today && p.ExpirationDate <= today);
            return products.ToProductDTOList();
            
        }

        public int GetTotalQuantity()
        {
            return _uow.ProductRepository.GetAll().Sum(p => p.AvailableQuantity ?? 0);
        }

        public decimal GetTotalValue()
        {
            var total =  _uow.ProductRepository.GetAll()
                .Sum(p => (p.AvailableQuantity ?? 0) * (p.Price ?? 0));

            return total;

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
            if (product is null)
                throw new KeyNotFoundException("Product not found");
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
