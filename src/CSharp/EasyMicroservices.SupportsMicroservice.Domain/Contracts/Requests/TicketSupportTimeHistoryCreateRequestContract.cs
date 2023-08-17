using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Contracts.Requests
{
    public class TicketSupportTimeHistoryCreateRequestContract
    {
        public long TicketId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
