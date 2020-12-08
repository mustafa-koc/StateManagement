
namespace StateManagement.DTO.Flow
{
    public class AddFlowRuleDto
    {
        public long FlowDefinationId { get; set; }
        public long? FromStateId { get; set; }
        public long ToStateId { get; set; }
    }
}
