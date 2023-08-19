using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.SupportsMicroservice.Database.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Database.Entities
{
    public class TicketSupportTimeHistoryEntity : TicketSupportTimeHistorySchema , IIdSchema<long>
    {
        public long TicketId { get; set; }
        public long Id { get; set; }
    }
}
