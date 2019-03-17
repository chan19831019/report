import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Report4Component } from './report4/report4.component';
import { Report5Component } from './report5/report5.component';
import { Report6Component } from './report6/report6.component';
import { Report7Component } from './report7/report7.component';
import { Report8Component } from './report8/report8.component';
import { Report9Component } from './report9/report9.component';
import { Report10Component } from './report10/report10.component';
import { Report11Component } from './report11/report11.component';
import { Report12Component } from './report12/report12.component';
import { Report13Component } from './report13/report13.component';
import { Report14Component } from './report14/report14.component';
import { Report15Component } from './report15/report15.component';
import { Report16Component } from './report16/report16.component';


@NgModule({
  declarations: [
    AppComponent,
    Report4Component,
    Report5Component,
    Report6Component,
    Report7Component,
    Report8Component,
    Report9Component,
    Report10Component,
    Report11Component,
    Report12Component,
    Report13Component,
    Report14Component,
    Report15Component,
    Report16Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
