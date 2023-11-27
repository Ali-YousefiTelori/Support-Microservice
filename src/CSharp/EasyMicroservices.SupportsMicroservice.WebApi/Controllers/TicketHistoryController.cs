using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class TicketHistoryController : SimpleQueryServiceController<TicketHistoryEntity, CreateTicketHistoryRequestContract, UpdateTicketHistoryRequestContract, TicketHistoryContract, long>
    {
        public IUnitOfWork _uow;

        public TicketHistoryController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }
        public override async Task<MessageContract<long>> Add(CreateTicketHistoryRequestContract request, CancellationToken cancellationToken = default)
        {
            var _ticketlogic = _uow.GetContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long>();
            var checkTicketId = await _ticketlogic.GetById(new GetIdRequestContract<long>() { Id = request.TicketId });
            if (checkTicketId.IsSuccess)
            return await base.Add(request, cancellationToken);
            return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "TicketId is incorrect");

        }
        public override async Task<MessageContract<TicketHistoryContract>> Update(UpdateTicketHistoryRequestContract request, CancellationToken cancellationToken = default)
        {
            var _ticketlogic = _uow.GetContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long>();
            var checkTicketId = await _ticketlogic.GetById(new GetIdRequestContract<long>() { Id = request.TicketId });
            if (checkTicketId.IsSuccess)
            return await base.Update(request, cancellationToken);
            return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "TicketId is incorrect");

        }
    }
}
