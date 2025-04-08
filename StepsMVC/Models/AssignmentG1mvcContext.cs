using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StepsMVC.Models;

public partial class AssignmentG1mvcContext : DbContext
{
    public AssignmentG1mvcContext()
    {
    }

    public AssignmentG1mvcContext(DbContextOptions<AssignmentG1mvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CrsResult> CrsResults { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Trainee> Trainees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AssignmentG1MVC;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.HasIndex(e => e.DepartmentId, "IX_Course_DepartmentId");

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<CrsResult>(entity =>
        {
            entity.ToTable("crsResult");

            entity.HasIndex(e => e.CourseId, "IX_crsResult_CourseId");

            entity.HasIndex(e => e.TraineeId, "IX_crsResult_TraineeId");

            entity.HasOne(d => d.Course).WithMany(p => p.CrsResults)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Trainee).WithMany(p => p.CrsResults)
                .HasForeignKey(d => d.TraineeId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.ToTable("Instructor");

            entity.HasIndex(e => e.CourseId, "IX_Instructor_CourseId");

            entity.HasIndex(e => e.DepartmentId, "IX_Instructor_DepartmentId");

            entity.HasOne(d => d.Course).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Department).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.ToTable("Trainee");

            entity.HasIndex(e => e.DepartmentId, "IX_Trainee_DepartmentId");

            entity.HasOne(d => d.Department).WithMany(p => p.Trainees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
