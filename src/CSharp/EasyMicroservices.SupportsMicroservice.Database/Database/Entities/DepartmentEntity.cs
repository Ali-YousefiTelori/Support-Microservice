using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.SupportsMicroservice.Database.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Database.Entities
{
    public class DepartmentEntity : DepartmentSchema, IIdSchema<long>
    {
        public long Id { get; set; }
        public ICollection<TicketDepartmentEntity> TicketDepartments { get; set; }

    }
}
