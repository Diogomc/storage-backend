using Storage.Models;

namespace Storage.DTOs.Mappings;

public static class CategoryDTOMappingExtensions
{
    public static CategoryDTO? ToCategoryDTO (this Category category)
    {
        if(category is null)
        {
            return null;
        }

        return new CategoryDTO
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryName
        };
    }
    public static Category? ToCategory (this CategoryDTO categoryDTO)
    {
        if(categoryDTO is null)
        {
            return null;
        }

        return new Category
        {
            CategoryId = categoryDTO.CategoryId,
            CategoryName = categoryDTO.CategoryName
        };
    }
    public static IEnumerable<CategoryDTO>? ToCategoryDTOList (this IEnumerable<Category> categories)
    {
        return categories.Select(categories => new CategoryDTO
        {
            CategoryId = categories.CategoryId,
            CategoryName = categories.CategoryName
        }).ToList();
    }
}
