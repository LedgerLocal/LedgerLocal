import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ServiceComponent } from './userdetail.component';
import { ServiceViewComponent } from './userdetail-view/userdetail-view.component';

const routes: Routes = [{
  path: '',
  component: ServiceComponent,
  children: [{
    path: 'service-view',
    component: ServiceViewComponent,
  }, {
    path: '',
    redirectTo: 'service-view',
    pathMatch: 'full',
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ServiceRoutingModule { }

export const routedComponents = [
  ServiceComponent,
  ServiceViewComponent,
];
