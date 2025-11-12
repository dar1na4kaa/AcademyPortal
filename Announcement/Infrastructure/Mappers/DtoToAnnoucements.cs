using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Entities;

namespace Infrastructure.Mappers
{
    public static class DtoToAnnoucements
    {
        public static Announcement Map(this CreateAnnouncementDto dto) => Announcement.CreateAnnouncement(dto.Title, dto.Content, dto.CreatorId, dto.ExpirationDate);
    }
}
