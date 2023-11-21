using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.SupportsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Database.Schemas
{
    public class TicketSchema : FullAbilitySchema
    {
        public string Title { get; set; }
        public TicketStatusType Status { get; set; }
        public TicketSensitivityStatusType SensitivityStatus { get; set; }
        public int? Priority { get; set; }
    }
}
