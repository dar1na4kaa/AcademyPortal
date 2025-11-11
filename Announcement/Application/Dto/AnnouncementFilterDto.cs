using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AnnouncementFilterDto
    {
        public string? Title { get; set; }

        public string? Content { get; set; }

        public Guid? CreatorId { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
