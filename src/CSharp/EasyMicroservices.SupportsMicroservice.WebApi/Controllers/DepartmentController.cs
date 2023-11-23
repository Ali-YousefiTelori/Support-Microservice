using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;



namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class DepartmentController : SimpleQueryServiceController<DepartmentEntity, CreateDepartmentRequestContract, UpdateDepartmentRequestContract, DepartmentContract, long>
    {
        public IUnitOfWork _uow;

        public DepartmentController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }
    }
}
