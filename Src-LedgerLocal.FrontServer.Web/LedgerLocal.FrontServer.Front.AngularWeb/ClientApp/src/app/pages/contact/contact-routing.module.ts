import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContactComponent } from './contact.component';
import { ContactViewComponent } from './contact-view/contact-view.component';

const routes: Routes = [{
  path: '',
  component: ContactComponent,
  children: [{
    path: 'contact-view',
    component: ContactViewComponent,
  }, {
    path: '',
    redirectTo: 'contact-view',
    pathMatch: 'full',
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ContactRoutingModule { }

export const routedComponents = [
  ContactComponent,
  ContactViewComponent,
];
