using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StateManagement.Data.ORM.EF.Entity;

namespace StateManagement.Data.ORM.EF.Configuration
{
    // State
    public class StateEntityConfiguration : IEntityTypeConfiguration<StateEntity>
    {
        public void Configure(EntityTypeBuilder<StateEntity> builder)
        {
            builder.ToTable("State", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_State").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.StateTitle).HasColumnName(@"StateTitle").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);

        }
    }
}
