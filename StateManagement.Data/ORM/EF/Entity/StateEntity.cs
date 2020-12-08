using StateManagement.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateManagement.Data.ORM.EF.Entity
{
    // State
    public class StateEntity : EntityBase
    {
        public string StateTitle { get; set; } // StateTitle (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child FlowStates where [FlowState].[StateID] point to this entity (FK_FlowState_State)
        /// </summary>
        public virtual ICollection<FlowStateEntity> FlowStates { get; set; } // FlowState.FK_FlowState_State

        /// <summary>
        /// Child FlowStateRules where [FlowStateRule].[FromStateID] point to this entity (FK_FlowStateRule_State)
        /// </summary>
        public virtual ICollection<FlowStateRuleEntity> FlowStateRules_FromStateId { get; set; } // FlowStateRule.FK_FlowStateRule_State

        /// <summary>
        /// Child FlowStateRules where [FlowStateRule].[ToStateID] point to this entity (FK_FlowStateRule_State1)
        /// </summary>
        public virtual ICollection<FlowStateRuleEntity> FlowStateRules_ToStateId { get; set; } // FlowStateRule.FK_FlowStateRule_State1

        /// <summary>
        /// Child TaskStateHistories where [TaskStateHistory].[StateID] point to this entity (FK_TaskStateHistory_State)
        /// </summary>
        public virtual ICollection<TaskStateHistoryEntity> TaskStateHistories { get; set; } // TaskStateHistory.FK_TaskStateHistory_State

        public StateEntity()
        {
            FlowStates = new List<FlowStateEntity>();
            FlowStateRules_FromStateId = new List<FlowStateRuleEntity>();
            FlowStateRules_ToStateId = new List<FlowStateRuleEntity>();
            TaskStateHistories = new List<TaskStateHistoryEntity>();
        }
    }
}
