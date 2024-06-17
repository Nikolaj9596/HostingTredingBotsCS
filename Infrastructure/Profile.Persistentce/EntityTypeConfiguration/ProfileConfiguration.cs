using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profile.Domain;

namespace Profile.Persistence.EntityTypeConfiguration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile.Domain.Profile>
    {
        public void Configure(EntityTypeBuilder<Profile.Domain.Profile> builder)
        {
            // Установка первичного ключа
            builder.HasKey(profile => profile.Id);
            // Установка индекса для Id, который должен быть уникальным
            builder.HasIndex(profile => profile.Id).IsUnique();
            builder.Property(profile => profile.FirstName).IsRequired();
            builder.Property(profile => profile.LastName).IsRequired();
            builder.Property(profile => profile.MiddleName).IsRequired();
            builder.Property(profile => profile.DateBirthday).IsRequired();
            builder.Property(profile => profile.UserId).IsRequired();
            builder.Property(profile => profile.CreatedAt).IsRequired();
            builder.Property(profile => profile.UpdatedAt).IsRequired(false);
            builder.Property(profile => profile.ArchivedAt).IsRequired(false);
            builder.Property(profile => profile.Avatar).IsRequired(false); // Можно сделать поле опциональным
        }
    }
}

