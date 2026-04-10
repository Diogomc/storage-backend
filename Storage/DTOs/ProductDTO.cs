namespace Storage.DTOs;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string? EntryDate { get; set; } = string.Empty;
    public string? Batch { get; set; }
    public string? SupplierName { get; set; }
    public string? ProductBrand { get; set; }
    public int? AvailableQuantity { get; set; }
    public decimal? SalePrice { get; set; }
    public decimal? PurchasePrice { get; set; }
    public string? PerishableCategory { get; set; }


    public int CategoryId { get; set; }

}
