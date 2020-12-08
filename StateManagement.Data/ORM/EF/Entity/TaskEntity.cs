using StateManagement.Core.Entity.Base;
using System.Collections.Generic;

namespace StateManagement.Data.ORM.EF.Entity
{
    // Task
    public class TaskEntity : EntityBase
    {
        public long FlowDefinationId { get; set; }
        public string TaskTitle { get; set; }

        public virtual ICollection<TaskStateHistoryEntity> TaskStateHistories { get; set; }

        // Foreign keys
        public virtual FlowDefinationEntity FlowDefination { get; set; }

        public TaskEntity()
        {
            TaskStateHistories = new List<TaskStateHistoryEntity>();
        }
    }
}
