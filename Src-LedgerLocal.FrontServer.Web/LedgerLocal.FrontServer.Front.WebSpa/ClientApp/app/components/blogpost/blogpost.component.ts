import { PLATFORM_ID, Component, AfterViewInit, Inject, OnDestroy } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { LayoutInitService } from '../../service/layoutinit';
import { Subscription } from 'rxjs/Subscription';
import { Http } from '@angular/http';
import { Title } from '@angular/platform-browser';

@Component({
    selector: 'blogpost',
    templateUrl: './blogpost.component.html'
})
export class BlogPostComponent implements AfterViewInit, OnDestroy {

    private liServiceLocal: LayoutInitService;
    private id: string;
    private route$: Subscription;
    public articleItem: any;
    public styleImagePost: string;

    constructor(private http: Http, private route: ActivatedRoute, @Inject(PLATFORM_ID) private platformId: Object, private liService: LayoutInitService, private titleService: Title) {
        this.liServiceLocal = liService;

        this.articleItem = {};

        this.route$ = this.route.params.subscribe(
            params => {

                if (params["id"]) {
                    this.http.get('/api/getArticle?id=' + params["id"]).subscribe(result => {
                        this.articleItem = result.json() as any;

                        this.styleImagePost = "url('" + this.articleItem.imagePost + "') center center no-repeat";

                        

                        this.titleService.setTitle(this.articleItem.title);
                    });
                }

            }
        );
    }

    ngAfterViewInit() {

        if (isPlatformBrowser(this.platformId)) {

            this.liServiceLocal.makeInit();
            this.liServiceLocal.goToTop();

        }

    }

    ngOnDestroy() {
        if (this.route$) this.route$.unsubscribe();
    }

}