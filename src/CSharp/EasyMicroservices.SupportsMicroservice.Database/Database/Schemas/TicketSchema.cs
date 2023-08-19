using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.SupportsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Database.Schemas
{
    public class TicketSchema : IUniqueIdentitySchema, ISoftDeleteSchema, IDateTimeSchema
    {
        public string Title { get; set; }
        public TicketStatusType Status { get; set; }
        public TicketSensitivityStatusType sensitivityStatus { get; set; }
        public int? Priority { get; set; }
        public string UniqueIdentity { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
    }
}
