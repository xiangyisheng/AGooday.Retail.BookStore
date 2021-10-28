import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AuditLogDto extends EntityDto<string> {
  UserName?: string;
  HttpMethod?: string;
  HttpStatusCode?: string;
  Url?: string;
  ExecutionTime?: string;
}

export interface GetAuditLogListDto extends PagedAndSortedResultRequestDto {
  UserName?: string;
}
