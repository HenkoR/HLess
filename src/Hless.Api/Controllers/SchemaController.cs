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
    [Route("[controller]")]
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
    }
}