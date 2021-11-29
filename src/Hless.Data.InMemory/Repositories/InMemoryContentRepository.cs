using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hless.Common.Repositories;
using Hless.Data.Models;

namespace Hless.Data.InMemory.Repositories
{
    public class InMemoryContentRepository : IContentRepository
    {
        private readonly List<Content> lstContent = new()
        {
            new Content
            {
                ContentId = 0,
                ContentFinal = "{}",
                DraftContent = "",
                CreatedBy = "UserId",
                CreatedAt = new DateTime(1, 2, 3, 4, 5, 6),
                LastModified = new DateTime(2, 3, 4, 5, 6, 7),
                FirstPublished = new DateTime(1, 2, 3, 4, 5, 6),
                LastPublished = new DateTime(2, 3, 4, 5, 6, 6),
                SchemaId = 0
            }
        };

        public async Task<Content> CreateContentAsync(Content content)
        {
            return await Task.Run(() =>
            {
                try
                {
                    Content newContent = new Content()
                    {
                        ContentId = lstContent.Count,
                        ContentFinal = "{}",
                        DraftContent = content.DraftContent,
                        CreatedBy = "UserId", //Updated with logged in user
                        CreatedAt = DateTime.Now,
                        LastModified = DateTime.Now,
                        FirstPublished = null,
                        LastPublished = null,
                        SchemaId = 0
                    };
                    lstContent.Add(newContent);

                    return newContent;
                }
                catch
                {
                    return null;
                }
            });
        }

        public async Task<bool> DeleteContentAsync(long contentId)
        {
            return await Task.Run(() =>
            {
                return lstContent.Remove(lstContent.Find(c => c.ContentId == contentId));
            });
        }

        public async Task<Content> GetContentAsync(long contentId)
        {
            return await Task.Run(() => lstContent.Find(c => c.ContentId == contentId));
        }

        public async Task<IEnumerable<Content>> GetContentsAsync()
        {
            return await Task.FromResult(lstContent);
        }

        public async Task<IEnumerable<Content>> GetContentsAsync(long schemaId)
        {
            return await Task.FromResult(lstContent.Where(x => x.SchemaId == schemaId));
        }

        public async Task<bool> PublishContentAsync(long contentId)
        {
            return await Task.Run(() =>
            {
                try
                {
                    int index = lstContent.FindIndex(x => x.ContentId == contentId);

                    Content newContent = new Content()
                    {
                        ContentId = lstContent[index].ContentId,
                        ContentFinal = lstContent[index].DraftContent,
                        DraftContent = "",
                        CreatedBy = lstContent[index].CreatedBy,
                        CreatedAt = lstContent[index].CreatedAt,
                        LastModified = DateTime.Now,
                        FirstPublished = lstContent[index].FirstPublished == null ? lstContent[index].FirstPublished : DateTime.Now,
                        LastPublished = DateTime.Now,
                        SchemaId = 0
                    };

                    lstContent[index] = newContent;

                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }


        public async Task<bool> UpdateContentAsync(Content content)
        {
            return await Task.Run(() =>
            {
                try
                {
                    int i = lstContent.FindIndex(c => c.ContentId == content.ContentId);
                    lstContent[i].DraftContent = content.DraftContent;
                    lstContent[i].LastModified = DateTime.Now;

                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

    }
}

