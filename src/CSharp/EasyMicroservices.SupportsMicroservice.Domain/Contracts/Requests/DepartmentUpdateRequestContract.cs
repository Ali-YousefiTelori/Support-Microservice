using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Contracts.Requests
{
    public class DepartmentUpdateRequestContract
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
