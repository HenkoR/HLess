using System.Collections.Generic;
using System.Threading.Tasks;
using Hless.Data.Models;

namespace Hless.Common.Repositories 
{
    public interface ISchemaRepository
    {
        Task<IEnumerable<Schema>> GetSchemasAsync(); 
        Task<Schema> GetSchemaAsync(long schemaId);
        Task<Schema> CreateSchemaAsync(Schema schema);
        Task<bool> UpdateSchemaAsync(Schema schema);
        Task<bool> PublishSchemaAsync(long schemaId);
        Task<bool> DeleteSchemaAsync(long schemaId);
    }
}