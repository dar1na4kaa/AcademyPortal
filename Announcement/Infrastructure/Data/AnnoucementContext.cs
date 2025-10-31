using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AnnouncementContext : DbContext
{
    public AnnouncementContext(DbContextOptions<AnnouncementContext> options): base(options) { }

    public DbSet<Announcement> Announcements { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("announcements");

            entity.Property(e => e.Title);
            entity.Property(e => e.Content);
            entity.Property(e => e.CreatedAt);
            entity.Property(e => e.CreatorId);
            entity.Property(e => e.ExpirationDate);
            entity.Property(e => e.IsActive);
            entity.Property(e => e.Guid);
        });
    }
}