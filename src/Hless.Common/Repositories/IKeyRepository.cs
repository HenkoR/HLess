using Hless.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hless.Common.Repositories
{
    public interface IKeyRepository
    {
        Task<IEnumerable<ApiKey>> GetAll();
        Task<ApiKey> GetKeyAsync(string key);
        Task<ApiKey[]> GetKeyUserAsync(long userId);
        Task<ApiKey[]> GetKeyApplicationAsync(long applicationId);
        Task<bool> DeleteKeyAsync(string key);
        Task<ApiKey> CreateNewKeyAsync(long userId, long AppId);
        Task<ApiKey> UpdateApiKey(ApiKey oldKey, ApiKey newKey);
        Task<ApiKey> ChangeApiKey(long keyId);
    }
}
