using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AuditLogging;

namespace AGooday.Retail.BookStore.AuditLogs
{
    public class AuditLogAppService : BookStoreAppService, IAuditLogAppService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogAppService(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        /// <summary>
        /// 分页查询审计日志
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<AuditLogPageListOutputDto>> GetListAsync(AuditLogPageListInputDto input)
        {
            var list = await _auditLogRepository.GetListAsync(
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount,
                input.StartTime?.Date,
                input.EndTime?.Date,
                input.HttpMethod,
                input.Url,
                null,
                input.UserName,
                input.ApplicationName,
                input.CorrelationId,
                input.MaxExecutionDuration,
                input.MinExecutionDuration,
                input.HasException,
                input.HttpStatusCode);
            var totalCount = await _auditLogRepository.GetCountAsync(
                input.StartTime?.Date,
                input.EndTime?.Date,
                input.HttpMethod,
                input.Url,
                null,
                input.UserName,
                input.ApplicationName,
                input.CorrelationId,
                input.MaxExecutionDuration,
                input.MinExecutionDuration,
                input.HasException,
                input.HttpStatusCode);
            return new PagedResultDto<AuditLogPageListOutputDto>(
                totalCount,
                ObjectMapper.Map<List<AuditLog>, List<AuditLogPageListOutputDto>>(list));
        }
    }
}
