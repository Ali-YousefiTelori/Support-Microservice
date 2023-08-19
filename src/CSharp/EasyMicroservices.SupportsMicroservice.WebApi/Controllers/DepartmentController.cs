using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class DepartmentController : SimpleQueryServiceController<DepartmentEntity, CreateDepartmentRequestContract, UpdateDepartmentRequestContract, DepartmentContract, long>
    {
        public DepartmentController(IContractLogic<DepartmentEntity, CreateDepartmentRequestContract, UpdateDepartmentRequestContract, DepartmentContract, long> contractLogic) : base(contractLogic)
        {

        }
    }
}
