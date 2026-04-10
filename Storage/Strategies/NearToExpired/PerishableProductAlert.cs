using Storage.DTOs;

namespace Storage.Strategies.NearToExpired;

public class PerishableProductAlert : INearToExpireAlert
{
    public string perishableCategory => "Perishable";

    public bool IsCloseToExpiration(ProductDTO product)
    {
        return product.ExpirationDate <= DateTime.Today.AddDays(3);
    }
}
