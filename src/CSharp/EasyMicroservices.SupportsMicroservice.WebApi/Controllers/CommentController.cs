using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.SupportsMicroservice.Contracts.Common;
using EasyMicroservices.SupportsMicroservice.Database.Entities;

namespace EasyMicroservices.SupportsMicroservice.WebApi.Controllers
{
    public class SupportController : SimpleQueryServiceController<SupportEntity, SupportContract, SupportContract, SupportContract, long>
    {
        public SupportController(IContractLogic<SupportEntity, SupportContract, SupportContract, SupportContract, long> contractReadable) : base(contractReadable)
        {

        }
    }
}
