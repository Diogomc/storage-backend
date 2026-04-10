using Storage.DTOs;

namespace Storage.Strategies.NearToExpired;

public class NotPerishableProductAlert : INearToExpireAlert
{
    public string perishableCategory => "NotPerishable";

    public decimal AplyDiscount(ProductDTO product)
    {
        if (IsCloseToExpiration(product))
            return product.SalePrice * 0.9m;

        return product.SalePrice;
    }

    public bool IsCloseToExpiration(ProductDTO product)
    {
        return product.ExpirationDate <= DateTime.Today.AddDays(20);
    }
}
