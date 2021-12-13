using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hless.Data.Models;
using Hless.Common.Repositories;

namespace Hless.Data.InMemory.Repositories
{
    internal class InMemoryApiKeyRepository : IKeyRepository
    {
        private List<ApiKey> _apiKeyList;

        public InMemoryApiKeyRepository(List<ApiKey> apiKeyList)
        {
            _apiKeyList = apiKeyList;
        }

        public async Task<ApiKey> ChangeApiKey(long keyId)
        {
            return await Task.FromResult(_apiKeyList.Find(x => x.Id == keyId).UpdateKey());
        }

        public async Task<ApiKey> CreateNewKeyAsync(long userId, long AppId)
        {
            return await Task.Run(() =>
            {
                try
                {
                    ApiKey newKey = new ApiKey(_apiKeyList.Count, userId, AppId);

                    _apiKeyList.Add(newKey);

                    return _apiKeyList[_apiKeyList.Count - 1];
                }
                catch
                {
                    return null;
                }
            });
        }

        public async Task<bool> DeleteKeyAsync(string key)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _apiKeyList.Remove(_apiKeyList.Find(x => x.Key == key));

                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<IEnumerable<ApiKey>> GetAll()
        {
            return await Task.FromResult(_apiKeyList);
        }

        public async Task<ApiKey[]> GetKeyApplicationAsync(long applicationId)
        {
            return await Task.FromResult(_apiKeyList.FindAll(x => x.ApplicationId == applicationId).ToArray());
        }

        public async Task<ApiKey> GetKeyAsync(string key)
        {
            return await Task.FromResult(_apiKeyList.Find(x => x.Key == key));
        }

        public async Task<ApiKey[]> GetKeyUserAsync(long userId)
        {
            return await Task.FromResult(_apiKeyList.FindAll(x => x.UserId == userId).ToArray());
        }

        public async Task<ApiKey> UpdateApiKey(ApiKey oldKey, ApiKey newKey)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return _apiKeyList[_apiKeyList.IndexOf(oldKey)] = newKey;
                }
                catch
                {
                    return null;
                }
            });
        }
    }
}
