using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class TicketDepartmentController : SimpleQueryServiceController<TicketDepartmentEntity, TicketDepartmentCreateRequestContract, TicketDepartmentUpdateRequestContract, TicketDepartmentContract, long>
    {
        public TicketDepartmentController(IContractLogic<TicketDepartmentEntity, TicketDepartmentCreateRequestContract, TicketDepartmentUpdateRequestContract, TicketDepartmentContract, long> contractLogic) : base(contractLogic)
        {

        }
    }
}
