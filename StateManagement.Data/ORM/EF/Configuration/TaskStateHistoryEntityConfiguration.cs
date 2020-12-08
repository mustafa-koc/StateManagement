using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StateManagement.Data.ORM.EF.Entity;

namespace StateManagement.Data.ORM.EF.Configuration
{
    // TaskStateHistory
    public class TaskStateHistoryEntityConfiguration : IEntityTypeConfiguration<TaskStateHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<TaskStateHistoryEntity> builder)
        {
            builder.ToTable("TaskStateHistory", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TaskStateHistory").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.TaskId).HasColumnName(@"TaskID").HasColumnType("bigint").IsRequired(false);
            builder.Property(x => x.StateId).HasColumnName(@"StateID").HasColumnType("bigint").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"Is_Deleted").HasColumnType("bit").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.State).WithMany(b => b.TaskStateHistories).HasForeignKey(c => c.StateId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TaskStateHistory_State");
            builder.HasOne(a => a.Task).WithMany(b => b.TaskStateHistories).HasForeignKey(c => c.TaskId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TaskStateHistory_Task");
        }
    }
}
