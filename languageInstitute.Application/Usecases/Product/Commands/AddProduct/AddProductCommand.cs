#nullable disable

using languageInstitute.Application.Wrappers;
using MediatR;

namespace languageInstitute.Application.Usecases.Product.Commands;

    public class AddProductCommand: IRequest<Response<int>>
    {
        public string Name { get; set; }    
        public decimal Price { get; set; }
    }

