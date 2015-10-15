namespace Startup
{
    using System;
    using Models;
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    class Startup
    {
        static void Main()
        {
             Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            using (var db = new StudentSystemContext())
            {
                var student = new Student { Name = "Ivan Bojinov", Number = "987654321" };

                db.Students.Add(student);

                var course = new Course { Name = "C# Intermediate", Description = "Writing more advanced programs in C#" };

                db.Courses.Add(course);

                db.SaveChanges();
            }

            Console.WriteLine("Saved!");
        }
    }
}
