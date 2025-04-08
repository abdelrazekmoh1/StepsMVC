using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StepsMVC.Models;

public partial class CrsResult
{
    public int Id { get; set; }

    public int Degree { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }

    [ForeignKey("Trainee")]
    public int TraineeId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Trainee Trainee { get; set; } = null!;
}
