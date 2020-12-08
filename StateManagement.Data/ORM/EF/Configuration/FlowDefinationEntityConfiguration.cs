using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StateManagement.Data.ORM.EF.Entity;

namespace StateManagement.Data.ORM.EF.Configuration
{

    // FlowDefination
    public class FlowDefinationEntityConfiguration : IEntityTypeConfiguration<FlowDefinationEntity>
    {
        public void Configure(EntityTypeBuilder<FlowDefinationEntity> builder)
        {
            builder.ToTable("FlowDefination", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_FlowDefination").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.FlowTitle).HasColumnName(@"FlowTitle").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
        }
    }
}
