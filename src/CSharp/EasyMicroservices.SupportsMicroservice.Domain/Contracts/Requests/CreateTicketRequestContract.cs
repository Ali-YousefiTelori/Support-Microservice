using EasyMicroservices.SupportsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Contracts.Requests
{
    public class CreateTicketRequestContract
    {
        public string Title { get; set; }
        public TicketStatusType Status { get; set; }
        public TicketSensitivityStatusType SensitivityStatus { get; set; }
        public int? Priority { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
