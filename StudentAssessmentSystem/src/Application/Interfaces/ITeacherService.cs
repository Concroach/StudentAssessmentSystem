namespace StudentAssessmentSystem.Application.Interfaces;

public interface ITeacherService
{
    Task<bool> AssignSubjectToTeacherAsync(Guid teacherId, Guid subjectId);

    Task<bool> AssignGradeAsync(Guid studentId, Guid subjectId, int grade);
    
    Task<bool> UpdateGradeAsync(Guid studentId, Guid subjectId, int newGrade);
    
    Task<bool> RemoveGradeAsync(Guid studentId, Guid subjectId);
}