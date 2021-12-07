using Hless.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hless.Common.Repositories
{
    public interface IContentRepository
    {
        Task<IEnumerable<Content>> GetContentsAsync();
        Task<IEnumerable<Content>> GetContentsAsync(long schemaId);
        Task<Content> GetContentAsync(long contentId);
        Task<Content> CreateContentAsync(Content content);
        Task<bool> UpdateContentAsync(Content content);
        Task<bool> PublishContentAsync(long contentId);
        Task<bool> DeleteContentAsync(long contentId);
    }
}
