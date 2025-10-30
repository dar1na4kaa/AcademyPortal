using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AnnoucementContext : DbContext
    {
        public AnnoucementContext(DbContextOptions<AnnoucementContext> options): base(options) { }

        DbSet<Announcement> Announcements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity => 
            { 
                entity.HasKey(e => e.Id);
            });
        }
    }
}
