using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Contracts.Requests
{
    public class UpdateTicketDiscussionRequestContract
    {
        public long Id { get; set; }
        public long TicketId { get; set; }
        public string Content { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
