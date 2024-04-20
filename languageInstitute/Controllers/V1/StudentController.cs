using AutoMapper;
using languageInstitute.Application.Contracts;
using languageInstitute.Application.Dtos;
using languageInstitute.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace languageInstitute.Controllers.V1;

public class StudentController : BaseController
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
   
    public StudentController(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Student student = await _studentService.GetStudentById(id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Student> students = await _studentService.GetStudents();
        if (students is null) return NotFound();    
        return Ok(students);    
    }

    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddStudentDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        student.CreateAt = DateTime.Now;
        await _studentService.AddStudent(student);

        return CreatedAtAction(nameof(Get), new { student.NationalCode}, student);
    }


    [HttpPut("{id}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatedStudentDto updatedStudentDto)
    {
        var updateSuccess = await _studentService.UpdateStudent(id, updatedStudentDto);
        if (!updateSuccess)
            return NotFound();
        return Ok();
    }


}

