using EmailNewsletter.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailNewsletter.Data
{
    public interface ITopicService
    {
        Task<ICollection<Topic>> GetTopicsAsync();
        Task<int> GetCountTopicsAsync();
        Task AddNewTopic(Topic topic);
        Task RemoveTopic(Topic topic);
    }

    public class TopicService : ITopicService
    {
        private readonly NewsletterContext _newsletterContext;

        public TopicService(NewsletterContext newsletterContext)
        {
            _newsletterContext = newsletterContext;
        }

        public async Task<ICollection<Topic>> GetTopicsAsync()
        {
            return await _newsletterContext.Topics.ToListAsync();
        }

        public async Task<int> GetCountTopicsAsync()
        {
            return await _newsletterContext.Topics.CountAsync();
        }

        public async Task AddNewTopic(Topic topic)
        {
            _newsletterContext.Topics.Add(topic);
            await _newsletterContext.SaveChangesAsync();
        }

        public async Task RemoveTopic(Topic topic)
        {
            _newsletterContext.Topics.Remove(topic);
            await _newsletterContext.SaveChangesAsync();
        }
    }
}
