using EasyMicroservices.Cores.AspCoreApi;
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

        public TicketDepartmentController(IContractLogic<DepartmentEntity, CreateDepartmentRequestContract, UpdateDepartmentRequestContract, DepartmentContract, long> departmentlogic,IContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long> ticketlogic,IContractLogic<TicketDepartmentEntity, CreateTicketDepartmentRequestContract, UpdateTicketDepartmentRequestContract, TicketDepartmentContract, long> contractLogic) : base(contractLogic)
        {
            _ticketlogic = ticketlogic;
            _departmentlogic = departmentlogic;
            _contractlogic = contractLogic;
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
