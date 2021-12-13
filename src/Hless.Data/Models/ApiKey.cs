using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hless.Data.Models
{
    public record ApiKey
    {
        public ApiKey(int id, long userId, long applicationId)
        {
            Id = id;
            Key = generateApiKey();
            UserId = userId;
            ApplicationId = applicationId;
        }

        public int Id { get; private set; }
        public string Key { get; private set; }
        public long UserId { get; private set; }
        public long ApplicationId { get; private set; }

        public ApiKey UpdateKey()
        {
            try
            {
                Key = generateApiKey();

                return this;
            }
            catch
            {
                return null;
            }
        }

        public static string generateApiKey()
        {
            return "api-key"; // return api key here
        }
    }
}
