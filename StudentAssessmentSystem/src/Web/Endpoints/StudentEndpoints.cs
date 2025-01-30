using StudentAssessmentSystem.Application.Interfaces;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/students");

        group.MapGet("/{studentId:guid}/grades", async (IStudentService studentService, Guid studentId) =>
        {
            var grades = await studentService.GetGradesAsync(studentId);
            return Results.Ok(grades);
        });

        group.MapPut("/{studentId:guid}/group/{groupName}", async (IStudentService studentService, Guid studentId, string groupName) =>
        {
            var result = await studentService.AssignToGroupAsync(studentId, groupName);
            return result ? Results.Ok() : Results.NotFound();
        });
    }
}