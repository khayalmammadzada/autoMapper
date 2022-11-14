using System;
using autoMapperTask.Configurations.BaseConfigurations;
using autoMapperTask.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace autoMapperTask.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.AddBaseAuditableConfiguration();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(64);
        builder.Property(e => e.Surname).IsRequired().HasMaxLength(128);

        builder
            .HasOne(e => e.Department)
           .WithMany(e => e.Employees)
           .HasForeignKey(e => e.DepartmentId);
    }
}

