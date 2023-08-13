using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmailNewsletter.Models
{
    public class EmailTopic
    {
        public int EmailId { get; set; }
        public int TopicId { get; set; }
        public virtual Email Email { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
    }
}
