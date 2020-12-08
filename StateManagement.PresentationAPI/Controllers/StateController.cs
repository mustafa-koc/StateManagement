using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Business.Interface;
using StateManagement.DTO.State;

namespace StateManagement.PresentationAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpPost]
        public bool Add(AddStateDto dto)
        {
            return _stateService.Add(dto);
        }

        [HttpGet]
        public IEnumerable<GetAllStateResDto> GetAll()
        {
            return _stateService.GetAll();
        }
    }
}
