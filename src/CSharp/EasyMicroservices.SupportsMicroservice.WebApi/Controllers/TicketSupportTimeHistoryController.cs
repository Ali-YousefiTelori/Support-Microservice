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
    public class TicketSupportTimeHistoryController : SimpleQueryServiceController<TicketSupportTimeHistoryEntity, CreateTicketSupportTimeHistoryRequestContract, UpdateTicketSupportTimeHistoryRequestContract, TicketSupportTimeHistoryContract, long>
    {
        public IUnitOfWork _uow;

        public TicketSupportTimeHistoryController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }
    }
}
