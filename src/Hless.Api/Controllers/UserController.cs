using Hless.Common.Repositories;
using Hless.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hless.Api.Attributes;

namespace Hless.Api.Controllers
{
    [ApiKeyAdmin]
    [Route("[controller]/[action]")]
    public class UserController : BaseController
    {
        readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _repository.GetUsersAsync();
        }
    }
}
