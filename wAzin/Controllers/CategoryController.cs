using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using wAzin.Core.Entities;
using wAzin.Repositories.Interfaces;

namespace wAzin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            var existing = await _categoryRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Name = category.Name;

            _categoryRepository.Update(existing);
            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var existing = await _categoryRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _categoryRepository.DeleteAsync(existing);
            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
