import { PLATFORM_ID, Component, AfterViewInit, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { LayoutInitService } from '../../service/layoutinit';
import { Http } from '@angular/http';

@Component({
    selector: 'blog',
    templateUrl: './blog.component.html'
})
export class BlogComponent implements AfterViewInit {

    private liServiceLocal: LayoutInitService;
    public articleList: any[];

    constructor(private router: Router, http: Http, @Inject(PLATFORM_ID) private platformId: Object, private liService: LayoutInitService) {
        this.liServiceLocal = liService;

        http.get('/api/getArticles').subscribe(result => {
            this.articleList = result.json() as any[];
        });

    }

    ngAfterViewInit() {

        if (isPlatformBrowser(this.platformId)) {

            this.liServiceLocal.makeInit();
            this.liServiceLocal.goToTop();

        }

    }

    public goToArticlePost(id) {

        this.router.navigateByUrl('/blogpost/' + id);

    }

}
