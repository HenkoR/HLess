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
        public async Task<IEnumerable<Content>> GetContents()
        {
            return await _reposistory.GetContentsAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<Content>> GetSchemaContents(long schemaId)
        {
            return await _reposistory.GetContentsAsync(schemaId);
        }

        [HttpGet]
        public async Task<Content> GetContent(long contentId)
        {
            return await _reposistory.GetContentAsync(contentId);
        }

        [HttpPost]
        public async Task<Content> CreateContent(Content content)
        {
            return await _reposistory.CreateContentAsync(content);
        }
        [HttpPut]
        public async Task<bool> UpdateContent(Content content)
        {
            return await _reposistory.UpdateContentAsync(content);
        }
        [HttpDelete]
        public async Task<bool> DeleteContent(long contentId)
        {
            return await _reposistory.DeleteContentAsync(contentId);
        }
        [HttpGet]
        public async Task<bool> PublishContent(long contentId)
        {
            return await _reposistory.PublishContentAsync(contentId);
        }
    }
}
