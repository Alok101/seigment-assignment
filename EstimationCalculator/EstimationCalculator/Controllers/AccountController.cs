using Business.Contracts.Interface;
using Business.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OuthServer;

namespace EstimationCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        private readonly ICustomerService _customerService;

        public AccountController(
            IUserLoginService userLoginService
            , ICustomerService customerService)
        {
            _userLoginService = userLoginService;
            _customerService = customerService;
        }

        [AllowAnonymous]
        [HttpPost, Route("Login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user == null) return BadRequest("Invalid Client Request");
            var userDetails = _userLoginService.UserExist(user);
            if (userDetails != null)
            {
                var customerDetails = _customerService.GetCustomerDetails(userDetails);
                return Ok(new { Token = GenerateToken.GenerateJwtToken(userDetails.UserId.ToString()), CustomerDetails = customerDetails });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
