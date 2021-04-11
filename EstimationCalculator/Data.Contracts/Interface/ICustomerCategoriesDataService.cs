using Data.Contracts.Models;
using System.Collections.Generic;

namespace Data.Contracts.Interface
{
    public interface ICustomerCategoriesDataService
    {
        public IEnumerable<CustomerCategories> GetCustomerCategories();
    }
}
