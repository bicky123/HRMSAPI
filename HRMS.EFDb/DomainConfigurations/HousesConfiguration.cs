using HRMS.EFDb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.EFDb.DomainConfigurations
{
    public class HousesConfiguration : IEntityTypeConfiguration<Houses>
    {
        public void Configure(EntityTypeBuilder<Houses> builder)
        {
            builder.ToTable("Houses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            builder.Property(x => x.HouseName)
                .HasColumnName("HouseName")
                .HasColumnType("nvarchar")
                .HasMaxLength(250);

            builder.Property(x => x.HouseNo)
                .HasColumnName("HouseNo")
                .HasColumnType("nvarchar")
                .HasMaxLength(250);

            builder.Property(x => x.Latitude)
                .HasColumnName("Latitude")
                .HasColumnType("decimal(18,10)")
                .HasDefaultValue(0);

            builder.Property(x => x.Longitude)
                .HasColumnName("Longitude")
                .HasColumnType("decimal(18,10)")
                .HasDefaultValue(0);

            builder.Property(x => x.ZipCode)
                .HasColumnName("ZipCode")
                .HasColumnType("nvarchar")
                .HasMaxLength(20);

            builder.Property(x => x.CountryId)
                .HasColumnName("CountryId")
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(x => x.StateId)
                .HasColumnName("StateId")
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(x => x.City)
                .HasColumnName("City")
                .HasColumnType("nvarchar")
                .HasMaxLength(250);

            builder.Property(x => x.Address)
                .HasColumnName("Address")
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

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
