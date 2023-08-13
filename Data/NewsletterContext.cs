using EmailNewsletter.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailNewsletter.Data
{
    public class NewsletterContext : DbContext
    {
        public DbSet<Email> Emails { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<EmailTopic> EmailTopics { get; set; }

        public NewsletterContext() : base() { }

        public NewsletterContext(DbContextOptions<NewsletterContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.EmailAddress).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.EmailAddress).IsUnique();               
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            });

            modelBuilder.Entity<EmailTopic>(entity =>
            {
                entity.HasKey(e => new {e.EmailId, e.TopicId});

                entity.HasOne(e => e.Email)
                .WithMany(e => e.EmailTopics)
                .HasForeignKey(e => e.EmailId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Topic)
                .WithMany(e => e.EmailTopics)
                .HasForeignKey(e => e.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
