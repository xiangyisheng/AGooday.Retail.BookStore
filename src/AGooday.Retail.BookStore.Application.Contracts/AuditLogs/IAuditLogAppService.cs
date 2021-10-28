using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AGooday.Retail.BookStore.AuditLogs
{
    public interface IAuditLogAppService : IApplicationService
    {
        /// <summary>
        /// 分页查询审计日志
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<AuditLogPageListOutputDto>> GetListAsync(AuditLogPageListInputDto input);
    }
}
