namespace Hless.Api.Models.Dto
{
    public record UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
