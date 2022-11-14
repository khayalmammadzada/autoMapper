using System;
using autoMapperTask.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace autoMapperTask.Configurations.BaseConfigurations;

public static class BaseConfigurations
{
    public static EntityTypeBuilder<TEnitty> AddBaseEntityConfiguration<TEnitty>(this EntityTypeBuilder<TEnitty> builder)
        where TEnitty : BaseEntity<string>
    {
        builder.Property(b => b.IsDeleted).HasDefaultValue(false);
        builder.Property(b => b.Id).HasDefaultValueSql("NEWID()");
        return builder;
    }
    public static EntityTypeBuilder<TEnitty> AddBaseAuditableConfiguration<TEnitty>(this EntityTypeBuilder<TEnitty> builder)
       where TEnitty : BaseAuditable<string>
    {
        builder.AddBaseEntityConfiguration();
        builder.Property(b => b.CreatedBy).IsRequired();
        builder.Property(b => b.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(b => b.UpdatedBy).IsRequired(false);
        return builder;
    }
}
