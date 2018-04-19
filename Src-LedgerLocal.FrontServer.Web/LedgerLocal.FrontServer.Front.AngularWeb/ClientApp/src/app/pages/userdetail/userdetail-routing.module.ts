import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserDetailComponent } from './userdetail.component';
import { UserDetailViewComponent } from './userdetail-view/userdetail-view.component';

const routes: Routes = [{
  path: '',
  component: UserDetailComponent,
  children: [{
    path: 'userdetail-view',
    component: UserDetailViewComponent,
  }, {
    path: '',
    redirectTo: 'userdetail-view',
    pathMatch: 'full',
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserDetailRoutingModule { }

export const routedComponents = [
  UserDetailComponent,
  UserDetailViewComponent,
];
