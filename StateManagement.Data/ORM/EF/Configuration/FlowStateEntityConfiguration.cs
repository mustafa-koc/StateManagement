using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StateManagement.Data.ORM.EF.Entity;

namespace StateManagement.Data.ORM.EF.Configuration
{
    // FlowState
    public class FlowStateEntityConfiguration : IEntityTypeConfiguration<FlowStateEntity>
    {
        public void Configure(EntityTypeBuilder<FlowStateEntity> builder)
        {
            builder.ToTable("FlowState", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_FlowState").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.FlowDefinationId).HasColumnName(@"FlowDefinationID").HasColumnType("bigint").IsRequired(false);
            builder.Property(x => x.StateId).HasColumnName(@"StateID").HasColumnType("bigint").IsRequired(false);
            builder.Property(x => x.StateOrder).HasColumnName(@"StateOrder").HasColumnType("tinyint").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.FlowDefination).WithMany(b => b.FlowStates).HasForeignKey(c => c.FlowDefinationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FlowState_FlowDefination");
            builder.HasOne(a => a.State).WithMany(b => b.FlowStates).HasForeignKey(c => c.StateId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FlowState_State");
        }
    }
}
