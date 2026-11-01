
using EF2.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF2.Configurations
{
    public class OrganizerProfileConfiguration
        : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(
            EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(p => p.OrganizerProfileId);

            builder.Property(p => p.Biography)
                   .IsRequired(false);

            builder.Property(p => p.Website)
                   .IsRequired(false);

            builder.Property(p => p.Logo)
                   .IsRequired(false);
        }

    }
}
