import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';

import { HomeRoutingModule, routedComponents } from './home-routing.module';
import { HomeViewComponent } from './home-view/home-view.component';
import { HomeComponent } from './home.component';

import { SmartTableService } from '../../@core/data/smart-table.service';
import { LayoutInitService } from '../../@core/data/layoutinit';
import { ContentService } from '../../@core/data/contentservice';

@NgModule({
  imports: [
    ThemeModule,
    HomeRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    ...routedComponents,
  ],
  providers: [
    SmartTableService,
    LayoutInitService,
    ContentService,
  ],
})
export class HomeModule { }
