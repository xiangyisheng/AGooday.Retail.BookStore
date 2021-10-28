import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { AuditLogRoutingModule } from './audit-log-routing.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { AuditLogComponent } from './audit-log.component';

@NgModule({
  imports: [SharedModule, AuditLogRoutingModule, NgbDatepickerModule],
  declarations: [AuditLogComponent]
})
export class AuditLogModule { }
