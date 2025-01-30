using Microsoft.EntityFrameworkCore;
using StudentAssessmentSystem.Application.Interfaces;
using StudentAssessmentSystem.Infrastructure.Data;

namespace StudentAssessmentSystem.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly ApplicationDbContext _context;

    public TeacherService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AssignSubjectToTeacherAsync(Guid teacherId, Guid subjectId)
    {
        var teacher = await _context.Users.Include(t => t.TeacherData).FirstOrDefaultAsync(u => u.Id == teacherId);
        var subject = await _context.Subjects.FindAsync(subjectId);

        if (teacher == null || subject == null || teacher.TeacherData == null) return false;

        teacher.TeacherData.Subjects.Add(subject);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AssignGradeAsync(Guid studentId, Guid subjectId, int grade)
    {
        var student = await _context.Users.Include(s => s.StudentData).FirstOrDefaultAsync(u => u.Id == studentId);
        if (student == null || student.StudentData == null) return false;

        student.StudentData.Grades[subjectId] = grade;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateGradeAsync(Guid studentId, Guid subjectId, int newGrade)
    {
        var student = await _context.Users.Include(s => s.StudentData).FirstOrDefaultAsync(u => u.Id == studentId);
        if (student == null || student.StudentData == null) return false;

        if (!student.StudentData.Grades.ContainsKey(subjectId)) return false;

        student.StudentData.Grades[subjectId] = newGrade;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveGradeAsync(Guid studentId, Guid subjectId)
    {
        var student = await _context.Users.Include(s => s.StudentData).FirstOrDefaultAsync(u => u.Id == studentId);
        if (student == null || student.StudentData == null) return false;

        if (!student.StudentData.Grades.ContainsKey(subjectId)) return false;

        student.StudentData.Grades.Remove(subjectId);
        await _context.SaveChangesAsync();
        return true;
    }
}