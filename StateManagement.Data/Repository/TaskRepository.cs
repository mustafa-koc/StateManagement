using System.Collections.Generic;
using System.Linq;
using StateManagement.Data.ORM.EF;
using StateManagement.Data.ORM.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace StateManagement.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly StateManagementDBContext _context;
        public TaskRepository(StateManagementDBContext context)
        {
            _context = context;
        }

        public bool Add(TaskEntity entity)
        {
            var stateRuleEntity = _context.FlowStateRules.Where(q => q.FlowDefinationId == entity.FlowDefinationId && q.FromStateId == null).FirstOrDefault();

            if (stateRuleEntity == null)
                return false;

            entity.TaskStateHistories.Add(new TaskStateHistoryEntity { IsDeleted = false, StateId = stateRuleEntity.ToStateId });
            _context.Tasks.Add(entity);
            return _context.SaveChanges()>0;
        }

        public List<TaskStateHistoryEntity> GetTaskHistories(long taskId)
        {
            return _context.TaskStateHistories.Include(i=>i.State)
                .Where(q => q.IsDeleted == false && q.TaskId == taskId)
                .OrderByDescending(o => o.Id)
                .ToList();
        }

        public long GetLoanDefIdByTaskId(long id)
        {
            return _context.Tasks.First(f=>f.Id == id).FlowDefinationId;
        }

        public long GetLatestTaskStateId(long taskId)
        {
            return _context.TaskStateHistories.Where(q => q.IsDeleted == false && q.TaskId == taskId).OrderByDescending(o => o.Id).First().StateId.Value;
        }

        public bool AddTaskStateHistory(long taskId, long stateId)
        {
            var taskEntity = _context.Tasks.Include(i => i.TaskStateHistories).FirstOrDefault(f => f.Id == taskId);
            if (taskEntity == null)
                return false;

            if (_context.TaskStateHistories.Any(a => a.IsDeleted == false && a.TaskId == taskId && a.StateId == stateId))
                return false;

            taskEntity.TaskStateHistories.Add(new TaskStateHistoryEntity { IsDeleted = false, StateId = stateId, TaskId = taskId });
            _context.Tasks.Update(taskEntity);
            return _context.SaveChanges() > 0; 
        }

        public bool StateRollback(long taskId, long targetHistoryId)
        {
            var histories = _context.TaskStateHistories.Where(q => q.IsDeleted == false && q.TaskId == taskId).OrderByDescending(o => o.Id).ToList();
            if (!histories.Any())
                return false;

            foreach (var historyItem in histories)
            {
                if (historyItem.Id == targetHistoryId)
                    break;

                historyItem.IsDeleted = true;
                _context.TaskStateHistories.Update(historyItem);
            }

            return _context.SaveChanges() > 0;
        }

        public TaskEntity GetById(long id)
        {
            return _context.Tasks.Include(i => i.FlowDefination)
                .Include(ii => ii.TaskStateHistories)
                .FirstOrDefault(f => f.Id == id);
        }
    }
}
