import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { AuditLogService, AuditLogDto } from '@proxy/auditLogs';

@Component({
  selector: 'app-audit-log',
  templateUrl: './audit-log.component.html',
  styleUrls: ['./audit-log.component.scss']
})
export class AuditLogComponent implements OnInit {
  auditLog = { items: [], totalCount: 0 } as PagedResultDto<AuditLogDto>;

  constructor(
      public readonly list: ListService,
      private auditLogService: AuditLogService
    ) { }

  ngOnInit() : void {
    console.log("ngOnInit");
    const authorStreamCreator = (query) => this.auditLogService.getList(query);

    this.list.hookToQuery(authorStreamCreator).subscribe((response) => {
      this.auditLog = response;
    });
  }

  queryAuditLog() {
    console.log("queryAuditLog");
  }

  viewAuditLog(id: string) {
    console.log("viewAuditLog"+id);
  }
}
