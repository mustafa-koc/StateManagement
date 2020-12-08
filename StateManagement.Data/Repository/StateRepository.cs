using StateManagement.Data.ORM.EF;
using StateManagement.Data.ORM.EF.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateManagement.Data.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly StateManagementDBContext _context;
        public StateRepository(StateManagementDBContext context)
        {
            _context = context;
        }

        public bool Add(StateEntity entity)
        {
            _context.States.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<StateEntity> GetAll()
        {
            return _context.States.ToList();
        }

        public StateEntity GetById(long id)
        {
            return _context.States.FirstOrDefault(f => f.Id == id);
        }
    }
}
