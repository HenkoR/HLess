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
