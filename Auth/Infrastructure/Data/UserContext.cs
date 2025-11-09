using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class UserContext: DbContext
{
    public UserContext(DbContextOptions<UserContext> options): base(options) { }

    public DbSet<User> Users;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.OwnsOne(e => e.Email, email =>
                {
                    email
                        .Property(e => e.Value)
                        .HasColumnName("Email")
                        .IsRequired();
                });
                
                entity.OwnsOne(e => e.Password, password =>
                {
                    password
                        .Property(e => e.Value)
                        .HasColumnName("Password")
                        .IsRequired();
                });
                
                entity.Property(e => e.UserGuid).IsRequired();
            }
            );
    }
}