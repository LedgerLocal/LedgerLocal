import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';

import { HomeComponent } from './components/home/home.component';
import { InvestComponent } from './components/invest/invest.component';
import { ContactComponent } from './components/contact/contact.component';

import { BlogComponent } from './components/blog/blog.component';
import { BlogPostComponent } from './components/blogpost/blogpost.component';

import { BlockchainComponent } from './components/blockchain/blockchain.component';

import { MapsComponent } from './components/maps/maps.component';

import { FaqComponent } from './components/faq/faq.component';
import { TermsComponent } from './components/terms/terms.component';
import { UserProfilComponent } from './components/userprofil/userprofil.component';
import { UserWalletComponent } from './components/userwallet/userwallet.component';

import { NotFoundComponent } from './components/notfound/notfound.component';
import { NotFoundBisComponent } from './components/notfoundbis/notfoundbis.component';

import { ForbiddenComponent } from './components/forbidden/forbidden.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,

        HomeComponent,
        InvestComponent,
        ContactComponent,

        BlogComponent,
        BlogPostComponent,

        BlockchainComponent,

        MapsComponent,

        TermsComponent,
        FaqComponent,
 
        UserProfilComponent,
        UserWalletComponent,

        NotFoundComponent,
        NotFoundBisComponent,

        ForbiddenComponent,
        UnauthorizedComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'invest', component: InvestComponent },
            { path: 'contact', component: ContactComponent },

            { path: 'blog', component: BlogComponent },
            { path: 'blogpost/:id', component: BlogPostComponent },

            { path: 'blockchain', component: BlockchainComponent },

            { path: 'maps', component: MapsComponent },

            { path: 'terms', component: TermsComponent },
            { path: 'faq', component: FaqComponent },
            
            { path: 'userprofil', component: UserProfilComponent },
            { path: 'userwallet', component: UserWalletComponent },

            { path: 'notfound', component: NotFoundComponent },
            { path: 'notfoundbis', component: NotFoundBisComponent },
            { path: 'forbidden', component: ForbiddenComponent },
            { path: 'unauthorized', component: UnauthorizedComponent },

            { path: '**', redirectTo: 'home' }
        ])
    ]
};
