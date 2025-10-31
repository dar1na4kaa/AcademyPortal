using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Announcement
    {
        public int Id { get; }
        
        public Guid Guid { get; set; }
        public string Title { get; }
        public string Content { get; }
        public Guid CreatorId { get; }
        public DateOnly ExpirationDate { get; }
        public DateTime CreatedAt { get; }
        public bool IsActive { get; }
        private Announcement(string title, string content, Guid creatorId, DateOnly expDate, bool isActive, DateTime createdAt, Guid guid)
        {
            Title = title;
            Content = content;
            CreatorId = creatorId;
            ExpirationDate = expDate;
            IsActive = isActive;
            CreatedAt = createdAt;
            Guid = guid;
        }

        private Announcement()
        {
            
        }

        public static Announcement CreateAnnouncement(string title, string content, Guid creatorId, DateOnly expDate)
        {
            Console.WriteLine(System.Guid.NewGuid());
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException("Title can not be empty or null");
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException("Content can not be empty or null");
            if (creatorId == Guid.Empty) throw new ArgumentNullException("CreatorId can not be empty or null");
            if (expDate < DateOnly.FromDateTime(DateTime.Now)) throw new ArgumentException("Expiration date can not be later than creation date");
            if (expDate == DateOnly.MinValue) throw new ArgumentException("Expiration date can not be empty");
            DateTime createdAt = DateTime.Now;
            var guid = System.Guid.NewGuid();
            return new Announcement(title, content, creatorId, expDate, true, createdAt, guid);
        }
        //методы 
    }
}
