using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Business.Interface;
using StateManagement.DTO.Flow;

namespace StateManagement.PresentationAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlowController : ControllerBase
    {
        private readonly IFlowService _flowService;
        public FlowController(IFlowService flowService)
        {
            _flowService = flowService;
        }

        [HttpPost]
        [Route("FlowDefination")]
        public bool AddFlowDefination(AddFlowDefinationDto dto)
        {
            return _flowService.AddFlowDefination(dto);
        }

        [HttpGet]
        [Route("FlowDefination")]
        public List<GetAllFlowDefinationsResDto> GetAllFlowDefinations()
        {
            return _flowService.GetAllFlowDefinations();
        }

        [HttpDelete]
        [Route("FlowDefination")]
        public bool DeleteFlowDefination(long id)
        {
            return _flowService.DeleteFlowDefination(id);
        }

        [HttpPost]
        [Route("FlowRule")]
        public bool AddFlowRule(List<AddFlowRuleDto> dto)
        {
            return _flowService.AddFlowRule(dto);
        }

        [HttpGet]
        [Route("FlowRule")]
        public List<GetAllFlowRulesResDto> GetFlowRules(long flowDefId)
        {
            return _flowService.GetFlowRules(flowDefId);
        }

        [HttpDelete]
        [Route("FlowRule")]
        public bool DeleteFlowRule(long ruleId)
        {
            return _flowService.DeleteFlowRule(ruleId);
        }

    }
}
