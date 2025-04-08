using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StepsMVC.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Degree { get; set; }

    public int MinDegree { get; set; }

    public int Houres { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }

    public virtual ICollection<CrsResult> CrsResults { get; set; } = new List<CrsResult>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
