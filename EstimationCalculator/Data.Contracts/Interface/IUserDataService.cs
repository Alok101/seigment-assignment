using Data.Contracts.Models;
using System.Collections.Generic;

namespace Data.Contracts.Interface
{
    public interface IUserDataService
    {
        public IEnumerable<UserLoginDetails> GetUser();
    }
}
