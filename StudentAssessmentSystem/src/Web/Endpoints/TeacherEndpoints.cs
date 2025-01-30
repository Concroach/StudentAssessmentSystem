using StudentAssessmentSystem.Application.Interfaces;

public static class TeacherEndpoints
{
    public static void MapTeacherEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/teachers");

        group.MapPut("/{teacherId:guid}/subject/{subjectId:guid}", async (ITeacherService teacherService, Guid teacherId, Guid subjectId) =>
        {
            var result = await teacherService.AssignSubjectToTeacherAsync(teacherId, subjectId);
            return result ? Results.Ok() : Results.NotFound();
        });

        group.MapPost("/{studentId:guid}/grade/{subjectId:guid}/{grade:int}", async (ITeacherService teacherService, Guid studentId, Guid subjectId, int grade) =>
        {
            var result = await teacherService.AssignGradeAsync(studentId, subjectId, grade);
            return result ? Results.Ok() : Results.NotFound();
        });

        group.MapPut("/{studentId:guid}/grade/{subjectId:guid}/{newGrade:int}", async (ITeacherService teacherService, Guid studentId, Guid subjectId, int newGrade) =>
        {
            var result = await teacherService.UpdateGradeAsync(studentId, subjectId, newGrade);
            return result ? Results.Ok() : Results.NotFound();
        });

        group.MapDelete("/{studentId:guid}/grade/{subjectId:guid}", async (ITeacherService teacherService, Guid studentId, Guid subjectId) =>
        {
            var result = await teacherService.RemoveGradeAsync(studentId, subjectId);
            return result ? Results.Ok() : Results.NotFound();
        });
    }
}