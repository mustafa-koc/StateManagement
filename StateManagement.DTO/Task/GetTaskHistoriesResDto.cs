
using System;

namespace StateManagement.DTO.Task
{
    public class GetTaskHistoriesResDto
    {
        public long Id { get; set; }
        public long StateId { get; set; }
        public string StateTitle { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
