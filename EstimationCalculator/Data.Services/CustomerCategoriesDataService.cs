using Data.Contracts.Interface;
using Data.Contracts.Models;
using Data.Services.Parser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Services
{
    public class CustomerCategoriesDataService : ICustomerCategoriesDataService
    {
        private const string CUST_CATEGORY_FILE = "CustomerCategories.xml";
        public IEnumerable<CustomerCategories> GetCustomerCategories()
        {
            IEnumerable<CustomerCategories> customerCategories = null;
            var path = FileManipulator.GetDataFilePath(CUST_CATEGORY_FILE);
            var xmlData = ParseDataFromXml.ReadDataFromFile(path);
            if (xmlData != null)
            {
                customerCategories = from cc in xmlData.Descendants("customerCategory")
                                     select new CustomerCategories
                                     {
                                         Id = Convert.ToInt32(cc.Element("id")?.Value),
                                         UserId = Convert.ToInt32(cc.Element("userId")?.Value),
                                         CategoryId = Convert.ToInt32(cc.Element("categoryId")?.Value)
                                     };
            }
            return customerCategories;
        }
    }
}
