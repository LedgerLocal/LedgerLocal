import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppointmentComponent } from './participate.component';
import { AppointmentViewComponent } from './participate-view/participate-view.component';

const routes: Routes = [{
  path: '',
  component: AppointmentComponent,
  children: [{
    path: 'appointment-view',
    component: AppointmentViewComponent,
  }, {
    path: '',
    redirectTo: 'appointment-view',
    pathMatch: 'full',
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AppointmentRoutingModule { }

export const routedComponents = [
  AppointmentComponent,
  AppointmentViewComponent,
];
