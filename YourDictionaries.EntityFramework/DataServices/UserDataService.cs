using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourDictionaries.Domain.Models;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace YourDictionaries.EntityFramework.DataServices
{
    public class UserDataService : GenericDataService<User>, IUsersDataService
    {
        public UserDataService(AppDbContextFactory appDbContextFactory) : base(appDbContextFactory) { }

        public bool UserAlreadyExist(User user)
        {
            using (var context = AppDbContextFactory.CreateDbContext())
            {
                return context.Users.Any(u => u.Name == user.Name || u.Email == user.Email);
            }
        }

        public async Task<User> UserIsValid(User user)
        {
            using (var context = AppDbContextFactory.CreateDbContext())
            {
                var entity = await context.Users.FirstOrDefaultAsync(u => u.Name == user.Name || u.Email == user.Email && u.Password == user.Password);
                return entity;
            }
        }
    }
}
