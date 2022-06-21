using CleanArch.Application.DTOs;

namespace CleanArch.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryById(long? id);
        Task<CategoryDTO> GetCategoryByName(string name);
        Task Add(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Remove(long? id);
    }
}
