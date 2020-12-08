using StateManagement.Core.Entity.Base;
using System.Collections.Generic;

namespace StateManagement.Data.ORM.EF.Entity
{
    // FlowDefination
    public class FlowDefinationEntity : EntityBase
    {
        public string FlowTitle { get; set; } 

        public virtual ICollection<FlowStateEntity> FlowStates { get; set; } 

        public virtual ICollection<TaskEntity> Tasks { get; set; }

        public virtual ICollection<FlowStateRuleEntity> FlowStateRules { get; set; }


        public FlowDefinationEntity()
        {
            FlowStateRules = new List<FlowStateRuleEntity>();
            FlowStates = new List<FlowStateEntity>();
            Tasks = new List<TaskEntity>();
        }
    }
}
