using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Market.Domain.Entities.Cafe;

namespace Market.Infrastructure.Database.Configurations.Cafe
{
    public class CafeTableConfiguration : IEntityTypeConfiguration<CafeTableEntity>
    {
        public void Configure(EntityTypeBuilder<CafeTableEntity> builder)
        {
            builder.ToTable("CafeTables");

            builder.Property(x => x.TableNumber).IsRequired();

            builder.Property(x => x.IsEnabled).IsRequired();

            builder.HasIndex(x => x.TableNumber).IsUnique().HasFilter("[IsDeleted] = 0");
        }
    }
}
