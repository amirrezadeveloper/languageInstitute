using languageInstitute.Application.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace languageInstitute.Controllers.V1;

public class AuthenticationController : BaseController
{
    [Route("Login")]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken ct)
    {
        return Ok(dto);

    }

    [Route("Register")]
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Register([FromBody] RegisterDto dto, CancellationToken ct)
    {
        return Created();
    }
}
