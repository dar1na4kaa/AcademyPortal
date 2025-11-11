using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAnnouncementService
{
    public Task CreateAsync(AnnouncementDTO announcement);
    public Task<List<AnnouncementDTO>> GetAnnouncements();
    public Task<IEnumerable<AnnouncementDTO>> GetAnnouncementsByFilters(AnnouncementFilterDto filter);
}