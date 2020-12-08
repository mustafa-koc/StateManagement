
namespace StateManagement.DTO.Task
{
    public class GetTaskResDto
    {
        public long TaskId { get; set; }
        public string TaskTitle { get; set; }
        public long FlowDefId { get; set; }
        public string FlowDefTitle { get; set; }
        public long ActiveStateId { get; set; }
        public string ActiveStateTitle { get; set; }
    }
}
