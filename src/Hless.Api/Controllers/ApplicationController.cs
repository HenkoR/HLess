using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hless.Common.Repositories;
using Hless.Data.Models.Dto;
using Hless.Api.Extensions.Models;
using Hless.Data.Models;

namespace Hless.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class ApplicationController : Controller
    {
        public IApplicationRepository _repository;

        public ApplicationController(IApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationDto>> GetApplicationsAsync()
        {
            var application = (await _repository.GetApplicationsAsync())
                .Select(app => app.AsDto());
            return application;
        }

        [HttpPost]
        public async void CreateApplicationAsync(ApplicationCreateDto application)
        {
            await _repository.CreateApplicationAsync(application);
        }

        [HttpGet]
        public async Task<Application> GetApplicationAsync(long applicationId)
        {
            return await _repository.GetApplicationAsync(applicationId);
        }

        [HttpPut]
        public async Task<bool> UpdateApplicationAsync(ApplicationDto application)
        {
            return await _repository.UpdateApplicationAsync(application);
        }

        [HttpDelete]
        public async Task<bool> DeleteApplicationAsync(long applicationId)
        {
            return await _repository.DeleteApplicationAsync(applicationId);
        }
    }
}
