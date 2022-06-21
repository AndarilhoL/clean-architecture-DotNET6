using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await _categoryService.GetCategories();

            if (categories is null)
                return NotFound("Categories not Found");

            return Ok(categories);
        }

        [HttpGet("{id:long}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(long? id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category is null)
                return NotFound("Category not Found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO is null)
                return BadRequest("Invalid Data");

            await _categoryService.Add(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(long? id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
                return BadRequest();

            if (categoryDTO == null)
                return BadRequest();

            await _categoryService.Update(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(long id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category is null)
                return BadRequest();

            await _categoryService.Remove(id);
            return Ok();
        }
    }
}
