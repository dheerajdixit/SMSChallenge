import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgxPaginationModule } from 'ngx-pagination';
import { OrderModule } from 'ngx-order-pipe';
import { NgxFontAwesomeModule } from 'ngx-font-awesome';
import { NgxDaterangepickerMd } from 'ngx-daterangepicker-material';
import { AuthModule } from '@auth0/auth0-angular';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    Ng2SearchPipeModule,
    NgxPaginationModule,
    HttpClientModule,
    FormsModule,
    OrderModule,
    NgxFontAwesomeModule,
    NgxDaterangepickerMd.forRoot(),
    AuthModule.forRoot({
      domain: 'dev-unab7yv8.us.auth0.com',
      clientId: 'R5lk4TIAghq5OIN89GuKPBBXZUVpPvcU'
    }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
