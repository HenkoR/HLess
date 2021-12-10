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
using System.Security.Claims;

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
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.GetUsersAsync();
        }

        [HttpGet]
        public async Task<User> Get(long userId)
        {
            return await _repository.GetUser(userId);
        }

        [HttpPost]
        public async Task<User> Add(NewUserDto user)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if(identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;

                var id = identity.FindFirst(ClaimTypes.Actor).Value;

                User newUser = new User
                {
                    Username = user.UserName,
                    EmailAddress = user.EmailAddress,
                    Password = user.Password,
                    admin = user.Admin,
                    CreatedById = long.Parse(id),
                    UpdatedById = long.Parse(id),
                };

                return await _repository.AddUser(newUser);
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        public Task<string> Test()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;

                return Task.FromResult(identity.FindFirst(ClaimTypes.Name).Value + " " + identity.FindFirst(ClaimTypes.Actor).Value);
            }
            else
            {
                return null;
            }

        }

        [HttpDelete]
        public async Task<bool> Delete(long userId)
        {
            return await _repository.RemoveUser(userId);
        }

        [HttpPost]
        public async Task<bool> Update([FromBody] UpdateUserDto updateUser)
        {
            return await _repository.UpdateUser(updateUser.userId, updateUser.user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserDto user)
        {
            User u = await _repository.GetUser(user.UserName);
            user.Id = u.id;
            var token = _jwtAuthenticationManager.Authenticate(user);

            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
