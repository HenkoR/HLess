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
        private readonly ISchemaRepository _schemaRepository;
        public InMemoryContentRepository(ISchemaRepository schemaRepository)
        {
            _schemaRepository = schemaRepository;
        }

        private readonly List<Content> lstContent = new()
        {
            new Content
            {
                ContentId = 1,
                ContentFinal = null,
                DraftContent = new Dictionary<string, string>
                {

                },
                CreatedBy = "UserId",
                CreatedAt = new DateTime(1, 2, 3, 4, 5, 6),
                LastModified = new DateTime(2, 3, 4, 5, 6, 7),
                FirstPublished = new DateTime(1, 2, 3, 4, 5, 6),
                LastPublished = new DateTime(2, 3, 4, 5, 6, 6),
                SchemaId = 1
            }
        };

        public async Task<Content> CreateContentAsync(Content content)
        {
            return await Task.Run(() =>
            {
                try
                {
                    // checks if schemaId is specified
                    if (content.SchemaId <= 0)
                        return null;

                    //checks if repository exists
                    if (_schemaRepository.GetSchemasAsync().Result.ToList().Find(s => s.SchemaId == content.SchemaId) == null)
                        return null;

                    Content newContent = new Content()
                    {
                        ContentId = lstContent.Count + 1,
                        ContentFinal = null,
                        DraftContent = content.DraftContent,
                        CreatedBy = "UserId", // TODO: Updated with logged in user
                        CreatedAt = DateTime.Now,
                        LastModified = DateTime.Now,
                        FirstPublished = null,
                        LastPublished = null,
                        SchemaId = content.SchemaId,
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

                    //checks if content exists with specified Id
                    if (index == -1)
                        return false;

                    Content newContent = new Content()
                    {
                        ContentId = lstContent[index].ContentId,
                        ContentFinal = lstContent[index].DraftContent,
                        DraftContent = null,
                        CreatedBy = lstContent[index].CreatedBy,
                        CreatedAt = lstContent[index].CreatedAt,
                        LastModified = DateTime.Now,
                        FirstPublished = lstContent[index].FirstPublished == null ? lstContent[index].FirstPublished : DateTime.Now,
                        LastPublished = DateTime.Now,
                        SchemaId = lstContent[index].SchemaId
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

                    //checks if content exists with specified Id
                    if (i == -1)
                        return false;

                    //checks whether DraftContent is specified
                    if (content.DraftContent != null)
                        lstContent[i].DraftContent = content.DraftContent;

                    // checks if schemaId is specified and if that id exists in database
                    if (content.SchemaId != 0 && _schemaRepository.GetSchemasAsync().Result.ToList().Find(s => s.SchemaId == content.SchemaId) != null)
                        lstContent[i].SchemaId = content.SchemaId;

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

