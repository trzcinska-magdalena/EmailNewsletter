using EmailNewsletter.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailNewsletter.Data
{
    public interface IEmailService
    {
        Task<ICollection<Email>> GetAllEmails();
        Task<int> GetCountEmailsAsync();
    }

    public class EmailService : IEmailService
    {
        private readonly NewsletterContext _newsletterContext;

        public EmailService(NewsletterContext newsletterContext)
        {
            _newsletterContext = newsletterContext;
        }

        public async Task<ICollection<Email>> GetAllEmails()
        {
            try
            {
                return await _newsletterContext.Emails.ToListAsync();
            }
            catch (Exception ex)
            {
                //TODO
                throw new Exception();
            }
        }

        public async Task<int> GetCountEmailsAsync()
        {
            try
            {
                return await _newsletterContext.Emails.CountAsync();
            }
            catch (Exception ex)
            {
                //TODO
                throw new Exception();
            }
        }
    }


}
