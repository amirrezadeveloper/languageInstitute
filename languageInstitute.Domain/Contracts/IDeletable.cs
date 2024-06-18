
namespace languageInstitute.Domain.Contracts;

public interface IDeletable
{
    public int DeletedByUserId { get; set; }
    public DateTime DeletedAt { get; set; }
}

