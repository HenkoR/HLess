using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hless.Data.Models.Dto;
using Hless.Data.Models;

namespace Hless.Common.Repositories
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetApplicationsAsync();
        Task<Application> GetApplicationAsync(long applicationId);
        Task CreateApplicationAsync(ApplicationCreateDto application);
        Task<bool> UpdateApplicationAsync(ApplicationDto application);
        Task<bool> DeleteApplicationAsync(long applicationId);
    }
}
