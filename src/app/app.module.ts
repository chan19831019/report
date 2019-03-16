import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReportFourComponent } from './report-four/report-four.component';
import { ReportFiveComponent } from './report-five/report-five.component';
import { ReportSixComponent } from './report-six/report-six.component';

@NgModule({
  declarations: [
    AppComponent,
    ReportFourComponent,
    ReportFiveComponent,
    ReportSixComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
