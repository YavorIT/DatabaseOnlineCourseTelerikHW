namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Students")]
    public class Student
    {
        private ICollection<Course> courses;

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public int StudentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Number { get; set; }

        [ForeignKey("Homework")]
        public int? HomeworkID { get; set; }

        public virtual Homework Homework { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
