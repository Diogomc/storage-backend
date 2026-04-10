using Storage.DTOs;

namespace Storage.Strategies.NearToExpired
{
    public interface INearToExpireAlert
    {
        string perishableCategory { get; }
        bool IsCloseToExpiration(ProductDTO product);
        decimal AplyDiscount(ProductDTO product);
    }
}
