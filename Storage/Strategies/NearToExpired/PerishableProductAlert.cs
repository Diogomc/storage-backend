using Storage.DTOs;

namespace Storage.Strategies.NearToExpired;

public class PerishableProductAlert : INearToExpireAlert
{
    public string perishableCategory => "Perishable";

    public decimal AplyDiscount(ProductDTO product)
    {
        if (IsCloseToExpiration(product))
            return product.SalePrice * 0.5m;

        return product.SalePrice;
    }

    public bool IsCloseToExpiration(ProductDTO product)
    {
        return product.ExpirationDate <= DateTime.Today.AddDays(3);
    }
}
