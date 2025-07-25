using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreMasterDetailsCRUD.Models;

public partial class CoreMasterDetailsDbContext : DbContext
{
    public CoreMasterDetailsDbContext()
    {
    }

    public CoreMasterDetailsDbContext(DbContextOptions<CoreMasterDetailsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=CoreMasterDetailsDB;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D71A734DF3AB2");

            entity.Property(e => e.CourseName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Modules__2B7477A76AD476A2");

            entity.Property(e => e.ModuleName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Modules)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Modules__Student__29572725");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B99E53E3157");

            entity.Property(e => e.AdmissionDate).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StudentName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Students__Course__267ABA7A");
        });
        modelBuilder.Seed();
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
