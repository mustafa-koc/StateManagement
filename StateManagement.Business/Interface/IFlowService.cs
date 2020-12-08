using StateManagement.DTO.Flow;
using System.Collections.Generic;

namespace StateManagement.Business.Interface
{
    public interface IFlowService
    {
        bool AddFlowDefination(AddFlowDefinationDto dto);
        bool AddFlowRule(List<AddFlowRuleDto> dto);
        bool DeleteFlowRule(long ruleId);
        List<GetAllFlowDefinationsResDto> GetAllFlowDefinations();
        List<GetAllFlowRulesResDto> GetFlowRules(long flowDefId);
        bool DeleteFlowDefination(long id);
    }
}
