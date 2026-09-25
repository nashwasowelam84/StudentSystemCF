using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystemCF.Models;

internal class StudentCourse
{

    public int StudentId { get; set; }
    public int CourseID { get; set; }

    public Student Student { get; set; } = new Student();
    public Course Course { get; set; } = new Course();
}
