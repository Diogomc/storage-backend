using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Storage.Models;

public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }
    [JsonIgnore]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}
