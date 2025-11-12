using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AnnouncementDTO
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CreatorId { get; set; }
        public DateOnly ExpirationDate { get; set; }

        public AnnouncementDTO(string title, string content, Guid creatorId, DateOnly expirationDate)
        {
            Title = title;
            Content = content;
            CreatorId = creatorId;
            ExpirationDate = expirationDate;
        }

        public static AnnouncementDTO CreateAnnouncementDTO(string title, string content, Guid creatorId, DateOnly expirationDate)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException("Title can not be empty or null");
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException("Content can not be empty or null");
            if (creatorId == Guid.Empty) throw new ArgumentNullException("CreatorId can not be empty or null");

            return new AnnouncementDTO(title, content, creatorId, expirationDate);
        }
    }
}
