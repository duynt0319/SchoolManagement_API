using BusinessObjects.DataAccess;
using Microsoft.AspNetCore.Mvc;
using SchoolRepository;
using SchoolService;

namespace SchoolManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public WeatherForecastController( IAccountService accountService)
        {
            _accountService = accountService;
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
    }
}