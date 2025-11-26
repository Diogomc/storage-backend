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
            ExpirationDate = product.ExpirationDate.ToString("dd-MM-yyyy"),
            ProductBrand = product.ProductBrand,
            SupplierName = product.SupplierName,
            CategoryId = product.CategoryId
            
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
            ExpirationDate = DateTime.Parse(productDTO.ExpirationDate),
            ProductBrand = productDTO.ProductBrand,
            SupplierName = productDTO.SupplierName,
            CategoryId = productDTO.CategoryId
        };
    }
    public static IEnumerable<ProductDTO> ToProductDTOList (this IEnumerable<Product> products)
    {
        return products.Select(products => new ProductDTO
        {
            ProductId = products.ProductId,
            ProductName = products.ProductName,
            Batch = products.Batch,
            ExpirationDate = products.ExpirationDate.ToString("dd-MM-yyyy"),
            ProductBrand = products.ProductBrand,
            SupplierName = products.SupplierName,
            CategoryId = products.CategoryId
            
        }).ToList();
    }
}
