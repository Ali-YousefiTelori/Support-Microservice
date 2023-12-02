using EasyMicroservices.ContentsMicroservice.Clients.Attributes;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Contracts.Requests
{
    public class CreateTicketHistoryRequestContract
    {
        public long TicketId { get; set; }
        [ContentLanguage(nameof(TicketHistoryContract.Content))]
        public List<Common.LanguageDataContract> Content { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
