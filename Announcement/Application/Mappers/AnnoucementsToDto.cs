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
        public static AnnouncementDTO Map(this Announcement announcement) => AnnouncementDTO.CreateAnnouncementDTO(announcement.Title, announcement.Content, announcement.CreatorId, announcement.ExpirationDate);
    }
}
