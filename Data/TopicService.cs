using EmailNewsletter.Models;
using EmailNewsletter.Pages;
using Microsoft.EntityFrameworkCore;

namespace EmailNewsletter.Data
{
    public interface ITopicService
    {
        Task<IDictionary<Topic, int>> GetTopicsWithAmountOfEmial();
        Task<int> GetAmountEmailsToTopic(int topicId);
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

        public async Task<IDictionary<Topic, int>> GetTopicsWithAmountOfEmial()
        {
            Dictionary<Topic, int> topicsWithAmountOfEmail = new Dictionary<Topic, int>();

            try
            {
                List<Topic> topics = await _newsletterContext.Topics.ToListAsync();

                foreach (var topic in topics)
                {
                    int emailCount = await GetAmountEmailsToTopic(topic.Id);
                    topicsWithAmountOfEmail.Add(topic, emailCount);
                }
            }
            catch (Exception ex)
            {
                //TODO
                throw new Exception();
            }

            return topicsWithAmountOfEmail;
        }

        public async Task<int> GetAmountEmailsToTopic(int topicId)
        {
            try
            {
                return await _newsletterContext.EmailTopics.Where(e => e.TopicId == topicId).CountAsync();
            }
            catch (Exception ex)
            {
                //TODO
                throw new Exception();
            }
        }

        public async Task<int> GetCountTopicsAsync()
        {
            try
            {
                return await _newsletterContext.Topics.CountAsync();
            }
            catch (Exception ex)
            {
                //TODO
                throw new Exception();
            }
        }

        public async Task AddNewTopic(Topic topic)
        {
            try
            {
                _newsletterContext.Topics.Add(topic);
                await _newsletterContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //TODO
                throw new Exception();
            }
        }

        public async Task RemoveTopic(Topic topic)
        {
            try
            {
                _newsletterContext.Topics.Remove(topic);
                await _newsletterContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //TODO
                throw new Exception();
            }
        }
    }
}
