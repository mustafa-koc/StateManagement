using StateManagement.Core.Entity.Base;

namespace StateManagement.Data.ORM.EF.Entity
{
    public class FlowStateRuleEntity : EntityBase
    {
        public long? FlowDefinationId { get; set; } 
        public long? FromStateId { get; set; } 
        public long? ToStateId { get; set; } 


        // Foreign keys
        public virtual FlowDefinationEntity FlowDefination { get; set; } 

        public virtual StateEntity FromState { get; set; } 

        public virtual StateEntity ToState { get; set; } 
    }
}
