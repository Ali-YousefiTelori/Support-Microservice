using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Contracts.Requests
{
    public class UpdateTicketHistoryRequestContract : CreateTicketHistoryRequestContract
    {
        public long Id { get; set; }
    }
}
