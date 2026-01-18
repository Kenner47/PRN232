using FUNewsManagementSystem.Repository.Models;
using FUNewsManagementSystem.Service.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemAccountsController : ControllerBase
    {
        private readonly ISystemAccountService _systemAccountService;

        public SystemAccountsController(ISystemAccountService systemAccountService)
        {
            _systemAccountService = systemAccountService;
        }

        // GET: api/SystemAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemAccount>>> GetSystemAccounts()
        {
            var accounts = await _systemAccountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        // GET: api/SystemAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemAccount>> GetSystemAccount(int id)
        {
            var account = await _systemAccountService.GetAccountByIdAsync(id);

            if (account == null)
            {
                return NotFound(new { message = $"Account with ID {id} not found." });
            }

            return Ok(account);
        }

        // GET: api/SystemAccounts/email/test@example.com
        [HttpGet("email/{email}")]
        public async Task<ActionResult<SystemAccount>> GetAccountByEmail(string email)
        {
            var account = await _systemAccountService.GetByEmailAsync(email);

            if (account == null)
            {
                return NotFound(new { message = $"Account with email {email} not found." });
            }

            return Ok(account);
        }

        // GET: api/SystemAccounts/role/1
        [HttpGet("role/{role}")]
        public async Task<ActionResult<IEnumerable<SystemAccount>>> GetAccountsByRole(int role)
        {
            var accounts = await _systemAccountService.GetAccountsByRoleAsync(role);
            return Ok(accounts);
        }

        // POST: api/SystemAccounts/login
        [HttpPost("login")]
        public async Task<ActionResult<SystemAccount>> Login([FromBody] LoginRequest request)
        {
            var account = await _systemAccountService.LoginAsync(request.Email, request.Password);

            if (account == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            return Ok(account);
        }

        // POST: api/SystemAccounts
        [HttpPost]
        public async Task<ActionResult<SystemAccount>> CreateSystemAccount(SystemAccount account)
        {
            var result = await _systemAccountService.CreateAccountAsync(account);

            if (!result)
            {
                return BadRequest(new { message = "Failed to create account. Email may already exist." });
            }

            return CreatedAtAction(nameof(GetSystemAccount), new { id = account.AccountId }, account);
        }

        // PUT: api/SystemAccounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSystemAccount(int id, SystemAccount account)
        {
            if (id != account.AccountId)
            {
                return BadRequest(new { message = "Account ID mismatch." });
            }

            var result = await _systemAccountService.UpdateAccountAsync(account);

            if (!result)
            {
                return NotFound(new { message = $"Account with ID {id} not found." });
            }

            return NoContent();
        }

        // DELETE: api/SystemAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemAccount(int id)
        {
            var result = await _systemAccountService.DeleteAccountAsync(id);

            if (!result)
            {
                return NotFound(new { message = $"Account with ID {id} not found." });
            }

            return NoContent();
        }
    }

    // DTO for login request
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}