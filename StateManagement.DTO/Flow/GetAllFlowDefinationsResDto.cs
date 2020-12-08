using System.Collections.Generic;

namespace StateManagement.DTO.Flow
{
    public class GetAllFlowDefinationsResDto
    {
        public long Id { get; set; }
        public string FlowTitle { get; set; }
        public List<FlowStateResDto> States { get; set; }

        public GetAllFlowDefinationsResDto()
        {
            States = new List<FlowStateResDto>();
        }
    }


    public class FlowStateResDto{
        public long Id { get; set; }
        public string StateTitle { get; set; }
        public byte? Order { get; set; }
    }
}
