import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';

import { ContactRoutingModule, routedComponents } from './contact-routing.module';
import { ContactViewComponent } from './contact-view/contact-view.component';
import { ContactComponent } from './contact.component';

import { SmartTableService } from '../../@core/data/smart-table.service';
import { LayoutInitService } from '../../@core/data/layoutinit';

@NgModule({
  imports: [
    ThemeModule,
    ContactRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    ...routedComponents,
  ],
  providers: [
    SmartTableService,
    LayoutInitService
  ],
})
export class ContactModule { }
