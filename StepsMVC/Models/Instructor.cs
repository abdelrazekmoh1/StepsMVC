using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StepsMVC.Models;

public partial class Instructor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public int Salary { get; set; }

    public string? Address { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    [ForeignKey("Course")]
    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;
}
