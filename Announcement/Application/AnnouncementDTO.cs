using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AnnouncementDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CreatorId { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
