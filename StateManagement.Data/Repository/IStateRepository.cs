using StateManagement.Data.ORM.EF.Entity;
using System.Collections.Generic;

namespace StateManagement.Data.Repository
{
    public interface IStateRepository
    {
        bool Add(StateEntity entity);
        IEnumerable<StateEntity> GetAll();
        StateEntity GetById(long id);
    }
}
