using HRMS.EFDb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.EFDb.DomainConfigurations
{
    public class RenterHouseMappingsConfiguration : IEntityTypeConfiguration<RenterHouseMappings>
    {
        public void Configure(EntityTypeBuilder<RenterHouseMappings> builder)
        {
            builder.ToTable("RenterHouseMappings");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            builder.Property(x => x.HouseId)
               .HasColumnName("HouseId")
               .HasColumnType("int")
               .HasDefaultValue(0);

            builder.Property(x => x.CreatedOn)
                .HasColumnName("CreatedOn")
                .HasColumnType("datetimeoffset(7)")
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            builder.Property(x => x.UpdatedOn)
                .HasColumnName("UpdatedOn")
                .HasColumnType("datetimeoffset(7)")
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
        }
    }
}
