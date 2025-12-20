using System.Text.Json.Serialization;

namespace Storage.Models;
public class Product
{

    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime EntryDate { get; set; }
    public string? Batch { get; set; }
    public string? SupplierName { get; set; }
    public string? ProductBrand { get; set; }
    public int? AvailableQuantity { get; set; }
    public decimal? Price { get; set; }

    public bool IsPerishable { get; set; }

    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category? categories { get; set; }

}
