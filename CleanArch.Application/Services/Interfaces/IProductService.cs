using CleanArch.Application.DTOs;

namespace CleanArch.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(long? id);

        //Task<ProductDTO> GetProductCategory(long? id);
        Task Add(ProductDTO productDto);
        Task Update(ProductDTO productDto);
        Task Remove(long? id);
    }
}
