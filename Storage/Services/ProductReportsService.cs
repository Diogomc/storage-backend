using Storage.DTOs;
using Storage.DTOs.Mappings;
using Storage.Models;
using Storage.Repositories;
using Storage.Strategies.NearToExpired;

namespace Storage.Services;

public class ProductReportsService : IProductReportsService
{
    private readonly IUnitOfWork _uow;
    private readonly NearToExpireAlert _nearToExpire;

    public ProductReportsService(IUnitOfWork uow, NearToExpireAlert nearToExpire)
    {
        _uow = uow;
        _nearToExpire = nearToExpire;
    }

    public IEnumerable<ProductDTO> GetCloseToExpiration()
    {
        return _uow.ProductRepository.GetAll()
            .ToProductDTOList()
            .Where(p =>
            {
                var alert = _nearToExpire.GetAlert(p);
                return alert.IsCloseToExpiration(p);
            }).Select(p =>
            {
                var alert = _nearToExpire.GetAlert(p);
                p.SalePrice = alert.AplyDiscount(p);
                return p;
            });
    }

    public IEnumerable<ProductDTO> GetExpiredProducts()
    {
        var expirationDate = _uow.ProductRepository.GetAll()
            .Where(p => p.ExpirationDate < DateTime.Today);

        return expirationDate.ToProductDTOList();
    }

    public decimal GetProfitMargin()
    {
        var allProductSalePrice = _uow.ProductRepository.GetAll()
            .Sum(p => (p.AvailableQuantity) * (p.SalePrice));

        var allProductPurchasePrice = _uow.ProductRepository.GetAll()
            .Sum(p => (p.AvailableQuantity) * (p.PurchasePrice));

        return allProductSalePrice - allProductPurchasePrice;
    }

    public decimal GetTotalGrossValue()
    {
        return _uow.ProductRepository.GetAll()
            .Sum(p => p.AvailableQuantity * p.PurchasePrice);
    }

    public int GetTotalQuantity()
    {
        return _uow.ProductRepository.GetAll()
            .Sum(p => p.AvailableQuantity);
    }

    public decimal GetTotalValue()
    {
        return _uow.ProductRepository.GetAll()
            .Sum(p => p.SalePrice * p.AvailableQuantity);
    }
}
