using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class TicketSupportTimeHistoryController : SimpleQueryServiceController<TicketSupportTimeHistoryEntity, TicketSupportTimeHistoryCreateRequestContract, TicketSupportTimeHistoryUpdateRequestContract, TicketSupportTimeHistoryContract, long>
    {
        public TicketSupportTimeHistoryController(IContractLogic<TicketSupportTimeHistoryEntity, TicketSupportTimeHistoryCreateRequestContract, TicketSupportTimeHistoryUpdateRequestContract, TicketSupportTimeHistoryContract, long> contractLogic) : base(contractLogic)
        {

        }
    }
}
