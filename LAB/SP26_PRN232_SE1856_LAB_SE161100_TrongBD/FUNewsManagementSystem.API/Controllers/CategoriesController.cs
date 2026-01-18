using FUNewsManagementSystem.Repository.Models;
using FUNewsManagementSystem.Service.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound(new { message = $"Category with ID {id} not found." });
            }

            return Ok(category);
        }

        // GET: api/Categories/5/children
        [HttpGet("{id}/children")]
        public async Task<ActionResult<Category>> GetCategoryWithChildren(int id)
        {
            var category = await _categoryService.GetCategoryWithChildrenAsync(id);

            if (category == null)
            {
                return NotFound(new { message = $"Category with ID {id} not found." });
            }

            return Ok(category);
        }

        // GET: api/Categories/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Category>>> GetActiveCategories()
        {
            var categories = await _categoryService.GetActiveCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/Categories/parent/5
        [HttpGet("parent/{parentId?}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesByParent(int? parentId)
        {
            var categories = await _categoryService.GetCategoriesByParentIdAsync(parentId);
            return Ok(categories);
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            var result = await _categoryService.CreateCategoryAsync(category);

            if (!result)
            {
                return BadRequest(new { message = "Failed to create category." });
            }

            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest(new { message = "Category ID mismatch." });
            }

            var result = await _categoryService.UpdateCategoryAsync(category);

            if (!result)
            {
                return NotFound(new { message = $"Category with ID {id} not found." });
            }

            return NoContent();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);

            if (!result)
            {
                return NotFound(new { message = $"Category with ID {id} not found." });
            }

            return NoContent();
        }
    }
}