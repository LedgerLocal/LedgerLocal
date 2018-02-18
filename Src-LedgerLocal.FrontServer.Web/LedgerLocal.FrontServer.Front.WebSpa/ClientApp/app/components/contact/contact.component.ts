import { PLATFORM_ID, Component, AfterViewInit, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { LayoutInitService } from '../../service/layoutinit';

@Component({
    selector: 'contact',
    templateUrl: './contact.component.html'
})
export class ContactComponent implements AfterViewInit {

    private liServiceLocal: LayoutInitService;

    constructor( @Inject(PLATFORM_ID) private platformId: Object, private liService: LayoutInitService) {
        this.liServiceLocal = liService;
    }

    ngAfterViewInit() {

        if (isPlatformBrowser(this.platformId)) {

            this.liServiceLocal.makeInit();
            this.liServiceLocal.goToTop();

        }

    }

}