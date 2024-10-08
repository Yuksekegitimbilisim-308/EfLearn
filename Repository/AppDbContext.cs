using EfLearn.Entities;
using System.Data.Entity;

namespace EfLearn.Repository
{
    public class AppDbContext : DbContext
    {
        //"Server = DESKTOP-OBCSS28;Database=CourseAppDb; Trusted Connection = true;"
        public AppDbContext() :base("Server = DESKTOP-OBCSS28;Database=CourseAppDb ;User Id =sa;Password =1234;")
        {}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                .Property(x => x.Id)
                .HasColumnName("Id");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Grade> Grades{ get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<User> Users{ get; set; }

    }
}
