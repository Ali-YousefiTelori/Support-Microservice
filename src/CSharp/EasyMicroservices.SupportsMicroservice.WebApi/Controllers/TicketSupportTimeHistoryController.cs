using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class TicketSupportTimeHistoryController : SimpleQueryServiceController<TicketSupportTimeHistoryEntity, CreateTicketSupportTimeHistoryRequestContract, UpdateTicketSupportTimeHistoryRequestContract, TicketSupportTimeHistoryContract, long>
    {
        private readonly IContractLogic<TicketSupportTimeHistoryEntity, CreateTicketSupportTimeHistoryRequestContract, UpdateTicketSupportTimeHistoryRequestContract, TicketSupportTimeHistoryContract, long> _contractlogic;
        private readonly IContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long> _ticketlogic;
        public TicketSupportTimeHistoryController(IContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long> ticketlogic , IContractLogic<TicketSupportTimeHistoryEntity, CreateTicketSupportTimeHistoryRequestContract, UpdateTicketSupportTimeHistoryRequestContract, TicketSupportTimeHistoryContract, long> contractLogic) : base(contractLogic)
        {
            _ticketlogic = ticketlogic;
            _contractlogic = contractLogic;
        }
        public override async Task<MessageContract<long>> Add(CreateTicketSupportTimeHistoryRequestContract request, CancellationToken cancellationToken = default)
        {
            var checkTicketId = await _ticketlogic.GetById(new GetIdRequestContract<long>() { Id = request.TicketId });
            if (checkTicketId.IsSuccess)
            return await base.Add(request, cancellationToken);

            return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "TicketId is incorrect");

        }
    }
}
