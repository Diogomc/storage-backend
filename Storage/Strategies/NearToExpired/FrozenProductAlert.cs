using Storage.DTOs;

namespace Storage.Strategies.NearToExpired
{
    public class FrozenProductAlert : INearToExpireAlert
    {
        public string perishableCategory => "Frozen";

        public decimal AplyDiscount(ProductDTO product)
        {
            if (IsCloseToExpiration(product))
                return product.SalePrice * 0.6m;

            return product.SalePrice;
        }

        public bool IsCloseToExpiration(ProductDTO product)
        {
            return product.ExpirationDate <= DateTime.Today.AddDays(10);
        }
    }
}
