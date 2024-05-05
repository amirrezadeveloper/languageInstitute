

using languageInstitute.Application.Dtos;

namespace languageInstitute.Application.Contracts;

public interface IAuthenticationService
{
    Task<AuthenticationResponseDto> Login(LoginDto dto);
    Task<AuthenticationResponseDto> Register(RegisterDto dto);
}
