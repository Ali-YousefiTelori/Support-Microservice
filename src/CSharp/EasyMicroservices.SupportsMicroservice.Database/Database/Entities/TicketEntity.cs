﻿using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.SupportsMicroservice.Database.Schemas;
using EasyMicroservices.SupportsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Database.Entities
{
    public class TicketEntity : TicketSchema, IIdSchema<long>
    {
        public long Id { get; set; }
        public ICollection<TicketHistoryEntity> TicketHistory { get; set; }
        public ICollection<TicketDepartmentEntity> TicketDepartment { get; set; }
    }
}
