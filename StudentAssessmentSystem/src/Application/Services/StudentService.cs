using Microsoft.EntityFrameworkCore;
using StudentAssessmentSystem.Application.Interfaces;
using StudentAssessmentSystem.Domain.Entities;
using StudentAssessmentSystem.Infrastructure.Data;

namespace StudentAssessmentSystem.Application.Services;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StudentData?> GetStudentByIdAsync(Guid id)
    {
        return await _context.StudentData.FindAsync(id);
    }

    public async Task<IEnumerable<StudentData>> GetAllStudentsAsync()
    {
        return await _context.StudentData.ToListAsync();
    }

    public async Task<StudentData> CreateStudentAsync(StudentData student)
    {
        _context.StudentData.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<bool> DeleteStudentAsync(Guid id)
    {
        var student = await _context.StudentData.FindAsync(id);
        if (student == null) return false;

        _context.StudentData.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<Dictionary<Guid, int>> GetGradesAsync(Guid studentId)
    {
        var student = await _context.Users.Include(s => s.StudentData).FirstOrDefaultAsync(u => u.Id == studentId);
        return student?.StudentData?.Grades ?? new Dictionary<Guid, int>();
    }

    public async Task<bool> AssignToGroupAsync(Guid studentId, string groupName)
    {
        var student = await _context.Users.Include(s => s.StudentData).FirstOrDefaultAsync(u => u.Id == studentId);
        if (student == null || student.StudentData == null) return false;

        student.StudentData.Group = groupName;
        await _context.SaveChangesAsync();
        return true;
    }
}