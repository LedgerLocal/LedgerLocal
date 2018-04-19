import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';

import { ParticipateRoutingModule, routedComponents } from './participate-routing.module';
import { ParticipateViewComponent } from './participate-view/participate-view.component';
import { ParticipateComponent } from './participate.component';

import { SmartTableService } from '../../@core/data/smart-table.service';
import { UserService } from '../../@core/data/users.service';
import { LayoutInitService } from '../../@core/data/layoutinit';

@NgModule({
  imports: [
    ThemeModule,
    ParticipateRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    ...routedComponents,
  ],
  providers: [
    SmartTableService,
    LayoutInitService,
    UserService
  ],
})
export class ParticipateModule { }
