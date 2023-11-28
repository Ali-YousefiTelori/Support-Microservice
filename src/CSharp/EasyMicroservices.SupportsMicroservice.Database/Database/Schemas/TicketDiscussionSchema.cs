using EasyMicroservices.Cores.Database.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Database.Schemas
{
    public class TicketDiscussionSchema : FullAbilitySchema
    {
        public string Content { get; set; }

    }
}
