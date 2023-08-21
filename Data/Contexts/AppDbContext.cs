using Domain.Entities;
using Domain.Entitiesl;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = OLMSystem; Trusted_Connection = True;");
    //}

    DbSet<User> Users { get; set; }
    DbSet<Assigment> Assigments { get; set; }
    DbSet<Course> Courses { get; set; }
    DbSet<Enrollment> Enrollments { get; set; }
    DbSet<Lesson> Lessons { get; set; }
    DbSet<Quiz> Quizs { get; set; } 
    DbSet<QuizQuestion> QuizQuestions { get; set; }
    DbSet<Submission> Submissions { get; set; }
    
}
