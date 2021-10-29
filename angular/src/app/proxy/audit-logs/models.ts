import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AuditLogDto extends EntityDto<string> {
  userName?: string;
  httpMethod?: string;
  httpStatusCode?: string;
  url?: string;
  executionTime?: string;
}

export interface GetAuditLogListDto extends PagedAndSortedResultRequestDto {
  StartTime?: string;
  EndTime?: string;
  HttpMethod?: string;
  Url?: string;
  userName?: string;
  ApplicationName?: string;
  CorrelationId?: string;
  MaxExecutionDuration?: number;
  MinExecutionDuration?: number;
  HasException?: boolean;
  HttpStatusCode?: number;
}
