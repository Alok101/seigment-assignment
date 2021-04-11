using Business.Contracts.Interface;
using Business.Contracts.Models;
using Data.Contracts.Interface;
using System.Linq;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICategoriesDataService _categoriesDataService;
        private readonly ICustomerCategoriesDataService _customerCategoriesDataService;
        public CustomerService(
            ICategoriesDataService categoriesDataService,
            ICustomerCategoriesDataService customerCategoriesDataService
            )
        {
            _categoriesDataService = categoriesDataService;
            _customerCategoriesDataService = customerCategoriesDataService;
        }
        public CustomerViewModel GetCustomerDetails(LoginModel loginModel)
        {
            var customerDetails = from cc in _customerCategoriesDataService.GetCustomerCategories().ToList().Where(x => x.UserId == loginModel.UserId)
                                  join category in _categoriesDataService.GetCategories().ToList() on cc.CategoryId equals category.CategoryId
                                  select new CustomerViewModel
                                  {
                                      Id = loginModel.UserId,
                                      Name = loginModel.UserName,
                                      Type = category.CategoryType,
                                      DiscountRule = category.Discounts
                                  };
            return customerDetails.FirstOrDefault();
        }
    }
}
