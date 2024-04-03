using languageInstitute.Contract;
using languageInstitute.Models;
using Microsoft.AspNetCore.Mvc;

namespace languageInstitute.Controllers.V1;

public class StudentController : BaseController
{
    private readonly IStudentBusiness _studentBusiness;
   
    public StudentController(IStudentBusiness studentBusiness)
    {
        _studentBusiness = studentBusiness;
    }

    [Route("{NationalCode}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] string NationalCode)
    {
        Student student = _studentBusiness.GetStudentByNationalCode(NationalCode);

        if (student is null)
            return NotFound();

        return Ok(student);
    }
}

