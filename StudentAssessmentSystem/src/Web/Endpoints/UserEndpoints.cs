using StudentAssessmentSystem.Application.Interfaces;
using StudentAssessmentSystem.Domain.Entities;
using StudentAssessmentSystem.Domain.Enums;

namespace StudentAssessmentSystem.Web.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/users");

        group.MapPost("/", async (IAdminService adminService, User user) =>
        {
            var createdUser = await adminService.CreateUserAsync(user);
            return Results.Ok(createdUser);
        });

        group.MapDelete("/{id:guid}", async (IAdminService adminService, Guid id) =>
        {
            var result = await adminService.DeleteUserAsync(id);
            return result ? Results.Ok() : Results.NotFound();
        });

        group.MapPut("/{id:guid}/role/{role}", async (IAdminService adminService, Guid id, Roles role) =>
        {
            var result = await adminService.AssignRoleAsync(id, role);
            return result ? Results.Ok() : Results.NotFound();
        });
    }
}