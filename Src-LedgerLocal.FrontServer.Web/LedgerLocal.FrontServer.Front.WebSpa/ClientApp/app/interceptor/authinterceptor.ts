﻿import { Injectable, Injector } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/observable';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    private oidcSecurityService: OidcSecurityService;

    constructor(private injector: Injector) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let requestToForward = req;

        if (this.oidcSecurityService === undefined) {
            this.oidcSecurityService = this.injector.get(OidcSecurityService);
        }
        if (this.oidcSecurityService !== undefined) {
            let token = this.oidcSecurityService.getToken();
            if (token !== "") {
                let tokenValue = "Bearer " + token;
                requestToForward = req.clone({ setHeaders: { "Authorization": tokenValue } });
            }
        } else {
            console.debug("OidcSecurityService undefined: NO auth header!");
        }

        return next.handle(requestToForward);
    }
}