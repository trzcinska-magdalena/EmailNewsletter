using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmailNewsletter.Models
{
    public class Email
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; } = null!;
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;
        public virtual ICollection<EmailTopic> EmailTopics { get; set; } = new List<EmailTopic>();
    }
}
