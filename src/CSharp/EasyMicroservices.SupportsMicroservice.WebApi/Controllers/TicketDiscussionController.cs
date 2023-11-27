using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;
using System.Runtime.CompilerServices;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class TicketDiscussionController : SimpleQueryServiceController<TicketDiscussionEntity, CreateTicketDiscussionRequestContract, UpdateTicketDiscussionRequestContract, TicketDiscussionContract, long>
    {
        public IUnitOfWork _uow;

        public TicketDiscussionController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }
        public override async Task<MessageContract<long>> Add(CreateTicketDiscussionRequestContract request, CancellationToken cancellationToken = default)
        {
            var _ticketlogic = _uow.GetContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long>();
            var ticketId = await _ticketlogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long> { Id = request.TicketId});
            if (ticketId.IsSuccess)
                return await base.Add(request, cancellationToken);
            return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "TicketId is incorrect");
        }
        public override async Task<MessageContract<TicketDiscussionContract>> Update(UpdateTicketDiscussionRequestContract request, CancellationToken cancellationToken = default)
        {
            var _ticketlogic = _uow.GetContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long>();
            var ticketId = await _ticketlogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long> { Id = request.TicketId });
            if (ticketId.IsSuccess)
                return await base.Update(request, cancellationToken);
            return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "TicketId is incorrect");
        }
    }
}
