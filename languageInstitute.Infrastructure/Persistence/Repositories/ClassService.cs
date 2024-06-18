using languageInstitute.Application.Contracts;
using languageInstitute.Application.Dtos;
using languageInstitute.Application.Wrappers;
using languageInstitute.Domain.Contracts;
using languageInstitute.Domain.Entities;
using languageInstitute.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;



namespace languageInstitute.Infrastructure.Persistence.Repositories;

public class ClassService : GenericRepository<Class>, IClasstService
{
    protected ClassService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
