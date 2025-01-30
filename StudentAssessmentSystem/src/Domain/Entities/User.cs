using StudentAssessmentSystem.Domain.Enums;

namespace StudentAssessmentSystem.Domain.Entities;

public class User
{
    public int Id { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Email { get; set; }
    
    public string? PasswordHash { get; set; }
    
    public Roles Role { get; set; }
}