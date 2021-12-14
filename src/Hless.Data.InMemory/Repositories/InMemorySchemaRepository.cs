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
                SchemaId = 1, 
                Name = "Users", 
                DraftDefinition = new Dictionary<string, string> {
                    { "Id", "number" },
                    { "Title", "text" },
                    { "Firstname", "text" },
                    { "Surname", "text" }
                },
                CreatedBy = "Admin",
                CreatedAt = DateTime.Now,
            },
            new Schema
            {
                SchemaId = 2,
                Name = "Car",
                DraftDefinition = new Dictionary<string, string> {
                    { "Id", "number" },
                    { "UsersId", "number" },
                    { "Name", "text" },
                    { "Licence", "text" }
                },
                CreatedBy = "Admin",
                CreatedAt = DateTime.Now,
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
                        SchemaId = schemas.Count + 1,
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
            var schema = schemas.Find(schema => schema.SchemaId == schemaId);
            return await Task.FromResult(schema);
        }

        public async Task<IEnumerable<Schema>> GetSchemasAsync()
        {
            return await Task.FromResult(schemas);
        }

        public Task<bool> PublishSchemaAsync(long schemaId)
        {
            return Task.Run(() => {
                try
                {
                    int i = schemas.IndexOf(schemas.Find(s => s.SchemaId == schemaId));

                    if (i == -1)
                        return false;

                    schemas[i].Definition = schemas[i].DraftDefinition;
                    schemas[i].LastPublished = DateTime.Now;

                    if (schemas[i].FirstPublished == null)
                        schemas[i].FirstPublished = schemas[i].LastPublished;

                    return true;
                }
                catch { return false; }
            });
        }

        public Task<bool> UpdateSchemaAsync(Schema schema)
        {
            return Task.Run(() =>
            {
                try
                {
                    if(schema.SchemaId == 0)
                        return false;

                    int i = schemas.IndexOf(schemas.Find(s => s.SchemaId == schema.SchemaId));

                    if (i == -1)
                        return false;

                    if(schema.Name != null)
                        schemas[i].Name = schema.Name;

                    if(schema.DraftDefinition != null)
                    schemas[i].DraftDefinition = schema.DraftDefinition;

                    if(schema.ApplicationId != 0)
                    schemas[i].ApplicationId = schema.ApplicationId;

                    schemas[i].LastModified = DateTime.Now;

                    return true;
                }
                catch { return false; }
            });
        }
    }
}