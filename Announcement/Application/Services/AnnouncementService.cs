using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Entities;
using System.Threading;

namespace Application.Services;

public class AnnouncementService(IAnnouncementRepository repository): IAnnouncementService
{
    public async Task CreateAsync(AnnouncementDTO announcement)
    {
       await repository.CreateAsync(announcement);
       await repository.SaveAsync();
    }

    public async Task<List<AnnouncementDTO>> GetAnnouncements()
    {
        var announcements = await repository.GetAnnouncements();

        return announcements.Select(a => a.Map()).ToList();
    }

    public async Task<IEnumerable<AnnouncementDTO>> GetAnnouncementsByFilters(AnnouncementFilterDto filter)
    {
        var announcements = await repository.GetAnnouncementsByFilters(filter);

        return announcements.Select(a => a.Map());
    }
}