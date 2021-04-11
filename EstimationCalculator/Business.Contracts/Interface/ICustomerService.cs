using Business.Contracts.Models;

namespace Business.Contracts.Interface
{
    public interface ICustomerService
    {
        public CustomerViewModel GetCustomerDetails(LoginModel loginModel);
    }
}
