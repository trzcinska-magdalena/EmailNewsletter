using System.ComponentModel.DataAnnotations;

namespace EmailNewsletter.Models
{
    public class Topic
    {
        [Required]
        [Range(0, int.MaxValue)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        virtual public ICollection<EmailTopic> EmailTopic { get; set; } = new List<EmailTopic>();
    }
}
