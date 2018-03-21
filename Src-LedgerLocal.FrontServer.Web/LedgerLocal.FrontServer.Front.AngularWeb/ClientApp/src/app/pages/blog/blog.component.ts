import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'ngx-blog',
  template: `<router-outlet></router-outlet>`,
})
export class BlogComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
