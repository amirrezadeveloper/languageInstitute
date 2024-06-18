
using languageInstitute.Domain.Contracts;


namespace languageInstitute.Infrastructure.Identity.Entities;

public class Users: BaseEntity<int>
{
    public string NationalCode {  get; set; }   
    public string FirstName { get; set; }   
    public string LastName { get; set; }    
    public string Address {  get; set; }    
    public string Mobile {  get; set; }    
    public string TellPhone { get; set; }
    public string FathersName { get; set; }  
    public string FathersPhone { get; set; }
    public string FathersJob { get; set; }   
    public string MothersName { get; set; } 
    public string MothersPhone { get; set; }
    public string MothersJob {  get; set; } 
    public string BirthDate { get; set; }  
}
 