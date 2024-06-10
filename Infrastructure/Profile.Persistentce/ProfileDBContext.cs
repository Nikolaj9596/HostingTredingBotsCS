using Microsoft.EntityFrameworkCore;
using Profile.Application.Interfaces;
using Profile.Domain;
using Profile.Persistence.EntityTypeConfiguration;

namespace Profile.Persistence
{
  public class ProfileDBContext: DbContext, IProfileDBContext
  {
    public DbSet<Profile.Domain.Profile> Profies {get; set;}
    public ProfileDBContext(DbContextOptions<ProfileDBContext> options)
      :base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ProfileConfiguration());
      base.OnModelCreating(modelBuilder)
    }
  }
}
