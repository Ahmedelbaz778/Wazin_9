using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using wAzin.Core.Entities;
using wAzin.Repositories.Interfaces;

namespace wAzin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly ISavingPlanRepository _budgetRepository;

        public BudgetController(ISavingPlanRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBudgets()
        {
            var budgets = await _budgetRepository.GetAllAsync();
            return Ok(budgets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetById(int id)
        {
            var budget = await _budgetRepository.GetByIdAsync(id);
            if (budget == null) return NotFound();
            return Ok(budget);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBudgetByUser(int userId)
        {
            var budget = await _budgetRepository.GetBudgetByUserIdAsync(userId);
            if (budget == null) return NotFound();
            return Ok(budget);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBudget([FromBody] SavingPlan budget)
        {
            await _budgetRepository.AddAsync(budget);
            await _budgetRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBudgetById), new { id = budget.Id }, budget);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBudget(int id, [FromBody] SavingPlan budget)
        {
            var existing = await _budgetRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.LimitAmount = budget.LimitAmount;
            existing.StartDate = budget.StartDate;
            existing.EndDate = budget.EndDate;
            existing.UserId = budget.UserId;
            

            _budgetRepository.Update(existing);
            await _budgetRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(int id)
        {
            var existing = await _budgetRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _budgetRepository.DeleteAsync(existing);
            await _budgetRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
