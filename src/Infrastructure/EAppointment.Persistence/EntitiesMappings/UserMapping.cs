using EAppointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAppointment.Persistence.EntitiesMappings
{
    internal sealed class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasColumnType("varchar(50)");
            builder.Property(u => u.LastName).HasColumnType("varchar(50)");
            builder.Ignore(u => u.FullName);
        }
    }
}
