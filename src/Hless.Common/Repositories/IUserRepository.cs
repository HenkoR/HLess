using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hless.Data.Models;

namespace Hless.Common.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> AddUser(User user);
        public Task<bool> RemoveUser(long userId);
        public Task<bool> UpdateUser(long userId, User user);
        public Task<User> GetUser(long userId);
    }
}
