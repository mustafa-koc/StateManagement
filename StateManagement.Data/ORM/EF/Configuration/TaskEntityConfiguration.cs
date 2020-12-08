using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StateManagement.Data.ORM.EF.Entity;

namespace StateManagement.Data.ORM.EF.Configuration
{
    // Task
    public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Task", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Task").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.FlowDefinationId).HasColumnName(@"FlowDefinationID").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.TaskTitle).HasColumnName(@"TaskTitle").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);

            // Foreign keys
            builder.HasOne(a => a.FlowDefination).WithMany(b => b.Tasks).HasForeignKey(c => c.FlowDefinationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Task_FlowDefination");
        }
    }
}
