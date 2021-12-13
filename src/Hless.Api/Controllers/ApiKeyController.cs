using Hless.Common.Repositories;
using Hless.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hless.Api.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ApiKeyController : BaseController
    {
        private IKeyRepository repository;

        public ApiKeyController(IKeyRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ApiKey>> getKeys()
        {
            return await repository.GetAll();
        }
    }
}
