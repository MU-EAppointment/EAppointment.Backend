using EAppointment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAppointment.Persistence.EntitiesMappings
{
    internal sealed class PatientMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");
            builder.Property(p => p.City).HasColumnType("varchar(50)");
            builder.Property(p => p.District).HasColumnType("varchar(50)");
            builder.Property(p => p.IdentityNumber).HasColumnType("varchar(11)");
            builder.Property(p => p.FullAddress).HasColumnType("varchar(500)");
            builder.HasIndex(p => p.IdentityNumber).IsUnique();
            builder.Ignore(p => p.FullName);
        }
    }
}
