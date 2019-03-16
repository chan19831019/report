import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReportFourComponent } from './report-four/report-four.component';
import { ReportFiveComponent } from './report-five/report-five.component';
import { ReportSixComponent } from './report-six/report-six.component';
import { ReportSevenComponent } from './report-seven/report-seven.component';
import { ReportEightComponent } from './report-eight/report-eight.component';
import { ReportNineComponent } from './report-nine/report-nine.component';
import { ReportTenComponent } from './report-ten/report-ten.component';
import { ReportElevenComponent } from './report-eleven/report-eleven.component';
import { ReportTwelveComponent } from './report-twelve/report-twelve.component';
import { ReportThirteenComponent } from './report-thirteen/report-thirteen.component';

@NgModule({
  declarations: [
    AppComponent,
    ReportFourComponent,
    ReportFiveComponent,
    ReportSixComponent,
    ReportSevenComponent,
    ReportEightComponent,
    ReportNineComponent,
    ReportTenComponent,
    ReportElevenComponent,
    ReportTwelveComponent,
    ReportThirteenComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
