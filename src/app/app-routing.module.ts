import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReportFourComponent } from './report-four/report-four.component';
import { ReportFiveComponent } from './report-five/report-five.component';
import { ReportSixComponent } from './report-six/report-six.component';
import { ReportSevenComponent } from './report-seven/report-seven.component';
import { ReportEightComponent } from './report-eight/report-eight.component';
import { ReportNineComponent } from './report-nine/report-nine.component';
import { ReportTenComponent } from './report-ten/report-ten.component';
import { ReportElevenComponent } from './report-eleven/report-eleven.component';
import { ReportTwelveComponent } from './report-twelve/report-twelve.component';

const routes: Routes = [
  {
    path: 'reportFour', component: ReportFourComponent
  },
  {
    path: 'reportFive', component: ReportFiveComponent
  },
  {
    path: 'reportSix', component: ReportSixComponent
  },
  {
    path: 'reportSeven', component: ReportSevenComponent
  },
  {
    path: 'reportEight', component: ReportEightComponent
  },
  {
    path: 'reportNine', component: ReportNineComponent
  },
  {
    path: 'reportTen', component: ReportTenComponent
  },
  {
    path: 'reportEleven', component: ReportElevenComponent
  },
  {
    path: 'reportTwelve', component: ReportTwelveComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
