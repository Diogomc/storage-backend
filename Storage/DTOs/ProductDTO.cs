namespace Storage.DTOs;

public class ProductDTO
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string EntryDate { get; set; } = string.Empty;
    public required string Batch { get; set; }
    public required string SupplierName { get; set; }
    public required string ProductBrand { get; set; }
    public int AvailableQuantity { get; set; }
    public decimal SalePrice { get; set; }
    public decimal PurchasePrice { get; set; }
    public required string PerishableCategory { get; set; }


    public int CategoryId { get; set; }

}
