using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.SupportsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.SupportsMicroservice.Contracts.Common
{
    public class TiketCotract : IUniqueIdentitySchema, ISoftDeleteSchema, IDateTimeSchema
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public StatusType Status { get; set; }
        public SensitivityStatusType sensitivityStatus { get; set; }
        public int? Priority { get; set; }
        public string UniqueIdentity { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
    }
}
