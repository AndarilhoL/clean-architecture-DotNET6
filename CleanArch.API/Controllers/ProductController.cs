using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await _productService.GetProducts();
            if (products is null)
                return NotFound("Products not Found");

            return Ok(products);
        }

        [HttpGet("{id:long}", Name ="GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProductsById(long id)
        {
            var produto = await _productService.GetById(id);
            if (produto is null)
                return BadRequest();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDTO productDTO)
        {
            if (productDTO is null)
                return BadRequest();

            await _productService.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(long? id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return BadRequest("Id invalid");

            if (productDTO is null)
                return BadRequest();

            await _productService.Update(productDTO);
            return Ok(productDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(long id)
        {
            var product = await _productService.GetById(id);
            if (product is null)
                return BadRequest();

            await _productService.Remove(id);
            return Ok();
        }
    }
}
