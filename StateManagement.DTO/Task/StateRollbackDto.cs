
namespace StateManagement.DTO.Task
{
    public class StateRollbackDto
    {
        public long TaskId { get; set; }
        public long TargetHistoryId { get; set; }
    }
}
