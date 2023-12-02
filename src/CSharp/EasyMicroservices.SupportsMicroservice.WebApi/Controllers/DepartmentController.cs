using EasyMicroservices.ContentsMicroservice.Clients.Helpers;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.OrderingMicroservice.Contracts.Common;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Contracts.Requests;
using EasyMicroservices.SupportsMicroservice.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class DepartmentController : SimpleQueryServiceController<DepartmentEntity, CreateDepartmentRequestContract, UpdateDepartmentRequestContract, DepartmentContract, long>
    {
        private readonly IConfiguration _config;
        readonly IUnitOfWork _uow;
        private readonly ContentLanguageHelper _contentHelper;



        public DepartmentController(IUnitOfWork uow, IConfiguration config) : base(uow)
        {
            _uow = uow;
            _config = config;
            _contentHelper = new(new Contents.GeneratedServices.ContentClient(_config.GetValue<string>("RootAddresses:Content"), new HttpClient()));
        }
        public override async Task<MessageContract<long>> Add(CreateDepartmentRequestContract request, CancellationToken cancellationToken = default)
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
        public override async Task<MessageContract<DepartmentContract>> Update(UpdateDepartmentRequestContract request, CancellationToken cancellationToken = default)
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
                        return updateToContent.ToContract<DepartmentContract>();
                }
                return result;
            }
            return addedItem.ToContract<DepartmentContract>();
        }
        [HttpPost]
        public async Task<MessageContract<DepartmentLanguageContract>> GetByIdAllLanguage(GetIdRequestContract<long> request)
        {
            var result = await base.GetById(request.Id);
            if (result)
            {
                var mapped = _uow.GetMapper().Map<DepartmentLanguageContract>(result.Result);
                await _contentHelper.ResolveContentAllLanguage(mapped);
                return mapped;
            }
            return result.ToContract<DepartmentLanguageContract>();
        }
        [HttpPost]
        public async Task<ListMessageContract<DepartmentContract>> GetAllByLanguage(Contracts.Requests.GetByLanguageRequestContract getByLanguage, CancellationToken cancellationToken = default)
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
