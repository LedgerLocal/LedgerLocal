import { Component, OnDestroy, OnInit, AfterViewInit, AfterViewChecked } from '@angular/core';
import { SmartTableService } from '../../../@core/data/smart-table.service';
import { LayoutInitService } from '../../../@core/data/layoutinit';
import { DomSanitizer, SafeResourceUrl, SafeUrl, SafeStyle } from '@angular/platform-browser';
import { ContentService } from '../../../@core/data/contentservice';

@Component({
  selector: 'ngx-blog-view',
  templateUrl: './blog-view.component.html',
  styleUrls: ['./blog-view.component.scss']
})
export class BlogViewComponent implements OnInit, AfterViewInit {

  public contentBlockList: any;

  constructor(private stService: SmartTableService,
    private loService: LayoutInitService,
    private userService: ContentService,
    private sanitization: DomSanitizer) {
  }

  ngOnInit() {
    this.userService.initContentList();
    this.userService.getContentList()
      .subscribe((cb: any) => {
        this.contentBlockList = cb;
      });
  }

  ngAfterViewInit() {
    this.loService.makeInit();
    this.loService.scrollToTop();
  }

}
