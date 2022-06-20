using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Services.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRespository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRespository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _categoryRespository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _categoryRespository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> GetCategoryByName(string name)
        {
            var category = await _categoryRespository.GetByNameAsync(name);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task Add(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRespository.CreateAsync(categoryEntity);
        }

        public async Task Update(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRespository.UpdateAsync(categoryEntity);
        }

        public async Task Remove(long? id)
        {
            var categoryEntity = await _categoryRespository.GetByIdAsync(id);
            if (categoryEntity != null)
                await _categoryRespository.DeleteAsync(id);
        }
    }
}
