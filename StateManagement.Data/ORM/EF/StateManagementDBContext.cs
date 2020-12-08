using Microsoft.EntityFrameworkCore;
using StateManagement.Data.ORM.EF.Configuration;
using StateManagement.Data.ORM.EF.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateManagement.Data.ORM.EF
{
    public class StateManagementDBContext : DbContext
    {
        public StateManagementDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FlowDefinationEntity> FlowDefinations { get; set; } // FlowDefination
        public DbSet<FlowStateEntity> FlowStates { get; set; } // FlowState
        public DbSet<FlowStateRuleEntity> FlowStateRules { get; set; } // FlowStateRule
        public DbSet<StateEntity> States { get; set; } // State
        public DbSet<TaskEntity> Tasks { get; set; } // Task
        public DbSet<TaskStateHistoryEntity> TaskStateHistories { get; set; } // TaskStateHistory



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FlowDefinationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FlowStateEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FlowStateRuleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StateEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskStateHistoryEntityConfiguration());
        }
    }
}
