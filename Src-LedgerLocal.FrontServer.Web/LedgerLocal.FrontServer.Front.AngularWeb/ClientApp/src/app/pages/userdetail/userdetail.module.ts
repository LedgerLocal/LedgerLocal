import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';

import { UserDetailRoutingModule, routedComponents } from './userdetail-routing.module';
import { UserDetailViewComponent } from './userdetail-view/userdetail-view.component';
import { UserDetailComponent } from './userdetail.component';

import { SmartTableService } from '../../@core/data/smart-table.service';
import { UserService } from '../../@core/data/users.service';
import { LayoutInitService } from '../../@core/data/layoutinit';
import { ContentService } from '../../@core/data/contentservice';

@NgModule({
  imports: [
    ThemeModule,
    UserDetailRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    ...routedComponents,
  ],
  providers: [
    SmartTableService,
    LayoutInitService,
    UserService,
    ContentService,
  ],
})
export class UserDetailModule { }
