/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CoreModule } from './@core/core.module';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ThemeModule } from './@theme/theme.module';
import { AuthModule, OidcSecurityService, OidcConfigService, OpenIDImplicitFlowConfiguration, AuthWellKnownEndpoints } from 'angular-auth-oidc-client';
import { ToastModule } from 'ng2-toastr/ng2-toastr';

import { ContentService } from './@core/data/contentservice';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    
    ThemeModule.forRoot(),
    CoreModule.forRoot(),
    ToastModule.forRoot(),
    AuthModule.forRoot(),
  ],
  bootstrap: [AppComponent],
  providers: [
    
    { provide: APP_BASE_HREF, useValue: '/' },
    OidcConfigService,
    ContentService,
  ],
})
export class AppModule {


  constructor(private oidcSecurityService: OidcSecurityService,
    private oidcConfigService: OidcConfigService) {

    const openIDImplicitFlowConfiguration = new OpenIDImplicitFlowConfiguration();

    openIDImplicitFlowConfiguration.stsServer = 'https://identity.ledgerlocal.com';
    openIDImplicitFlowConfiguration.redirect_url = 'https://www.ledgerlocal.com/#/pages/userdetail#';
    // The Client MUST validate that the aud (audience) Claim contains its client_id value registered at the Issuer identified by the iss (issuer) Claim as an audience.
    // The ID Token MUST be rejected if the ID Token does not list the Client as a valid audience, or if it contains additional audiences not trusted by the Client.
    openIDImplicitFlowConfiguration.client_id = 'ledgerlocal.web';
    openIDImplicitFlowConfiguration.response_type = 'id_token token';
    openIDImplicitFlowConfiguration.scope = 'openid profile offline_access api.main';

    openIDImplicitFlowConfiguration.start_checksession = false;
    openIDImplicitFlowConfiguration.silent_renew = true;
    openIDImplicitFlowConfiguration.silent_renew_offset_in_seconds = 60;
    //openIDImplicitFlowConfiguration.post_login_route = '/userdetail#';
    // HTTP 403
    openIDImplicitFlowConfiguration.forbidden_route = '/forbidden';
    // HTTP 401
    openIDImplicitFlowConfiguration.unauthorized_route = '/unauthorized';
    openIDImplicitFlowConfiguration.auto_userinfo = true;
    openIDImplicitFlowConfiguration.log_console_warning_active = true;
    openIDImplicitFlowConfiguration.log_console_debug_active = true;
    // id_token C8: The iat Claim can be used to reject tokens that were issued too far away from the current time,
    // limiting the amount of time that nonces need to be stored to prevent attacks.The acceptable range is Client specific.
    openIDImplicitFlowConfiguration.max_id_token_iat_offset_allowed_in_seconds = 10;

    const authWellKnownEndpoints = new AuthWellKnownEndpoints();
    authWellKnownEndpoints.issuer = 'https://identity.ledgerlocal.com';

    authWellKnownEndpoints.jwks_uri = 'https://identity.ledgerlocal.com/.well-known/openid-configuration/jwks';
    authWellKnownEndpoints.authorization_endpoint = 'https://identity.ledgerlocal.com/connect/authorize';
    authWellKnownEndpoints.token_endpoint = 'https://identity.ledgerlocal.com/connect/token';
    authWellKnownEndpoints.userinfo_endpoint = 'https://identity.ledgerlocal.com/connect/userinfo';
    authWellKnownEndpoints.end_session_endpoint = 'https://identity.ledgerlocal.com/connect/endsession';
    authWellKnownEndpoints.check_session_iframe = 'https://identity.ledgerlocal.com/connect/checksession';
    authWellKnownEndpoints.revocation_endpoint = 'https://identity.ledgerlocal.com/connect/revocation';
    authWellKnownEndpoints.introspection_endpoint = 'https://identity.ledgerlocal.com/connect/introspect';

    this.oidcSecurityService.setupModule(openIDImplicitFlowConfiguration, authWellKnownEndpoints);

  }
}
