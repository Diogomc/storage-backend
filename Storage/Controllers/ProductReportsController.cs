using Microsoft.AspNetCore.Mvc;
using Storage.DTOs;
using Storage.Services;

namespace Storage.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductReportsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductReportsController(IProductService productService)
    {
        _service = productService;
    }

    [HttpGet("{name}")]
    public ActionResult<ProductDTO> GetByName(string name)
    {
        return Ok(_service.GetByName(name));
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
    [HttpGet("GrossValue")]
    public ActionResult<decimal> GetGrossValueTotal()
    {
        return Ok(_service.GetTotalGrossValue());
    }
    [HttpGet("ProfitMargin")]
    public ActionResult<decimal> GetProfitMargin()
    {
        return Ok(_service.GetProfitMargin());
    }
}
