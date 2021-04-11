using Data.Contracts.Models;
using System.Collections.Generic;

namespace Data.Contracts.Interface
{
    public interface ICategoriesDataService
    {
        public IEnumerable<Categories> GetCategories();
    }
}
