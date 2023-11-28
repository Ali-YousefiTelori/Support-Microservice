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
    }
}
