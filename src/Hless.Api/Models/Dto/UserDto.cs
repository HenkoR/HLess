using Hless.Data.Models;

namespace Hless.Api.Models.Dto
{
    public record UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Admin { get; set; }
    }

    public record UpdateUserDto
    {
        public long userId { get; init; }
        public User user { get; init; }
    }
}
