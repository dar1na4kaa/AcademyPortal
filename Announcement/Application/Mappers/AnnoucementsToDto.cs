using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Entities;

namespace Application.Mappers
{
    public static class AnnoucementsToDto
    {
        public static CreateAnnouncementDto Map(this Announcement announcement) => new()
        {
            Title = announcement.Title,
            Content = announcement.Content,
            CreatorId = announcement.CreatorId,
            ExpirationDate = announcement.ExpirationDate
        };
    }
}
