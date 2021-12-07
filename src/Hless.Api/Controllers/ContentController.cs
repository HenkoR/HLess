using Hless.Common.Repositories;
using Hless.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hless.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class ContentController : BaseController
    {
        private IContentRepository _reposistory;
        public ContentController(IContentRepository repository)
        {
            _reposistory = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Content>> GetContentsAsync()
        {
            return await _reposistory.GetContentsAsync();
        }
    }
}
