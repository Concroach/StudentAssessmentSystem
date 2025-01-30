using Microsoft.EntityFrameworkCore;
using StudentAssessmentSystem.Application.Interfaces;
using StudentAssessmentSystem.Domain.Entities;
using StudentAssessmentSystem.Domain.Enums;
using StudentAssessmentSystem.Infrastructure.Data;

namespace StudentAssessmentSystem.Application.Services;

public class AdminService : IAdminService
{
    private readonly ApplicationDbContext _context;

    public AdminService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AssignRoleAsync(Guid userId, Roles role)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) return false;

        user.Role = role;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Subject> CreateSubjectAsync(Subject subject)
    {
        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();
        return subject;
    }

    public async Task<bool> AssignTeacherToClassAsync(Guid teacherId, string className)
    {
        var teacher = await _context.Users.Include(t => t.TeacherData).FirstOrDefaultAsync(u => u.Id == teacherId);
        if (teacher == null || teacher.TeacherData == null) return false;

        teacher.TeacherData.Classes.Add(className);
        await _context.SaveChangesAsync();
        return true;
    }
}