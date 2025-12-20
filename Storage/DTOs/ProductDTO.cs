namespace Storage.DTOs;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public string ExpirationDate { get; set; } = string.Empty;
    public string? EntryDate { get; set; } = string.Empty;
    public string? Batch { get; set; }
    public string? SupplierName { get; set; }
    public string? ProductBrand { get; set; }
    public int? AvailableQuantity { get; set; }
    public decimal? Price { get; set; }
    public bool IsPerishable { get; set; }


    public int CategoryId { get; set; }

}
