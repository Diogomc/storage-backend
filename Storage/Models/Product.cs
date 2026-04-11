using System.Text.Json.Serialization;

namespace Storage.Models;
public class Product
{

    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public DateTime EntryDate { get; set; }
    public string Batch { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
    public string ProductBrand { get; set; } = string.Empty;
    public int AvailableQuantity { get; set; }
    public decimal SalePrice { get; set; }
    public decimal PurchasePrice { get; set; }

    public string PerishableCategory { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category? categories { get; set; }

}
