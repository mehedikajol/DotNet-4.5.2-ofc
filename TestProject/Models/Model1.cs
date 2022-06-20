using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TestProject.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<SubjectDet> SubjectDets { get; set; }
        public virtual DbSet<SubjectMa> SubjectMas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.DeptName)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.DeptId);

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.IdNo)
                .IsUnicode(false);

            modelBuilder.Entity<SubjectDet>()
                .Property(e => e.SubjectName)
                .IsUnicode(false);

            modelBuilder.Entity<SubjectMa>()
                .HasMany(e => e.SubjectDets)
                .WithOptional(e => e.SubjectMa)
                .HasForeignKey(e => e.SubjectMasId);
        }
    }
}
