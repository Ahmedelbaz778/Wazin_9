using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using wAzin.Core.Entities;
using wAzin.Repositories.Interfaces;

namespace wAzin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _expenseRepository.GetAllAsync();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null) return NotFound();
            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] Expense expense)
        {
            await _expenseRepository.AddAsync(expense);
            await _expenseRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExpenseById), new { id = expense.Id }, expense);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, [FromBody] Expense expense)
        {
            var existing = await _expenseRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Amount = expense.Amount;
            existing.Date = expense.Date;
            existing.UserId = expense.UserId;
            existing.CategoryId = expense.CategoryId;
            existing.SavingPlanId = expense.SavingPlanId;
            existing.Description = expense.Description;

            _expenseRepository.Update(existing);
            await _expenseRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var existing = await _expenseRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _expenseRepository.DeleteAsync(existing);
            await _expenseRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
