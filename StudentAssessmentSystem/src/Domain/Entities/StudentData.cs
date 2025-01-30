namespace StudentAssessmentSystem.Domain.Entities;

public class StudentData
{
    public Guid Id { get; set; }
    
    public int UserId { get; set; }
    
    public string? GroupId { get; set; }

    public User User { get; set; }
}
