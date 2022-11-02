using System.ComponentModel.DataAnnotations;

namespace DateTimeOnly
{
    public class ClassWithStructs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TimeOnly Time { get; set; }

    }
}