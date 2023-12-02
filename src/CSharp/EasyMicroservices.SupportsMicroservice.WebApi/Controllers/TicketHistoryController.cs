using EasyMicroservices.ContentsMicroservice.Clients.Helpers;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.OrderingMicroservice.Contracts.Common;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class TicketHistoryController : SimpleQueryServiceController<TicketHistoryEntity, CreateTicketHistoryRequestContract, UpdateTicketHistoryRequestContract, TicketHistoryContract, long>
    {
        private readonly IConfiguration _config;
        readonly IUnitOfWork _uow;
        private readonly ContentLanguageHelper _contentHelper;
        public TicketHistoryController(IUnitOfWork uow ,IConfiguration config) : base(uow)
        {
            _uow = uow;
            _config = config;
            _contentHelper = new(new Contents.GeneratedServices.ContentClient(_config.GetValue<string>("RootAddresses:Content"), new HttpClient()));
        }
        public override async Task<MessageContract<long>> Add(CreateTicketHistoryRequestContract request, CancellationToken cancellationToken = default)
        {
            var result = await base.Add(request, cancellationToken);
            if (result)
            {
                var addedItem = await GetById(new Cores.Contracts.Requests.GetIdRequestContract<long> { Id = result.Result });
                request.UniqueIdentity = addedItem.Result.UniqueIdentity;

                var addContent = await _contentHelper.AddToContentLanguage(request);
                if (!addContent.IsSuccess)
                    return addContent.ToContract<long>();
            }
            return result;
        }
        public override async Task<MessageContract<TicketHistoryContract>> Update(UpdateTicketHistoryRequestContract request, CancellationToken cancellationToken = default)
        {
            var addedItem = await GetById(new Cores.Contracts.Requests.GetIdRequestContract<long> { Id = request.Id });
            if (addedItem)
            {
                request.UniqueIdentity = addedItem.Result.UniqueIdentity;
                var result = await base.Update(request, cancellationToken);
                if (result)
                {
                    var updateToContent = await _contentHelper.UpdateToContentLanguage(request);
                    if (!updateToContent.IsSuccess)
                        return updateToContent.ToContract<TicketHistoryContract>();
                }
                return result;
            }
            return addedItem.ToContract<TicketHistoryContract>();
        }
        [HttpPost]
        public async Task<MessageContract<TicketHistoryLanguageContract>> GetByIdAllLanguage(GetIdRequestContract<long> request)
        {
            var result = await base.GetById(request.Id);
            if (result)
            {
                var mapped = _uow.GetMapper().Map<TicketHistoryLanguageContract>(result.Result);
                await _contentHelper.ResolveContentAllLanguage(mapped);
                return mapped;
            }
            return result.ToContract<TicketHistoryLanguageContract>();
        }
        [HttpPost]
        public async Task<ListMessageContract<TicketHistoryContract>> GetAllByLanguage(Contracts.Requests.GetByLanguageRequestContract getByLanguage, CancellationToken cancellationToken = default)
        {
            var result = await base.GetAll(cancellationToken);
            if (result)
            {
                await _contentHelper.ResolveContentLanguage(result.Result, getByLanguage.Language);
            }
            return result;
        }
    }
}
