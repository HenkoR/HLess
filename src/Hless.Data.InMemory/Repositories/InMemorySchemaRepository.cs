using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Hless.Common.Repositories;
using Hless.Data.Models;

namespace Hless.Data.InMemory.Repositories
{
    public class InMemorySchemaRepository : ISchemaRepository
    {
        private readonly List<Schema> schemas = new() 
        {
            new Schema { SchemaId = 1, Name = "HomePage", Definition = "{\n\"fields\":[\n{\n\"name\":\"Title\",\n\"type\":\"text\"\n}\n]\n}" }
        };

        public Task CreateSchemaAsync(Schema schema)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Schema> GetSchemaAsync(long schemaId)
        {
            var schema = schemas.Where(schema => schema.SchemaId == schemaId).SingleOrDefault();
            return await Task.FromResult(schema);
        }

        public async Task<IEnumerable<Schema>> GetSchemasAsync()
        {
            return await Task.FromResult(schemas);
        }

        public Task PublishSchemaAsync(long schemaId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateSchemaAsync(Schema schema)
        {
            throw new System.NotImplementedException();
        }
    }
}