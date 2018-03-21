import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home.component';
import { HomeViewComponent } from './home-view/home-view.component';

const routes: Routes = [{
  path: '',
  component: HomeComponent,
  children: [{
    path: 'home-view',
    component: HomeViewComponent,
  }, {
      path: '',
      redirectTo: 'home-view',
      pathMatch: 'full',
    }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule { }

export const routedComponents = [
  HomeComponent,
  HomeViewComponent,
];
