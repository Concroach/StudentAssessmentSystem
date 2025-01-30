namespace StudentAssessmentSystem.Domain.Entities;

public class TeacherData
{
    public Guid Id { get; set; }
    
    public int UserId { get; set; }
    
    public List<Subject>? Subjects { get; set; }
    
    public List<string>? Classes { get; set; }

    public User User { get; set; }
}
