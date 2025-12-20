using Microsoft.AspNetCore.Mvc;
using Storage.DTOs;
using Storage.Services;

namespace Storage.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    public readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductDTO>> GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id:int}", Name = "TakeProduct")]
    public ActionResult<ProductDTO> GetById(int id)
    {
        var product = _service.GetById(id);
        if (product is null) return NotFound("Product not found");

        return Ok(product);
    }
    [HttpGet("TotalQuantity")]
    public ActionResult<int> GetTotalQuantity()
    {
        return Ok(_service.GetTotalQuantity());
    }
    [HttpGet("Expireds")]
    public ActionResult<IEnumerable<ProductDTO>> GetExpiredProducts()
    {
        return Ok(_service.GetExpiredProducts());
    }
    [HttpGet("CloseExpirationPerishables")]
    public ActionResult<IEnumerable<ProductDTO>> GetCloseExpirationPerishables()
    {
        return Ok(_service.GetCloseExpirationPerishables());
    }
    [HttpGet("TotalValue")]
    public ActionResult<decimal> GetTotalValue()
    {
        return Ok(_service.GetTotalValue());
    }
    [HttpGet("CloseExpiration")]
    public ActionResult<IEnumerable<ProductDTO>> GetCloseExpiration()
    {
        return Ok(_service.GetCloseToExpiration());
    }


    [HttpPost]
    public ActionResult<ProductDTO> Post(ProductDTO productDto)
    {
        var created = _service.Create(productDto);
        return new CreatedAtRouteResult("TakeProduct", new { id = productDto.ProductId }, created);
    }
    [HttpPut("{id:int}")]
    public ActionResult<ProductDTO> Put (int id, ProductDTO productDTO)
    {
        return Ok(_service.Update(id, productDTO));
    }
    [HttpDelete("{id:int}")]
    public ActionResult<ProductDTO> Delete(int id)
    {
        return Ok(_service.Delete(id));
    }
}
