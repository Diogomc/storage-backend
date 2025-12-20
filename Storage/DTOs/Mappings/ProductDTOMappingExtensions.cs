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
            ExpirationDate = product.ExpirationDate.ToString("dd/MM/yyyy"),
            ProductBrand = product.ProductBrand,
            SupplierName = product.SupplierName,
            Price = product.Price,
            AvailableQuantity = product.AvailableQuantity,
            IsPerishable = product.IsPerishable,
            EntryDate = product.EntryDate.ToString("dd/MM/yyyy"),
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
            Price = productDTO.Price,
            EntryDate = DateTime.Parse(productDTO.EntryDate),
            AvailableQuantity = productDTO.AvailableQuantity,
            IsPerishable = productDTO.IsPerishable,
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
            ExpirationDate = products.ExpirationDate.ToString("dd/MM/yyyy"),
            ProductBrand = products.ProductBrand,
            SupplierName = products.SupplierName,
            AvailableQuantity = products.AvailableQuantity,
            Price = products.Price,
            EntryDate = products.EntryDate.ToString("dd/MM/yyyy"),
            IsPerishable = products.IsPerishable,
            CategoryId = products.CategoryId
            
        }).ToList();
    }
}
