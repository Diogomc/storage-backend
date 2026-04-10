using Storage.DTOs;

namespace Storage.Strategies.NearToExpired
{
    public class FrozenProductAlert : INearToExpireAlert
    {
        public string perishableCategory => "Frozen";

        public bool IsCloseToExpiration(ProductDTO product)
        {
            return product.ExpirationDate <= DateTime.Today.AddDays(10);
        }
    }
}
