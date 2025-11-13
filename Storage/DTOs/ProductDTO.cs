namespace Storage.DTOs;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string? Batch { get; set; }
    public string? SupplierName { get; set; }
    public string? ProductBrand { get; set; }

}
