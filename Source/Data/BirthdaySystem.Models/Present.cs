namespace BirthdaySystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Present
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
