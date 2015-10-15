namespace Data
{
    using System.Data.Entity;
    using Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() : base("StudentSystemDB")
        {
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                                        .HasMany<Course>(co => co.Courses)
                                        .WithMany(st => st.Students)
                                        .Map(cs =>
                                        {
                                            cs.MapLeftKey("StudentID");
                                            cs.MapRightKey("CourseID");
                                            cs.ToTable("Student_Courses");
                                        });

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
