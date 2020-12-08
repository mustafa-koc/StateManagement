using StateManagement.Data.ORM.EF.Entity;
using System.Collections.Generic;

namespace StateManagement.Data.Repository
{
    public interface IFlowRepository
    {
        bool AddFlowDefination(FlowDefinationEntity entity);
        bool AddFlowRule(List<FlowStateRuleEntity> entities);
        bool DeleteFlowRule(long ruleId);
        List<FlowDefinationEntity> GetAllFlowDefinations();
        List<FlowStateRuleEntity> GetFlowRules(long flowDefId);
        bool DeleteFlowDefination(long id);
        bool CheckRule(long flowDefId, long fromStateId, long toStateId);
    }
}
