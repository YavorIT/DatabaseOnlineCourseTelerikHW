namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Courses")]
    public class Course
    {
        private ICollection<Student> students;

        public Course()
        {
            this.students = new HashSet<Student>();
        }

        public int CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Materials { get; set; }

        [ForeignKey("Homework")]
        public int? HomeworkID { get; set; }

        public virtual Homework Homework { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
