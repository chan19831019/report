import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReportFourComponent } from './report-four/report-four.component';
import { ReportFiveComponent } from './report-five/report-five.component';
import { ReportSixComponent } from './report-six/report-six.component';
import { ReportSevenComponent } from './report-seven/report-seven.component';

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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
