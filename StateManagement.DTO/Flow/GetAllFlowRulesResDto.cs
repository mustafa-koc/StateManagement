
namespace StateManagement.DTO.Flow
{
    public class GetAllFlowRulesResDto
    {
        public long RuleId { get; set; }

        public RuleStateResDto? FromState { get; set; }
        public RuleStateResDto ToState { get; set; }
    }

    public class RuleStateResDto
    {
        public long Id { get; set; }
        public string StateTitle { get; set; }
    }
}
