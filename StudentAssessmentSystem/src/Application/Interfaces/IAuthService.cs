using StudentAssessmentSystem.Domain.Entities;

namespace StudentAssessmentSystem.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponse?> AuthenticateAsync(AuthRequest request);
}