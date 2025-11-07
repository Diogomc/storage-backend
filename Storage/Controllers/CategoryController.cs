using Microsoft.AspNetCore.Mvc;
using Storage.Models;
using Storage.Repositories;

namespace Storage.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    public readonly IUnitOfWork _uow;

    public CategoryController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
        return _uow.CategoryRepository.GetAll().ToList();
    }
    [HttpGet("{id:int}", Name ="TakeCategory")]
    public ActionResult<Category> GetById(int id)
    {
        var getCategoryId = _uow.CategoryRepository.GetById(c => c.CategoryId == id);
        return Ok(getCategoryId);
    }
    [HttpPost]
    public ActionResult<Category> Post (Category category)
    {
        var createCategory = _uow.CategoryRepository.Create(category);
        _uow.Commit();

        return new CreatedAtRouteResult("TakeCategory",
            new { id = category.CategoryId }, createCategory);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Category> Delete(int id)
    {
        var getCategoryId = _uow.CategoryRepository.GetById(c => c.CategoryId == id);
        _uow.CategoryRepository.Delete(getCategoryId);
        _uow.Commit();
        return Ok(getCategoryId);
    }
    [HttpPut("{id:int}")]
    public ActionResult<Category> Put (int id, Category category)
    {
        _uow.CategoryRepository.Update(category);
        _uow.Commit();
        return Ok(category);
    }
}
