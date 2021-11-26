using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hless.Data.Models;

namespace Hless.Common.Repositories
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetApplicationsAsync();
        Task<Application> GetApplicationAsync(long applicationId);
        Task CreateApplicationAsync(string name, string OwnerId);
        Task<bool> UpdateApplicationAsync(long applicationId, string name, string OwnerId);
        Task<bool> DeleteApplicationAsync(long applicationId);
    }
}
