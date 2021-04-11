using Data.Contracts.Interface;
using Data.Contracts.Models;
using Data.Services.Parser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Services
{
    public class CategoriesDataService : ICategoriesDataService
    {
        private const string CATEGORIES_FILE = "Categories.xml";
        public IEnumerable<Categories> GetCategories()
        {
            IEnumerable<Categories> categories = null;
            var path = FileManipulator.GetDataFilePath(CATEGORIES_FILE);
            var xmlData = ParseDataFromXml.ReadDataFromFile(path);
            if (xmlData != null)
            {
                categories = from user in xmlData.Descendants("category")
                             select new Categories
                             {
                                 CategoryId = Convert.ToInt32(user.Element("categoryId")?.Value),
                                 CategoryType = user.Element("categoryType")?.Value,
                                 Discounts = (from discount in user.Descendants("discount")
                                              select new Discount
                                              {
                                                  ItemVisible = Convert.ToBoolean(discount.Element("itemVisible")?.Value),
                                                  PricePercentage = Convert.ToInt32(discount.Element("pricePercentage")?.Value),
                                                  Applicable = Convert.ToBoolean(discount.Element("applicable")?.Value)
                                              }).FirstOrDefault()
                             };
            }
            return categories;
        }
    }
}
