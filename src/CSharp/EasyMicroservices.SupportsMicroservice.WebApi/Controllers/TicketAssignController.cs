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
    public class TicketAssignController : SimpleQueryServiceController<TicketAssignEntity, CreateTicketAssignRequestContract, UpdateTicketAssignRequestContract, TicketAssignContract, long>
    {
        public IUnitOfWork _uow;

        public TicketAssignController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }
        public override async Task<MessageContract<long>> Add(CreateTicketAssignRequestContract request, CancellationToken cancellationToken = default)
        {
            var _ticketlogic = _uow.GetContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long>();
            var _contractlogic = _uow.GetContractLogic<TicketAssignEntity, CreateTicketAssignRequestContract, UpdateTicketAssignRequestContract, TicketAssignContract, long>();
            var checkTicketId = await _ticketlogic.GetById(new GetIdRequestContract<long>(){ Id = request.TicketId});
            if (checkTicketId.IsSuccess)
            return await _contractlogic.Add(request, cancellationToken);
            return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "TicketId is incorrect");
        }
        public override async Task<MessageContract<TicketAssignContract>> Update(UpdateTicketAssignRequestContract request, CancellationToken cancellationToken = default)
        {
            var _ticketlogic = _uow.GetContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long>();
            var _contractlogic = _uow.GetContractLogic<TicketAssignEntity, CreateTicketAssignRequestContract, UpdateTicketAssignRequestContract, TicketAssignContract, long>();
            var checkTicketId = await _ticketlogic.GetById(new GetIdRequestContract<long>() { Id = request.TicketId });
            if (checkTicketId.IsSuccess)
            return await _contractlogic.Update(request, cancellationToken);
            return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "TicketId is incorrect");
        }
    }
}
