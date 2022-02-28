using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourDictionaries.Domain.Models;

namespace YourDictionaries.EntityFramework.DataServices.Interfaces
{
    public interface IUsersDataService : IDataService<User>
    {
        public Task<User> UserIsValid(User user);
        public bool UserAlreadyExist(User user);
    }
}
