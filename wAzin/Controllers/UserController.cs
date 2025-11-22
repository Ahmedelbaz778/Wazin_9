using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using wAzin.Core.Entities;
using wAzin.Repositories.Interfaces;

namespace wAzin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Name = user.Name;
            existing.Email = user.Email;
            existing.PasswordHash = user.PasswordHash;

            _userRepository.Update(existing);
            await _userRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _userRepository.DeleteAsync(existing); 
            await _userRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
