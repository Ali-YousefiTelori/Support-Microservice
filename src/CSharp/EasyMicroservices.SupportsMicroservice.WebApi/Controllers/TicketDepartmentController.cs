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
        private readonly IContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long> _ticketlogic;
        private readonly IContractLogic<DepartmentEntity, CreateDepartmentRequestContract, UpdateDepartmentRequestContract, DepartmentContract, long> _departmentlogic;
        private readonly IContractLogic<TicketDepartmentEntity, CreateTicketDepartmentRequestContract, UpdateTicketDepartmentRequestContract, TicketDepartmentContract, long> _contractlogic;
        public IUnitOfWork _uow;

        public TicketDepartmentController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
            _ticketlogic = uow.GetContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long>();
            _departmentlogic = uow.GetContractLogic<DepartmentEntity, CreateDepartmentRequestContract, UpdateDepartmentRequestContract, DepartmentContract, long>();
            _contractlogic = uow.GetContractLogic<TicketDepartmentEntity, CreateTicketDepartmentRequestContract, UpdateTicketDepartmentRequestContract, TicketDepartmentContract, long>();
        }
        public override async Task<MessageContract<long>> Add(CreateTicketDepartmentRequestContract request, CancellationToken cancellationToken = default)
        {
            var checkTicketId = await _ticketlogic.GetById(new GetIdRequestContract<long>() { Id = request.TicketId });
            var checkDepartmentID = await _departmentlogic.GetById(new GetIdRequestContract<long>() { Id = request.DepartmentId });
            if (checkTicketId.IsSuccess && checkDepartmentID.IsSuccess)
            return await _contractlogic.Add(request, cancellationToken);
            return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "TicketId or DepartmantId is incorrect");
        }
    }
}
