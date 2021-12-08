using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hless.Common.Repositories;
using Hless.Data.Models;

namespace Hless.Data.InMemory.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> users = new()
        {
            new User
            {
                id = 0,
                Name = "Admin",
                EmailAddress = "admin@gmail.com",
                ApiKey = "admin-test-api-key",
                admin = true,
                CreatedById = 0,
                UpdatedById = 0,
            },
            new User
            {
                id = 1,
                Name = "Pieter",
                EmailAddress = "pieter@gmail.com",
                ApiKey = "test-api-key",
                admin = false,
                CreatedById = 0,
                UpdatedById = 0,
            }
        };

        public Task<User> AddUser(User user)
        {
            return Task.Run(() =>
            {
                try
                {
                    users.Add(user);
                    return user;
                }
                catch
                {
                    return null;
                }
            });
        }

        public Task<User> GetUser(long userId)
        {
            return Task.FromResult(users.FirstOrDefault(x => x.id == userId));
        }
        public Task<User> GetUser(string apiKey)
        {
            return Task.FromResult(users.FirstOrDefault(x => x.ApiKey == apiKey));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await Task.FromResult(users);
        }

        public Task<bool> RemoveUser(long userId)
        {
            return Task.FromResult(users.Remove(users.FirstOrDefault(x => x.id == userId)));
        }

        public Task<bool> UpdateUser(long userId, User user)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (users.Exists(x => x.id == userId))
                    {

                        var i = users.IndexOf(users.FirstOrDefault(x => x.id == user.id));

                        var newUser = new User
                        {
                            id = userId,
                            Name = user.Name,
                            EmailAddress = user.EmailAddress,
                            ApiKey = user.ApiKey,
                            admin = user.admin,
                            CreatedById = user.CreatedById,
                            UpdatedById = user.UpdatedById,
                        };


                        users[i] = newUser;

                        return true;
                    }
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
