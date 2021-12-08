using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hless.Common.Repositories;
using Hless.Data.Models;
using Hless.Data.Tools.HashingTools;

namespace Hless.Data.InMemory.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> users = new()
        {
            new User
            {
                id = 0,
                Username = "Admin",
                EmailAddress = "admin@gmail.com",
                Password = Sha256.Hash("admin-password"),
                admin = true,
                CreatedById = 0,
                UpdatedById = 0,
            },
            new User
            {
                id = 1,
                Username = "Pieter",
                EmailAddress = "pieter@gmail.com",
                Password = Sha256.Hash("password"),
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
                            Username = user.Username,
                            EmailAddress = user.EmailAddress,
                            Password = user.Password,
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
