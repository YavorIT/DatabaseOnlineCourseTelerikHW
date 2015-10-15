namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Homeworks")]
    public class Homework
    {
        private ICollection<Student> students;
        private ICollection<Course> courses;

        public Homework()
        {
            this.students = new HashSet<Student>();
            this.courses = new HashSet<Course>();
        }
        public int HomeworkID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime TimeSent { get; set; }


        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
