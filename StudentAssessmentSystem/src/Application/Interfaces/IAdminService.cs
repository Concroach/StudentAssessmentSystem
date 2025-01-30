using StudentAssessmentSystem.Domain.Entities;
using StudentAssessmentSystem.Domain.Enums;

namespace StudentAssessmentSystem.Application.Interfaces;

public interface IAdminService
{
    Task<User> CreateUserAsync(User user);
    
    Task<bool> DeleteUserAsync(Guid id);
    
    Task<bool> AssignRoleAsync(Guid userId, Roles role);
    
    Task<Subject> CreateSubjectAsync(Subject subject);
    
    Task<bool> AssignTeacherToClassAsync(Guid teacherId, string className);
}