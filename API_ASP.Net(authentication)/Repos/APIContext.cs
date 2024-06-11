using System;
using System.Collections.Generic;
using API_ASP.Net_authentication_.Repos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ASP.Net_authentication_.Repos;

public partial class APIContext : DbContext
{
    public APIContext()
    {
    }

    public APIContext(DbContextOptions<APIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__EMPLOYEE__AF2DBB99366AF1E3");

            entity.Property(e => e.EmpId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__test__A25C5AA664C993E1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
