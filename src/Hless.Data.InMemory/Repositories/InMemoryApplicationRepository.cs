using Hless.Common.Repositories;
using Hless.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hless.Data.InMemory.Repositories
{
    public class InMemoryApplicationRepository : IApplicationRepository
    {
        private readonly List<Application> applications = new()
        {
            new Application
            {
                ApplicationId = 0,
                Name = "FirstApp",
                OwnerId = "ownerId here",
                CreatedBy = "creatorId here",
                CreatedAt = new DateTime(01, 02, 03, 04, 05, 06),
                LastModified = new DateTime(01, 02, 03, 04, 05, 06)
            }
        };

        public async Task CreateApplicationAsync(string name, string OwnerId)
        {
            await Task.Run(() =>
            {
                Application application = new Application()
                {
                    ApplicationId = applications.Count,
                    Name = name,
                    OwnerId = OwnerId,
                    CreatedBy = "CreatedBy", // TODO: Change to logged in user
                    CreatedAt = DateTime.Now,
                    LastModified = DateTime.Now,
                };

                applications.Add(application);
            });
        }

        public async Task<bool> DeleteApplicationAsync(long applicationId)
        {
            return await Task.Run(() => applications.Remove(applications.SingleOrDefault(app => app.ApplicationId == applicationId)));
        }

        public async Task<Application> GetApplicationAsync(long applicationId)
        {
            return await Task.Run(() => applications.Where(app => app.ApplicationId == applicationId).SingleOrDefault());
        }

        public async Task<IEnumerable<Application>> GetApplicationsAsync()
        {
            return await Task.FromResult(applications);
        }

        public async Task<bool> UpdateApplicationAsync(long applicationId, string name, string OwnerId)
        {
            return await Task.Run(() =>
            {
                Application oldApp = applications.SingleOrDefault(app => app.ApplicationId == applicationId);

                if (oldApp != null)
                {
                    Application newApp = new Application()
                    {
                        ApplicationId = oldApp.ApplicationId,
                        Name = name,
                        OwnerId = OwnerId,
                        CreatedBy = oldApp.CreatedBy, // TODO: Change to logged in user
                        CreatedAt = oldApp.CreatedAt,
                        LastModified = DateTime.Now,
                    };

                    var indexOldApp = applications.IndexOf(oldApp);

                    applications[indexOldApp] = newApp;

                    return true;
                }
                else
                {
                    return false;
                }
            });
        }
    }
}
