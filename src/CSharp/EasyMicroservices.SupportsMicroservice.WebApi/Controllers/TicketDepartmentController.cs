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
    public class TicketDepartmentController : SimpleQueryServiceController<TicketDepartmentEntity, CreateTicketDepartmentRequestContract, UpdateTicketDepartmentRequestContract, TicketDepartmentContract, long>
    {
        public IUnitOfWork _uow;

        public TicketDepartmentController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }
        public override async Task<MessageContract<long>> Add(CreateTicketDepartmentRequestContract request, CancellationToken cancellationToken = default)
        {
            var _ticketlogic = _uow.GetContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long>();
            var _departmentlogic = _uow.GetContractLogic<DepartmentEntity, CreateDepartmentRequestContract, UpdateDepartmentRequestContract, DepartmentContract, long>();
            var checkTicketId = await _ticketlogic.GetById(new GetIdRequestContract<long>() { Id = request.TicketId });
            var checkDepartmentId = await _departmentlogic.GetById(new GetIdRequestContract<long>() { Id = request.DepartmentId });
            if (checkTicketId.IsSuccess && checkDepartmentId.IsSuccess)
            return await base.Add(request, cancellationToken);
            return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "TicketId or DepartmantId is incorrect");
        }
    }
}
