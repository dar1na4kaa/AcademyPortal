using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAnnouncementService
{
    public Task CreateAsync(CreateAnnouncementDto createAnnouncement);
    public Task<IEnumerable<CreateAnnouncementDto>> GetAnnouncementsByFilters(AnnouncementQueryParameters filter);
}