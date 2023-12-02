using Contents.GeneratedServices;
using EasyMicroservices.ContentsMicroservice.Clients.Attributes;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Contracts.Requests
{
    public class CreateDepartmentRequestContract
    {
        [ContentLanguage(nameof(DepartmentContract.Title))]
        public List<Common.LanguageDataContract> Title { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
