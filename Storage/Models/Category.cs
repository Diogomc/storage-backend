using System.Collections.ObjectModel;

namespace Storage.Models;

public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    public ICollection<Product>? Products { get; set; }
}
