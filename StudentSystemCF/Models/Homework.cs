using StudentSystemCF.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystemCF.Models;

internal class Homework
{
    public int HomeworkId { get; set; }
    public String Content { get; set; } = String.Empty;
    public ContentTypeNames ContentTypeNames { get; set; }
    public DateTime Submission { get; set; }

    public int CourseID { get; set; }

    public int StudentId { get; set; }

    public Student students { get; set; } = new Student();

    public Course courses { get; set; } = new Course();
}

