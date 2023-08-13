namespace EmailNewsletter.Models
{
    public class EmailTopic
    {
        public int EmailId { get; set; }
        public int TopicId { get; set; }
        virtual public Email Email { get; set; } = null!;
        virtual public Topic Topic { get; set; } = null!;
    }
}
