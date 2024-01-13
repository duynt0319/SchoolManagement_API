using BusinessObjects.DataAccess;
using Microsoft.AspNetCore.Mvc;
using SchoolRepository;
using SchoolService;

namespace SchoolManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController (IAccountService accountService, ILogger<AccountController > logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpGet("Login")]
        public IActionResult GetAccount(string email, string password)
        {
            var account = _accountService.GetAccountByEmail(email, password);
            if (account == null)
            {
                return NotFound("can not found account");
            }
            return Ok(account);
        }

        [HttpGet(Name ="GetListAccount")]
        public IActionResult GetAccounts() 
        { 
            List<Account> accounts = _accountService.GetAccounts();
            if(accounts == null)
            {
                return NotFound("List empty");
            }
            return Ok(accounts);
        }

        [HttpPost("Create")]
        public IActionResult AddAccount([FromBody] Account account)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                bool isSuccess = _accountService.AddAccount(account);
                if (isSuccess)
                {
                    return Ok("Account was add successed!");
                }
                else
                {
                    var checkDuplicate = _accountService.GetAccountByEmail(account.Email);
                    if (checkDuplicate != null)
                    {
                        return BadRequest("Email is already taken. Please choose a different email.");
                    }
                    else
                    {
                        return BadRequest("Add failed");
                    }
                }

            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteAccount(string userName)
        {
            try
            {
                bool isSuccess = _accountService.RemoveAccount(userName);

                if (isSuccess)
                {
                    return Ok("Account was removed successfully!");
                }
                else
                {
                    return BadRequest("Failed to remove account. Account not found or deletion failed.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to remove account. {ex.Message}");
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateAccount(Account account)
        {
            try
            {
                bool result = _accountService.UpdateAccount(account);
                if (!result)
                {
                    return BadRequest("Failed to update account. Account not found or updation failed.");
                }
                return Ok("Account was updated successfully!");
            } catch(Exception ex)
            {
                return BadRequest($"Failed to update account. {ex.Message}");
            }
        }
    }
}
