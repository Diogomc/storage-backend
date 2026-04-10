using Microsoft.AspNetCore.Http.HttpResults;
using Storage.DTOs;
using Storage.DTOs.Mappings;
using Storage.Models;
using Storage.Repositories;
using Storage.Strategies.NearToExpired;
using System;
using System.Globalization;

namespace Storage.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly NearToExpireAlert _nearToExpire;

        public ProductService(IUnitOfWork uow, NearToExpireAlert nearToExpire)
        {
            _uow = uow;
            _nearToExpire = nearToExpire;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return _uow.ProductRepository.GetAll().ToProductDTOList();
        }

        public ProductDTO GetByName(string name)
        {
            var product = _uow.ProductRepository.GetAll()
                .FirstOrDefault(p => p.ProductName == name);

            var dto = product.ToProductDTO();
            return dto;
        }

        public ProductDTO GetById(int id)
        {
            var product = _uow.ProductRepository.GetById(p => p.ProductId == id);

            if (product is null)
                throw new KeyNotFoundException("Product not found");

            return product.ToProductDTO();
        }

        public IEnumerable<ProductDTO> GetExpiredProducts()
        {
            var today = DateTime.Today;
            var products = _uow.ProductRepository.GetAll()
                      .Where(p => p.ExpirationDate < today && p.ExpirationDate <= today);
            return products.ToProductDTOList();
            
        }
        public decimal GetTotalGrossValue()
        {
            var gross = _uow.ProductRepository.GetAll()
                .Sum(p => (p.PurchasePrice ?? 0) * (p.AvailableQuantity ?? 0));
            return gross;
        }
        public int GetTotalQuantity()
        {
            return _uow.ProductRepository.GetAll().Sum(p => p.AvailableQuantity ?? 0);
        }

        public decimal GetTotalValue()
        {
            var total =  _uow.ProductRepository.GetAll()
                .Sum(p => (p.AvailableQuantity ?? 0) * (p.SalePrice ?? 0));

            return total;

        }
        public decimal GetProfitMargin ()
        {
            var margin = _uow.ProductRepository.GetAll()
                .Sum(p => (p.SalePrice ?? 0) - (p.PurchasePrice ?? 0));
            return margin;
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

        public IEnumerable<ProductDTO> GetCloseToExpiration()
        {
            var products = GetAll();
            return products.Where(p =>
            {
                var alert = _nearToExpire.GetAlert(p);
                return alert.IsCloseToExpiration(p);
            });
        }
    }
}
