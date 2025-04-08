using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StepsMVC.Models;

public partial class Trainee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public string? Address { get; set; }

    public int Grade { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }

    public virtual ICollection<CrsResult> CrsResults { get; set; } = new List<CrsResult>();

    public virtual Department Department { get; set; } = null!;
}
