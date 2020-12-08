using StateManagement.Data.ORM.EF.Entity;
using System.Collections.Generic;

namespace StateManagement.Data.Repository
{
    public interface ITaskRepository
    {
        bool Add(TaskEntity entity);
        List<TaskStateHistoryEntity> GetTaskHistories(long taskId);
        long GetLoanDefIdByTaskId(long id);
        long GetLatestTaskStateId(long taskId);
        bool AddTaskStateHistory(long taskId, long stateId);
        bool StateRollback(long taskId, long targetHistoryId);
        TaskEntity GetById(long id);
    }
}
