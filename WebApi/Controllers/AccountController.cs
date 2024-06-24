using Application.Abstractions.Services;
using Application.Models.User;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(IUserService accountService) : Controller
    {
        private readonly IUserService _accountService = accountService;

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(RegisterUser user, CancellationToken cancellationToken)
        {
            await _accountService.RegisterUser(user, cancellationToken);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser(LoginUser user, CancellationToken cancellationToken) 
        {
            var token = await _accountService.LoginUser(user, cancellationToken);
            return Ok(token);
        }
        
        [HttpGet]
        public async Task<ActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var users = await _accountService.GetAll(cancellationToken);

            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult> GetUser(string email, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetUserByEmail(email, cancellationToken);

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(Domain.Entities.User user, CancellationToken cancellationToken)
        {
            var result = await _accountService.UpdateUser(user, cancellationToken);

            return Ok(result.ToString());
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> DeleteHarbour(string email, CancellationToken cancellationToken)
        {
            await _accountService.RemoveUser(email, cancellationToken);

            return NoContent();
        }

    }
}
