using System;
using autoMapperTask.Configurations.BaseConfigurations;
using autoMapperTask.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace autoMapperTask.Configurations;

public class DeparmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.AddBaseEntityConfiguration();
        builder.Property(d => d.Name).IsRequired().HasMaxLength(64);

        builder
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId);

    }
}
