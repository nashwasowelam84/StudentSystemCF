using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystemCF.Models;

internal class Course
{
    public int CourseID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public decimal Price { get; set; }

    public List<Resource> Resources { get; set; } = new List<Resource>();

    public List<Student> Students { get; set; } = new List<Student>();

    public List<Homework> HomeworkSubmission { get; set; } = new List<Homework>();
}
