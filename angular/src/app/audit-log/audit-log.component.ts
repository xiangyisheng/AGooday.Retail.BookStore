import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { AuditLogService, AuditLogDto } from '@proxy/audit-logs';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';

@Component({
  selector: 'app-audit-log',
  templateUrl: './audit-log.component.html',
  styleUrls: ['./audit-log.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
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

  searchAuditLog() {
    console.log("searchAuditLog");
  }

  viewAuditLog(id: string) {
    console.log("viewAuditLog"+id);
  }
}
