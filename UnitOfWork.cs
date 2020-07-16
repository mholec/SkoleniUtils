using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Holec.SkoleniUtils
{
    public class UnitOfWork : DbContext
    {
        public UnitOfWork()
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Student> Students { get; private set; }
        public DbSet<Course> Courses { get; private set; }
        public DbSet<Enrollment> Ennrollments { get; private set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=database.db");
            }

            // zapnu lazy aby nebyly problemy na non-EF kurzech
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany(x => x.Enrollments).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
            modelBuilder.Entity<Course>().HasMany(x => x.Enrollments).WithOne(x => x.Course).HasForeignKey(x => x.CourseId);
           
            modelBuilder.Entity<Student>().ToTable("Students").HasKey(x => x.Id);
            modelBuilder.Entity<Student>().Property(x => x.Id).ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Course>().ToTable("Courses").HasKey(x => x.Id);
            modelBuilder.Entity<Course>().Property(x => x.Id).ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments").HasKey(x => x.Id);
            modelBuilder.Entity<Enrollment>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>().OwnsOne(x => x.Name);
            modelBuilder.Entity<Course>().Property(x => x.Title).IsRequired().HasMaxLength(200);
        }

        public void Seed()
        {
            if(!Ennrollments.Any())
            {
                var c1 = new Course() {Title = "Vývoj aplikací v ASP.NET Core", Price = 7900, Date = DateTime.Now.AddDays(20)};
                var c2 = new Course() {Title = "Vývoj REST API v .NET Core", Price = 6900, Date = DateTime.Now.AddDays(21)};
                var c3 = new Course() {Title = "Tipy a triky v ASP.NET Core", Price = 5900, Date = DateTime.Now.AddDays(22)};
                var c4 = new Course() {Title = "Microservices v ASP.NET Core gRPC", Price = 8900, Date = DateTime.Now.AddDays(23)};
                
                var s1 = new Student() {Name = new Name() {Firstname = "Jan", Lastname = "Chytrý"}, RegistrationDate = DateTime.Now.AddSeconds(-908967)};
                var s2 = new Student() {Name = new Name() {Firstname = "Josefína", Lastname = "Moudrá"}, RegistrationDate = DateTime.Now.AddSeconds(-456710)};
                var s3 = new Student() {Name = new Name() {Firstname = "John", Lastname = "Doe"}, RegistrationDate = DateTime.Now.AddSeconds(-12293)};
                var s4 = new Student() {Name = new Name() {Firstname = "Martin", Lastname = "Inkvizitor"},  RegistrationDate = DateTime.Now.AddSeconds(-12293)};

                Ennrollments.Add(new Enrollment(){Course = c1, Student = s1, });
                Ennrollments.Add(new Enrollment(){Course = c1, Student = s2, });
                Ennrollments.Add(new Enrollment(){Course = c1, Student = s3, });
                Ennrollments.Add(new Enrollment(){Course = c2, Student = s1, });
                Ennrollments.Add(new Enrollment(){Course = c2, Student = s3, });
                Ennrollments.Add(new Enrollment(){Course = c2, Student = s4, });
                Ennrollments.Add(new Enrollment(){Course = c3, Student = s1, });
                Ennrollments.Add(new Enrollment(){Course = c4, Student = s2, });
                Ennrollments.Add(new Enrollment(){Course = c4, Student = s3, });
                Ennrollments.Add(new Enrollment(){Course = c4, Student = s4, });

                SaveChanges();
            }
        }
    }
}