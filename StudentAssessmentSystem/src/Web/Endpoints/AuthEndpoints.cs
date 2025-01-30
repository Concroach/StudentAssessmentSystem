using StudentAssessmentSystem.Application.Interfaces;
using StudentAssessmentSystem.Domain.Entities;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/auth");

        group.MapPost("/login", async (IAuthService authService, AuthRequest request) =>
        {
            var response = await authService.AuthenticateAsync(request);
            return response != null ? Results.Ok(response) : Results.Unauthorized();
        });
    }
}