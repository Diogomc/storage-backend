using Microsoft.AspNetCore.Mvc;
using Storage.Context;
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
    public ActionResult<IEnumerable<Product>> Get()
    {
        var products = _uow.ProductRepository.GetAll().ToList();
        return Ok(products);
    }
    [HttpGet("{id:int}", Name = "TakeProduct")]
    public ActionResult<Product> GetById(int id)
    {
        var getProductId = _uow.ProductRepository.GetById(p => p.ProductId == id);
        return Ok(getProductId);
    }
    [HttpPost]
    public ActionResult<Product> Post(Product product)
    {
        var createProduct = _uow.ProductRepository.Create(product);
        _uow.Commit();

        return new CreatedAtRouteResult("TakeProduct",
            new { id = product.ProductId }, createProduct);
    }
    [HttpDelete("{id:int}")]
    public ActionResult<Product> Delete(int id)
    {
        var getProductId = _uow.ProductRepository.GetById(p => p.ProductId == id);
        _uow.ProductRepository.Delete(getProductId);
        _uow.Commit();

        return Ok(getProductId);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Product> Put(int id, Product product)
    {
        _uow.ProductRepository.Update(product);
        _uow.Commit();
        return Ok(product);
    }
}
