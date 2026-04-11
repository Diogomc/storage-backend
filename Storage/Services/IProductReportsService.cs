using Storage.DTOs;

namespace Storage.Services;

public interface IProductReportsService
{
    int GetTotalQuantity();
    IEnumerable<ProductDTO> GetExpiredProducts();
    IEnumerable<ProductDTO> GetCloseToExpiration();
    decimal GetTotalValue();
    decimal GetProfitMargin();
    decimal GetTotalGrossValue();
}
