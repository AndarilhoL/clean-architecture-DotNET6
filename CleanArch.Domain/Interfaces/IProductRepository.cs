using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetCategoriesAsync();
        Task<Product> GetByIdAsync(long? id);
        Task<Product> GetByNameAsync(string name);
        Task<Product> GetProductCategoryAsync(long? id);
        Task<Product> CreateAsync(Product category);
        Task<Product> UpdateAsync(Product category);
        Task DeleteAsync(long id);
    }
}