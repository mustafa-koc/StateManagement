using System;
using System.Collections.Generic;

namespace StateManagement.DTO.Flow
{
    public class AddFlowDefinationDto
    {
        public string FlowTitle { get; set; }
        public List<AddFlowStateDto> States { get; set; }
    }

    public class AddFlowStateDto
    {
        public long StateId { get; set; }
        public Byte Order { get; set; }
    }
}
