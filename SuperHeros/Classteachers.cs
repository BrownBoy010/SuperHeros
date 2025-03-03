using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SuperHeros
{
    public class Classteachers
    {
        [Key]
        public int TeacherId { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public ICollection<Student> students { get; set; }
    }
}
