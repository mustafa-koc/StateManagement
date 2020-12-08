using StateManagement.DTO.State;
using System.Collections.Generic;

namespace StateManagement.Business.Interface
{
    public interface IStateService
    {
        bool Add(AddStateDto dto);
        IEnumerable<GetAllStateResDto> GetAll();
    }
}
