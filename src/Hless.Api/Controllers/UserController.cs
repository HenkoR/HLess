using Hless.Common.Repositories;
using Hless.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hless.Api.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Hless.Api.JWT;

namespace Hless.Api.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        readonly IUserRepository _repository;
        readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public UserController(IUserRepository repository, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _repository = repository;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _repository.GetUsersAsync();
        }

        [HttpGet]
        public async Task<User> GetUser(long userId)
        {
            return await _repository.GetUser(userId);
        }

        [HttpPost]
        public async Task<User> AddUser(User user)
        {
            return await _repository.AddUser(user);
        }

        [HttpDelete]
        public async Task<bool> DeleteUser(long userId)
        {
            return await _repository.RemoveUser(userId);
        }

        [HttpPost]
        public async Task<bool> UpdateUser([FromBody] UpdateUserDto updateUser)
        {
            return await _repository.UpdateUser(updateUser.userId, updateUser.user);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserDto user)
        {
            var token = _jwtAuthenticationManager.Authenticate(user);

            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
