using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class DepartmentController : SimpleQueryServiceController<DepartmentEntity, DepartmentCreateRequestContract, DepartmentUpdateRequestContract, DepartmentContract, long>
    {
        public DepartmentController(IContractLogic<DepartmentEntity, DepartmentCreateRequestContract, DepartmentUpdateRequestContract, DepartmentContract, long> contractLogic) : base(contractLogic)
        {

        }
    }
}
