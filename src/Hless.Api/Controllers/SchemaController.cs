using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hless.Api.Extensions.Models;
using Hless.Api.Models.Dto;
using Hless.Common.Repositories;
using Hless.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hless.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class SchemaController : BaseController
    {
        readonly ISchemaRepository _repository;
        public SchemaController(ISchemaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<SchemaDto>> GetSchemasAsync()
        {
            var schemas = (await _repository.GetSchemasAsync())
                .Select(schema => schema.AsDto());
            return schemas;
        }
        [HttpGet]
        public async Task<Schema> GetSchemaAsync(long schemaId)
        {
            return await _repository.GetSchemaAsync(schemaId);
        }
        [HttpPost]
        public async Task<Schema> CreateSchemaAsync(SchemaCreateDto schema)
        {
            Schema newSchema = new Schema()
            {
                Name = schema.Name,
                DraftDefinition = schema.DraftDefinition,
                ApplicationId = schema.ApplicationId,
            };

            return await _repository.CreateSchemaAsync(newSchema);
        }
        [HttpPut]
        public async Task<bool> UpdateSchemaAsync([FromBody] Schema schema)
        {
            return await _repository.UpdateSchemaAsync(schema);
        }
        [HttpGet]
        public async Task<bool> PublishSchemaAsync(long schemaId)
        {
            return await _repository.PublishSchemaAsync(schemaId);
        }
        [HttpDelete]
        public async Task<bool> DeleteSchemaAsync(long schemaId)
        {
            return await _repository.DeleteSchemaAsync(schemaId);
        }
        [HttpGet]
        public async Task<Schema> Test([FromBody] Schema schema)
        {
            return await Task.FromResult(schema);
        }
    }
}