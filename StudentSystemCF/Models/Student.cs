using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystemCF.Models;

internal class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public DateOnly RegisteredOn { get; set; }

    public DateOnly? BirthDay { get; set; }

    public List<Course> Courses { get; set; } = new List<Course>();

    public List<Homework> HomeworkSubmission { get; set; } = new List<Homework>();
}
