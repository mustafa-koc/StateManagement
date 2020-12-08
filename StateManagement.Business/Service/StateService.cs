using StateManagement.Business.Interface;
using StateManagement.Data.ORM.EF.Entity;
using StateManagement.Data.Repository;
using StateManagement.DTO.State;
using System.Collections.Generic;
using System.Linq;

namespace StateManagement.Business.Service
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public bool Add(AddStateDto dto)
        {
            return _stateRepository.Add(new StateEntity { StateTitle = dto.StateTitle });
        }

        public IEnumerable<GetAllStateResDto> GetAll()
        {
            return _stateRepository.GetAll().Select(s => new GetAllStateResDto { Id = s.Id, StateTitle = s.StateTitle });
        }

    }
}
