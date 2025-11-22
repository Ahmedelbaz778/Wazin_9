using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using wAzin.Core.Entities;
using wAzin.Repositories.Interfaces;

namespace wAzin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeController(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeRepository.GetAllAsync();
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncomeById(int id)
        {
            var income = await _incomeRepository.GetByIdAsync(id);
            if (income == null) return NotFound();
            return Ok(income);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncome([FromBody] Income income)
        {
            await _incomeRepository.AddAsync(income);
            await _incomeRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIncomeById), new { id = income.Id }, income);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncome(int id, [FromBody] Income income)
        {
            var existing = await _incomeRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Amount = income.Amount;
            existing.Date = income.Date;
            existing.UserId = income.UserId;

            _incomeRepository.Update(existing);
            await _incomeRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var existing = await _incomeRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _incomeRepository.DeleteAsync(existing); // Async now
            await _incomeRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
