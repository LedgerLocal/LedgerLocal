import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { PagesComponent } from './pages.component';

const routes: Routes = [{
  path: '',
  component: PagesComponent,
  children: [{
    path: 'home',
    loadChildren: './home/home.module#HomeModule',
  }, {
    path: 'userdetail',
    loadChildren: './userdetail/userdetail.module#ServiceModule',
  }, {
      path: 'participate',
      loadChildren: './participate/participate.module#AppointmentModule',
  }, {
    path: 'blog',
    loadChildren: './blog/blog.module#BlogModule',
  }, {
    path: 'contact',
    loadChildren: './contact/contact.module#ContactModule',
  }, {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {
}
