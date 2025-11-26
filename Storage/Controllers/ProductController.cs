using Microsoft.AspNetCore.Mvc;
using Storage.Context;
using Storage.DTOs;
using Storage.DTOs.Mappings;
using Storage.Models;
using Storage.Repositories;

namespace Storage.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    public readonly IUnitOfWork _uow;

    public ProductController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductDTO>> Get()
    {
        var products = _uow.ProductRepository.GetAll().ToList();
        var productsDto = products.ToProductDTOList();
        return Ok(productsDto);
    }
    [HttpGet("{id:int}", Name = "TakeProduct")]
    public ActionResult<ProductDTO> GetById(int id)
    {
        var getProductId = _uow.ProductRepository.GetById(p => p.ProductId == id);

        var productDto = getProductId.ToProductDTO();
        return Ok(productDto);
    }
    [HttpGet("expired")]
    public ActionResult<IEnumerable<ProductDTO>> GetExpiredProducts()
    {
        var today = DateTime.Now;

        var expiredProduct = _uow.ProductRepository.GetAll()
            .Where(p => p.ExpirationDate < today);

        var expiredProductDto = expiredProduct.ToProductDTOList();

        return Ok(expiredProduct);
    }
    [HttpPost]
    public ActionResult<ProductDTO> Post(ProductDTO productDto)
    {
        var product = productDto.ToProduct();

        var createProduct = _uow.ProductRepository.Create(product);
        _uow.Commit();

        var createProductDto = createProduct.ToProductDTO();

        return new CreatedAtRouteResult("TakeProduct",
            new { id = createProductDto.ProductId }, createProductDto);
    }


    [HttpDelete("{id:int}")]
    public ActionResult<ProductDTO> Delete(int id)
    {
        var getProductId = _uow.ProductRepository.GetById(p => p.ProductId == id);

        var deletedProduct = _uow.ProductRepository.Delete(getProductId);
        _uow.Commit();

        var productDto = deletedProduct.ToProductDTO();

        return Ok(productDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ProductDTO> Put(int id, ProductDTO productDto)
    {
        var product = productDto.ToProduct();
        var editedProduct = _uow.ProductRepository.Update(product);
        _uow.Commit();

        var editedProductDto = editedProduct.ToProductDTO();
        return Ok(editedProductDto);
    }
}
