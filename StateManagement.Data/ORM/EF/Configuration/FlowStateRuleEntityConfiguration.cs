using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StateManagement.Data.ORM.EF.Entity;

namespace StateManagement.Data.ORM.EF.Configuration
{
    // FlowStateRule
    public class FlowStateRuleEntityConfiguration : IEntityTypeConfiguration<FlowStateRuleEntity>
    {
        public void Configure(EntityTypeBuilder<FlowStateRuleEntity> builder)
        {
            builder.ToTable("FlowStateRule", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_FlowStateRule").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.FlowDefinationId).HasColumnName(@"FlowDefinationID").HasColumnType("bigint").IsRequired(false);
            builder.Property(x => x.FromStateId).HasColumnName(@"FromStateID").HasColumnType("bigint").IsRequired(false);
            builder.Property(x => x.ToStateId).HasColumnName(@"ToStateID").HasColumnType("bigint").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.FlowDefination).WithMany(b => b.FlowStateRules).HasForeignKey(c => c.FlowDefinationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FlowStateRule_FlowDefination");
            builder.HasOne(a => a.FromState).WithMany(b => b.FlowStateRules_FromStateId).HasForeignKey(c => c.FromStateId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FlowStateRule_State");
            builder.HasOne(a => a.ToState).WithMany(b => b.FlowStateRules_ToStateId).HasForeignKey(c => c.ToStateId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FlowStateRule_State1");
        }
    }
}
