using System;
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
            new Schema { 
                SchemaId = 0, 
                Name = "HomePage", 
                Definition = "{\n\"fields\":[\n{\n\"name\":\"Title\",\n\"type\":\"text\"\n}\n]\n}" 
            }
        };

        public async Task<Schema> CreateSchemaAsync(Schema schema)
        {
            return await Task.Run(() =>
            {
                try
                {


                    Schema newSchema = new Schema()
                    {
                        SchemaId = schemas.Count,
                        Name = schema.Name,
                        Definition = null,
                        DraftDefinition = schema.DraftDefinition,
                        CreatedBy = "CreatedBy", // Update with logged in user
                        CreatedAt = DateTime.Now,
                        LastModified = DateTime.Now,
                        FirstPublished = null,
                        LastPublished = null,
                        ApplicationId = schema.ApplicationId,
                    };
                    schemas.Add(newSchema);

                    return newSchema;
                }
                catch
                {
                    return null;
                }
            });
        }

        public Task<bool> DeleteSchemaAsync(long schemaId)
        {

            return Task.Run(() => schemas.Remove(schemas.Find(s => s.SchemaId == schemaId)));
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

        public Task<bool> PublishSchemaAsync(long schemaId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateSchemaAsync(Schema schema)
        {
            throw new System.NotImplementedException();
        }
    }
}