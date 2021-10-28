import type { AuditLogDto, GetAuditLogListDto } from './models';
import { PagedResultDto, RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuditLogService {
  apiName = 'Default';

  constructor(private restService: RestService) { }

  getList = (input: GetAuditLogListDto) =>
  this.restService.request<any, PagedResultDto<AuditLogDto>>({
    method: 'GET',
    url: `/api/app/audit-log`,
    params: input,
  },
  { apiName: this.apiName });
}
