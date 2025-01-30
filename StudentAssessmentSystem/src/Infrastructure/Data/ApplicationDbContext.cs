using Microsoft.EntityFrameworkCore;
using StudentAssessmentSystem.Domain.Entities;

namespace StudentAssessmentSystem.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    
    public DbSet<StudentData> StudentData { get; set; }
    
    public DbSet<TeacherData> TeacherData { get; set; }
    
    public DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            entity.Property(u => u.PasswordHash).IsRequired();
        });

        modelBuilder.Entity<StudentData>(entity =>
        {
            entity.ToTable("StudentData");
            entity.HasKey(sd => sd.Id);
            entity.HasIndex(sd => sd.UserId).IsUnique();
            entity.Property(sd => sd.GroupId).IsRequired();
            entity.HasOne(sd => sd.User)
                  .WithOne()
                  .HasForeignKey<StudentData>(sd => sd.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TeacherData>(entity =>
        {
            entity.ToTable("TeacherData");
            entity.HasKey(td => td.Id);
            entity.HasIndex(td => td.UserId).IsUnique();
            entity.HasOne(td => td.User)
                  .WithOne()
                  .HasForeignKey<TeacherData>(td => td.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(td => td.Classes)
                  .HasConversion(
                      v => string.Join(',', v),
                      v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                  )
                  .IsRequired();
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("Subjects");
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
        });
    }
}