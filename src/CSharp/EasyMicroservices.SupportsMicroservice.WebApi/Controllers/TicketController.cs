using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class TicketController : SimpleQueryServiceController<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long>
    {
        private readonly IContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long> _contractlogic;
        public IUnitOfWork _uow;


        public TicketController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
            _contractlogic = uow.GetContractLogic<TicketEntity, CreateTicketRequestContract, UpdateTicketRequestContract, TicketContract, long>();

        }
    }
}
