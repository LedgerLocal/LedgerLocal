import { Component, OnInit } from '@angular/core';
import { ContentService } from '../../@core/data/contentservice';

@Component({
  selector: 'ngx-home',
  template: `<router-outlet></router-outlet>`,
})
export class HomeComponent implements OnInit {

  constructor(private conS: ContentService) { }

  ngOnInit() {
    this.conS.initContentList();
  }

}
