using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace AGooday.Retail.BookStore.AuditLogs
{
    public class EntityChangeDto : EntityDto<Guid>
    {
        public Guid AuditLogId { get; set; }

        public Guid? TenantId { get; set; }

        public virtual DateTime ChangeTime { get; set; }

        public EntityChangeType ChangeType { get; set; }

        public Guid? EntityTenantId { get; set; }

        public string EntityId { get; set; }

        public string EntityTypeFullName { get; set; }

        public ICollection<EntityPropertyChangeDto> PropertyChanges { get; set; }

        public Dictionary<string, object> ExtraProperties { get; set; }
    }
}
