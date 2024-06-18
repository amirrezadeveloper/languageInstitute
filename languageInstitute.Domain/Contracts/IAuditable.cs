namespace languageInstitute.Domain.Contracts;

public interface IAuditable
{
    public int EditedByUserId { get; set; }
    public DateTime UpdateAt { get; set; }
}
