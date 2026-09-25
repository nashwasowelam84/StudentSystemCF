namespace StudentSystemCF.DataAccess;

using Microsoft.EntityFrameworkCore;
using StudentSystemCF.Enum;

using StudentSystemCF.Models;

internal class ApplicationDbContext : DbContext
{
    //*************Table Representation****************************
   
   // public DbSet<Course> Courses { get; set; }
    public DbSet<Homework> Homeworks { get; set; }

    public DbSet<Resource> Resources { get; set; }
    public DbSet<Student> Students { get; set; }

    public DbSet<StudentCourse> StudentCourseTable { get; set; }

    //************End of Table Representation****************************

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StudentSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //***************Student********************* 
        modelBuilder.Entity<Student>()
            .Property(e => e.Name)
            .IsUnicode(true)
            .HasMaxLength(100);

        modelBuilder.Entity<Student>()
            .Property(e => e.PhoneNumber)
            .IsUnicode(false)
            .HasMaxLength(10);

     

        //***************Course********************* 
        modelBuilder.Entity<Course>()
            .Property(e => e.Name)
            .IsUnicode(true)
            .HasMaxLength(80);

        modelBuilder.Entity<Course>()
            .Property(e => e.Description)
            .IsUnicode(true);

        //********************Resource*********************

        //make Name column as unicode and has maxlength of 50
        modelBuilder.Entity<Resource>()
            .Property(e => e.Name)
            .IsUnicode(true)
            .HasMaxLength(50);
        //url inot a unicode
        modelBuilder.Entity<Resource>()
            .Property(e => e.Url)
            .IsUnicode(false);
        // foreingn Key Relation

        //*******************Homework********************
        modelBuilder.Entity<Homework>()
            .Property(e => e.Content)
            .IsUnicode(false)
            .HasMaxLength(1000);

        //Student-course table 

        modelBuilder.Entity<Student>()
    .HasMany(e => e.Courses)
    .WithMany(e => e.Students)
    .UsingEntity<StudentCourse>(
        e => e
            .HasOne(e => e.Course)
            .WithMany()
            .HasForeignKey(e => e.CourseID),

        e => e
            .HasOne(e => e.Student)
            .WithMany()
            .HasForeignKey(e => e.StudentId),

        e =>
        {
            e.HasKey(e => new { e.StudentId, e.CourseID });
        });


        //Relations

        //One course can have many Resources

        modelBuilder.Entity<Resource>()
             .HasOne(e => e.course)
             .WithMany(e => e.Resources)
             .HasForeignKey(e => e.CourseId);


        //*******************homework-student relation************
        modelBuilder.Entity<Homework>()
      .HasOne(e => e.students)
      .WithMany(e => e.HomeworkSubmission)
      .HasForeignKey(e => e.StudentId);

        // One course can have many HomeworkSubmissions
        modelBuilder.Entity<Homework>()
             .HasOne(e => e.courses)
             .WithMany(e => e.HomeworkSubmission)
             .HasForeignKey(e => e.CourseID);

        //One student can have many CourseEnrollments

       
    }

}

