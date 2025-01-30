namespace StudentAssessmentSystem.Domain.Entities;

public class Subject
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public List<TeacherData>? Teachers { get; set; }
}


