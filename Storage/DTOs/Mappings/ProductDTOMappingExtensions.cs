using Storage.Models;

namespace Storage.DTOs.Mappings;

public static class ProductDTOMappingExtensions
{
    public static ProductDTO? ToProductDTO (this Product product)
    {
        if (product is null)
        {
            return null;
        }
        return new ProductDTO
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            Batch = product.Batch,
            ExpirationDate = product.ExpirationDate,
            ProductBrand = product.ProductBrand,
            SupplierName = product.SupplierName
        };
    }
    public static Product? ToProduct (this ProductDTO productDTO)
    {
        if (productDTO is null)
        {
            return null;
        }

        return new Product
        {
            ProductId = productDTO.ProductId,
            ProductName = productDTO.ProductName,
            Batch = productDTO.Batch,
            ExpirationDate = productDTO.ExpirationDate,
            ProductBrand = productDTO.ProductBrand,
            SupplierName = productDTO.SupplierName
        };
    }
    public static IEnumerable<ProductDTO> ToProductDTOList (this IEnumerable<Product> products)
    {
        return products.Select(products => new ProductDTO
        {
            ProductId = products.ProductId,
            ProductName = products.ProductName,
            Batch = products.Batch,
            ExpirationDate = products.ExpirationDate,
            ProductBrand = products.ProductBrand,
            SupplierName = products.SupplierName
        }).ToList();
    }
}
