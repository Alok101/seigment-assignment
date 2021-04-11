using Business.Contracts.Models;

namespace Business.Contracts.Interface
{
    public interface IUserLoginService
    {
        public LoginModel UserExist(LoginModel user);
    }
}
