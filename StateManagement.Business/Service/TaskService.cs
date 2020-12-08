using StateManagement.Business.Interface;
using StateManagement.Data.ORM.EF.Entity;
using StateManagement.Data.Repository;
using StateManagement.DTO.Task;
using System.Collections.Generic;
using System.Linq;

namespace StateManagement.Business.Service
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IFlowRepository _flowRepository;
        private readonly IStateRepository _stateRepository;
        public TaskService(ITaskRepository taskRepository,
            IFlowRepository flowRepository,
            IStateRepository stateRepository)
        {
            _taskRepository = taskRepository;
            _flowRepository = flowRepository;
            _stateRepository = stateRepository;
        }

        public bool Add(AddTaskDto dto)
        {
            return _taskRepository.Add(new TaskEntity { FlowDefinationId = dto.FlowDefinationId, TaskTitle = dto.TaskTitle });
        }

        public List<GetTaskHistoriesResDto> GetTaskHistories(long taskId)
        {
            var repoResult = _taskRepository.GetTaskHistories(taskId);
            return repoResult.Select(s => new GetTaskHistoriesResDto { StateId = s.StateId.Value, StateTitle = s.State.StateTitle, Id = s.Id }).ToList();
        }

        public bool StateUpdate(TaskStateUpdateDto dto)
        {
            long flowDefId = _taskRepository.GetLoanDefIdByTaskId(dto.TaskId);
            long fromStateId = _taskRepository.GetLatestTaskStateId(dto.TaskId);
            if (_flowRepository.CheckRule(flowDefId, fromStateId, dto.StateId))
                return _taskRepository.AddTaskStateHistory(dto.TaskId, dto.StateId);
            else
                return false;
        }

        public bool StateRollback(StateRollbackDto dto)
        {
            return _taskRepository.StateRollback(dto.TaskId, dto.TargetHistoryId);
        }

        public GetTaskResDto GetById(long id)
        {
            var repoResult = _taskRepository.GetById(id);
            var latestState = repoResult.TaskStateHistories.Where(q => !q.IsDeleted).OrderByDescending(o => o.Id).First();
            var activeState = _stateRepository.GetById(latestState.StateId.Value);
            var result = new GetTaskResDto
            {
                FlowDefId = repoResult.FlowDefinationId,
                FlowDefTitle = repoResult.FlowDefination.FlowTitle,
                TaskId = repoResult.Id,
                TaskTitle = repoResult.TaskTitle,
                ActiveStateId = activeState.Id,
                ActiveStateTitle = activeState.StateTitle
            };
            return result;
        }
    }
}
