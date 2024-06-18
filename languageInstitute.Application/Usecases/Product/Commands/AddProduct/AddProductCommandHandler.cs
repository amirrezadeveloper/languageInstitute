
using AutoMapper;
using languageInstitute.Application.Contracts;
using languageInstitute.Application.Wrappers;
using MediatR;

namespace languageInstitute.Application.Usecases.Product.Commands;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Response<int>>
{
    private readonly IClasstService _studentService;
    private readonly IMapper _mapper;   

    public AddProductCommandHandler (IClasstService studentService, IMapper mapper)
    {
        _studentService = studentService;   
        _mapper = mapper;   
    }

    public async Task<Response<int>> Handle(AddProductCommand request, CancellationToken ct)
    {
        var student = _mapper.Map<languageInstitute.Domain.Entities.Student>(request);
        await _studentService.AddStudent(student);
        return new Response<int>();
        
    }
}
