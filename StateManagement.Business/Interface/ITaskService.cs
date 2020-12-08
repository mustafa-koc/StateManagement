using StateManagement.DTO.Task;
using System.Collections.Generic;

namespace StateManagement.Business.Interface
{
    public interface ITaskService
    {
        bool Add(AddTaskDto dto);
        List<GetTaskHistoriesResDto> GetTaskHistories(long taskId);
        bool StateUpdate(TaskStateUpdateDto dto);
        bool StateRollback(StateRollbackDto dto);
        GetTaskResDto GetById(long id);
    }
}
