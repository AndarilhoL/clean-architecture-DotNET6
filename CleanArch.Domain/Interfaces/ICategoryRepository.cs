using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetByIdAsync(long? id);
        Task<Category> GetByNameAsync(string name);
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category); 
        Task DeleteAsync(long? id);
    }
}
