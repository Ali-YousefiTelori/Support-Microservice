using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class TicketHistoryController : SimpleQueryServiceController<TicketHistoryEntity, TicketHistoryCreateRequestContract, TicketHistoryUpdateRequestContract, TicketHistoryContract, long>
    {
        public TicketHistoryController(IContractLogic<TicketHistoryEntity, TicketHistoryCreateRequestContract, TicketHistoryUpdateRequestContract, TicketHistoryContract, long> contractLogic) : base(contractLogic)
        {

        }
    }
}
