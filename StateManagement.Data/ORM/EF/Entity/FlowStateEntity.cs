using StateManagement.Core.Entity.Base;
using System.Collections.Generic;

namespace StateManagement.Data.ORM.EF.Entity
{
    public class FlowStateEntity : EntityBase
    {
        public long? FlowDefinationId { get; set; } // FlowDefinationID
        public long? StateId { get; set; } // StateID
        public byte? StateOrder { get; set; } // StateOrder


        // Foreign keys
        public virtual FlowDefinationEntity FlowDefination { get; set; } 

        public virtual StateEntity State { get; set; } 

        public FlowStateEntity()
        {
        }
    }
}
