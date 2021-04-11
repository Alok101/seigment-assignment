using Business.Contracts.Interface;
using Business.Contracts.Models;
using Data.Contracts.Interface;
using System.Linq;

namespace Business.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserDataService _userDataService;
        public UserLoginService(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }
        public LoginModel UserExist(LoginModel user)
        {
            var users = _userDataService.GetUser();
            var userDetails = users.Where(x => x.UserName.ToLower() == user.UserName.ToLower() && x.UserPassword == user.UserPassword)
                .Select(x => new LoginModel { UserId = x.UserId, UserName = x.UserName }).FirstOrDefault();
            return userDetails;
        }
    }
}
