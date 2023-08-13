using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmailNewsletter.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<EmailTopic> EmailTopics { get; set; } = new List<EmailTopic>();
    }
}
