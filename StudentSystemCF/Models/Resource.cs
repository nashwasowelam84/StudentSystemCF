using StudentSystemCF.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystemCF.Models;

internal class Resource
{

    public int ResourceId { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public ResourceTypeNames ResourceType { get; set; }

    public int CourseId { get; set; }

    public Course course { get; set; } = new Course();
}
