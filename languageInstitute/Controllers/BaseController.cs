using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace languageInstitute.Controllers;

[Route("api/V{version:apiversion}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]  

public class BaseController : ControllerBase
{
    
}
