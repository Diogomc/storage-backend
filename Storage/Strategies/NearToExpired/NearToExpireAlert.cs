using Storage.DTOs;

namespace Storage.Strategies.NearToExpired;

public class NearToExpireAlert
{
    private readonly Dictionary<string, INearToExpireAlert> _nearToExpire;

    public NearToExpireAlert(IEnumerable<INearToExpireAlert> alert)
    {
        _nearToExpire = alert.ToDictionary(s => s.perishableCategory, s => s);
    }
    public INearToExpireAlert GetAlert(ProductDTO product)
    {
        if(_nearToExpire.TryGetValue(product.PerishableCategory, out var alert))
            return alert;

        throw new NotImplementedException("Perishable category not found");
        
    }
}
