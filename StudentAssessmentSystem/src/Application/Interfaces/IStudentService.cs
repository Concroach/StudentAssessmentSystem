using StudentAssessmentSystem.Domain.Entities;

namespace StudentAssessmentSystem.Application.Interfaces;

public interface IStudentService
{
    Task<StudentData?> GetStudentByIdAsync(Guid id);
    
    Task<IEnumerable<StudentData>> GetAllStudentsAsync();
    
    Task<StudentData> CreateStudentAsync(StudentData student);
    
    Task<bool> DeleteStudentAsync(Guid id);
    
    Task<Dictionary<Guid, int>> GetGradesAsync(Guid studentId);

    Task<bool> AssignToGroupAsync(Guid studentId, string groupName);
}
