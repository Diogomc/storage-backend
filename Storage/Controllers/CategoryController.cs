using Microsoft.AspNetCore.Mvc;
using Storage.DTOs;
using Storage.DTOs.Mappings;
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
    public ActionResult<IEnumerable<CategoryDTO>> Get()
    {
        var getCategories = _uow.CategoryRepository.GetAll().ToList();

        var categoriesDto = getCategories.ToCategoryDTOList();

        return Ok(categoriesDto);
    }
    [HttpGet("{id:int}", Name ="TakeCategory")]
    public ActionResult<CategoryDTO> GetById(int id)
    {
        var getCategoryId = _uow.CategoryRepository.GetById(c => c.CategoryId == id);

        var categoryDtoId = getCategoryId.ToCategoryDTO();

        return Ok(categoryDtoId);
    }
    [HttpPost]
    public ActionResult<CategoryDTO> Post (CategoryDTO categoryDto)
    {

        var category = categoryDto.ToCategory();

        var createCategory = _uow.CategoryRepository.Create(category);
        _uow.Commit();

        var createCategoryDto = createCategory.ToCategoryDTO();

        return new CreatedAtRouteResult("TakeCategory",
            new { id = createCategoryDto.CategoryId }, createCategoryDto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<CategoryDTO> Delete(int id)
    {
        var getCategoryId = _uow.CategoryRepository.GetById(c => c.CategoryId == id);


        var deletedCategory = _uow.CategoryRepository.Delete(getCategoryId);
        _uow.Commit();

        var categoryDto = deletedCategory.ToCategoryDTO();
        return Ok(categoryDto);
    }
    [HttpPut("{id:int}")]
    public ActionResult<CategoryDTO> Put (int id, CategoryDTO categoryDto)
    {
        var category = categoryDto.ToCategory();
        var editedCategory = _uow.CategoryRepository.Update(category);
        _uow.Commit();

        var editedCategoryDto = editedCategory.ToCategoryDTO();
        return Ok(editedCategoryDto);
    }
}
