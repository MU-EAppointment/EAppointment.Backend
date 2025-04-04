using EAppointment.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAppointment.Persistence.EntitiesMappings
{
    internal sealed class DoctorMapping : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(d => d.FirstName).HasColumnType("varchar(50)");
            builder.Property(d => d.LastName).HasColumnType("varchar(50)");
            builder.Property(d => d.Department).HasColumnType("varchar(50)");
            builder.Ignore(d => d.FullName);
        }
    }
}
