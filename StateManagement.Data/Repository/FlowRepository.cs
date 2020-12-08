using Microsoft.EntityFrameworkCore;
using StateManagement.Data.ORM.EF;
using StateManagement.Data.ORM.EF.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateManagement.Data.Repository
{
    public class FlowRepository : IFlowRepository
    {
        private readonly StateManagementDBContext _context;
        public FlowRepository(StateManagementDBContext context)
        {
            _context = context;
        }

        public bool AddFlowDefination(FlowDefinationEntity entity)
        {
            _context.FlowDefinations.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public List<FlowDefinationEntity> GetAllFlowDefinations()
        {
            return _context.FlowDefinations.Include(i => i.FlowStates).Include("FlowStates.State").ToList();
        }

        public bool DeleteFlowDefination(long id)
        {
            var entity = _context.FlowDefinations.FirstOrDefault(q => q.Id == id);
            if (entity == null)
                return false;

            _context.FlowDefinations.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public bool AddFlowRule(List<FlowStateRuleEntity> entities)
        {
            _context.FlowStateRules.AddRange(entities);
            return _context.SaveChanges() > 0;
        }

        public List<FlowStateRuleEntity> GetFlowRules(long flowDefId)
        {
            return _context.FlowStateRules.Include(ii => ii.FromState).Include(i => i.ToState).Where(q=>q.FlowDefinationId == flowDefId).ToList();
        }

        public bool DeleteFlowRule(long ruleId)
        {
            var entity = _context.FlowStateRules.FirstOrDefault(q => q.Id == ruleId);
            if (entity == null)
                return false;

            _context.FlowStateRules.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public bool CheckRule(long flowDefId, long fromStateId, long toStateId)
        {
            return _context.FlowStateRules.Any(q => q.FlowDefinationId == flowDefId && q.FromStateId == fromStateId && q.ToStateId == toStateId);
        }

    }
}
