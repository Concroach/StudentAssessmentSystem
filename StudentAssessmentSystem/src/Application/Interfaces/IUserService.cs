using StudentAssessmentSystem.Domain.Entities;

namespace StudentAssessmentSystem.Application.Interfaces;

public interface IUserService
{
    Task<User?> GetUserByIdAsync(Guid id);

    Task<IEnumerable<User>> GetAllUsersAsync();

    Task<User> CreateUserAsync(User user);

    Task<bool> DeleteUserAsync(Guid id);
}