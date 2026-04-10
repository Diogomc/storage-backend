using Storage.DTOs;

namespace Storage.Strategies.NearToExpired;

public class NotPerishableProductAlert : INearToExpireAlert
{
    public string perishableCategory => "NotPerishable";

    public bool IsCloseToExpiration(ProductDTO product)
    {
        return product.ExpirationDate <= DateTime.Today.AddDays(20);
    }
}
