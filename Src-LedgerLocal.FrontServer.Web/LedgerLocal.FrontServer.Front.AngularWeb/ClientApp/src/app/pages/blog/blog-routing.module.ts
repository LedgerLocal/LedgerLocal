import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BlogComponent } from './blog.component';
import { BlogViewComponent } from './blog-view/blog-view.component';

const routes: Routes = [{
  path: '',
  component: BlogComponent,
  children: [{
    path: 'blog-view',
    component: BlogViewComponent,
  }, {
    path: '',
    redirectTo: 'blog-view',
    pathMatch: 'full',
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BlogRoutingModule { }

export const routedComponents = [
  BlogComponent,
  BlogViewComponent,
];
