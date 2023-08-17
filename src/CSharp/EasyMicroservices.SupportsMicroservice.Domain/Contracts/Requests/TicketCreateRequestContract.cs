using EasyMicroservices.SupportsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Contracts.Requests
{
    public class TicketCreateRequestContract
    {
        public string Title { get; set; }
        public StatusType Status { get; set; }
        public SensitivityStatusType SensitivityStatus { get; set; }
        public int? Priority { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
