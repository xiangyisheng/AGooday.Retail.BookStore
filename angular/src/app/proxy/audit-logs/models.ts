import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AuditLogDto extends EntityDto<string> {
  applicationName?: string;
  userId?: string;
  userName?: string;
  tenantId?: string;
  tenantName?: string;
  executionTime?: string;
  executionDuration?: string;
  clientIpAddress?: string;
  browserInfo?: string;
  httpMethod?: string;
  url?: string;
  exceptions?: string;
  comments?: string;
  httpStatusCode?: number;
}

export interface GetAuditLogListDto extends PagedAndSortedResultRequestDto {
  startTime?: string;
  endTime?: string;
  httpMethod?: string;
  url?: string;
  userName?: string;
  applicationName?: string;
  correlationId?: string;
  maxExecutionDuration?: number;
  minExecutionDuration?: number;
  hasException?: boolean;
  httpStatusCode?: number;
}
