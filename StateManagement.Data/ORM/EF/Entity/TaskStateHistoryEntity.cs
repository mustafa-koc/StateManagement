using StateManagement.Core.Entity.Base;

namespace StateManagement.Data.ORM.EF.Entity
{
    // TaskStateHistory
    public class TaskStateHistoryEntity : EntityBase
    {
        public long? TaskId { get; set; }
        public long? StateId { get; set; }
        public bool IsDeleted { get; set; }

        // Foreign keys
        public virtual StateEntity State { get; set; }

        public virtual TaskEntity Task { get; set; }

        public TaskStateHistoryEntity()
        {
            IsDeleted = false;
        }
    }
}
