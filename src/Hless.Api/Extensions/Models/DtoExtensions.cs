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
        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.id,
                UserName = user.Username,
                Password = user.Password,
                EmailAddress = user.EmailAddress,
                Admin = user.admin,
            };
        }
    }
}