using StateManagement.Business.Interface;
using StateManagement.Data.ORM.EF.Entity;
using StateManagement.Data.Repository;
using StateManagement.DTO.Flow;
using System.Collections.Generic;
using System.Linq;

namespace StateManagement.Business.Service
{
    public class FlowService : IFlowService
    {
        private readonly IFlowRepository _flowRepository;
        public FlowService(IFlowRepository flowRepository)
        {
            _flowRepository = flowRepository;
        }

        public bool AddFlowDefination(AddFlowDefinationDto dto)
        {
            var entity = new FlowDefinationEntity {FlowTitle = dto.FlowTitle };
            entity.FlowStates = dto.States.Select(s => new FlowStateEntity { StateId = s.StateId, StateOrder = s.Order }).ToList();
            return _flowRepository.AddFlowDefination(entity);
        }

        public List<GetAllFlowDefinationsResDto> GetAllFlowDefinations()
        {
            var repoResult = _flowRepository.GetAllFlowDefinations();
            return repoResult.Select(s => new GetAllFlowDefinationsResDto { Id = s.Id, FlowTitle = s.FlowTitle, States = s.FlowStates.Select(ss=> new FlowStateResDto { Id = ss.Id, StateTitle = ss.State.StateTitle, Order = ss.StateOrder}).ToList() }).ToList();
        }

        public bool AddFlowRule(List<AddFlowRuleDto> dto)
        {
            var entities = dto.Select(s => new FlowStateRuleEntity { FlowDefinationId = s.FlowDefinationId, FromStateId = s.FromStateId, ToStateId = s.ToStateId }).ToList();
            return _flowRepository.AddFlowRule(entities);
        }

        public bool DeleteFlowRule(long ruleId)
        {
            return _flowRepository.DeleteFlowRule(ruleId);
        }

        public List<GetAllFlowRulesResDto> GetFlowRules(long flowDefId)
        {
            var repoResult = _flowRepository.GetFlowRules(flowDefId);
           
            return repoResult.
                Select(s=> new GetAllFlowRulesResDto 
                { RuleId = s.Id,
                  FromState = s.FromState == null ? null : new RuleStateResDto {  Id = s.FromState.Id, StateTitle = s.FromState.StateTitle},
                  ToState = new RuleStateResDto { Id = s.ToState.Id, StateTitle = s.ToState.StateTitle }
                }).ToList();
        }

        public bool DeleteFlowDefination(long id)
        {
            return _flowRepository.DeleteFlowDefination(id);
        }
    }
}
