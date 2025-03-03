using System.ComponentModel.DataAnnotations;

namespace SuperHeros
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Class { get; set; }


        [Display(Name = "Class Teacher ID")]
        public int TeacherId { get; set; }

    }
}
