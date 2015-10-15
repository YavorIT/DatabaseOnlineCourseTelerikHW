namespace Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<Data.StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Data.StudentSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Students.AddOrUpdate(st => st.Name, new Student { Name = "Ivan Ivanov", Number = "123456789" } );
            context.Courses.AddOrUpdate(c => c.Name, new Course {Name = "C# fundamentals", Description = "Writing basic programs in C#"});
        }
    }
}
