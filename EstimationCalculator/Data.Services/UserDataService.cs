using Data.Contracts.Interface;
using Data.Contracts.Models;
using Data.Services.Parser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Services
{
    public class UserDataService : IUserDataService
    {
        private const string USER_LOGIN_FILE = "UserLogins.xml";
        public IEnumerable<UserLoginDetails> GetUser()
        {
            IEnumerable<UserLoginDetails> users = null;
            var path = FileManipulator.GetDataFilePath(USER_LOGIN_FILE);
            var userLogins = ParseDataFromXml.ReadDataFromFile(path);
            if (userLogins != null)
            {
                users = from user in userLogins.Descendants("user")
                        select new UserLoginDetails
                        {
                            UserId = Convert.ToInt32(user.Element("userId")?.Value),
                            UserName = user.Element("userName")?.Value,
                            UserPassword = user.Element("password")?.Value,
                        };
            }
            return users;
        }
    }
}
