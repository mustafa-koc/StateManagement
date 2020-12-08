using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Business.Interface;
using StateManagement.DTO.Task;

namespace StateManagement.PresentationAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public bool AddTask(AddTaskDto dto)
        {
            return _taskService.Add(dto);
        }

        [HttpGet]
        [Route("histories")]
        public List<GetTaskHistoriesResDto> GetTaskHistories(long taskId)
        {
            return _taskService.GetTaskHistories(taskId);
        }

        [HttpPost]
        [Route("stateUpdate")]
        public bool StateUpdate(TaskStateUpdateDto dto)
        {
            return _taskService.StateUpdate(dto);
        }

        [HttpPost]
        [Route("stateRollback")]
        public bool StateRollback(StateRollbackDto dto)
        {
            return _taskService.StateRollback(dto);
        }

        [HttpGet]
        public GetTaskResDto Get(long id)
        {
            return _taskService.GetById(id);
        }
    }
}
