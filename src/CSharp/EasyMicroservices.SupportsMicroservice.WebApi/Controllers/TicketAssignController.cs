using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class TicketAssignController : SimpleQueryServiceController<TicketAssignEntity, TicketAssignCreateRequestContract, TicketAssignUpdateRequestContract, TicketAssignContract, long>
    {
        public TicketAssignController(IContractLogic<TicketAssignEntity, TicketAssignCreateRequestContract, TicketAssignUpdateRequestContract, TicketAssignContract, long> contractLogic) : base(contractLogic)
        {

        }
    }
}
