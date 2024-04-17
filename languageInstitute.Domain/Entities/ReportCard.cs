using languageInstitute.Domain.Contracts;
namespace languageInstitute.Domain.Entities;

public class ReportCard : BaseEntity<int>
{

    public int ReadingGrade { get; set; }
    public int WritingGrade { get; set; }
    public int ListeningGrade { get; set; }
    public int SpeakingGrade { get; set; }
}
