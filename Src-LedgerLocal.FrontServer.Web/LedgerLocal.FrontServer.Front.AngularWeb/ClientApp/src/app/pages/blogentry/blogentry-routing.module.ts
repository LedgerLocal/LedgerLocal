import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BlogentryComponent } from './blogentry.component';
import { BlogentryViewComponent } from './blogentry-view/blogentry-view.component';

const routes: Routes = [{
  path: '',
  component: BlogentryComponent,
  children: [{
    path: 'blogentry-view',
    component: BlogentryViewComponent,
  }, {
    path: '',
    redirectTo: 'blogentry-view',
    pathMatch: 'full',
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BlogentryRoutingModule { }

export const routedComponents = [
  BlogentryComponent,
  BlogentryViewComponent,
];
