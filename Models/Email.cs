using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmailNewsletter.Models
{
    public class Email
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        virtual public ICollection<EmailTopic> EmailTopic { get; set; } = new List<EmailTopic>();
    }
}
