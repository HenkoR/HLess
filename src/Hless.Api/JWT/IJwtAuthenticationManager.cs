using Hless.Api.Models.Dto;

namespace Hless.Api.JWT
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(UserDto user);
    }
}
