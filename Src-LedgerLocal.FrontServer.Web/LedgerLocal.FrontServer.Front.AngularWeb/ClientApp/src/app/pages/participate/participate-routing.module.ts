import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ParticipateComponent } from './participate.component';
import { ParticipateViewComponent } from './participate-view/participate-view.component';

const routes: Routes = [{
  path: '',
  component: ParticipateComponent,
  children: [{
    path: 'participate-view',
    component: ParticipateViewComponent,
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
export class ParticipateRoutingModule { }

export const routedComponents = [
  ParticipateComponent,
  ParticipateViewComponent,
];
