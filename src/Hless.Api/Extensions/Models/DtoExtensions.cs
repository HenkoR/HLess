using Hless.Api.Models.Dto;
using Hless.Data.Models;

namespace Hless.Api.Extensions.Models
{
    public static class DtoExtensions
    {
        public static SchemaDto AsDto(this Schema schema)
        {
            return new SchemaDto 
            {
                CreatedBy = schema.CreatedBy,
                Definition = schema.Definition,
                DraftDefinition = schema.DraftDefinition,
                Name = schema.Name,
                SchemaId = schema.SchemaId
            };
        }
    }
}