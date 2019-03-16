import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReportFourComponent } from './report-four/report-four.component';
import { ReportFiveComponent } from './report-five/report-five.component';

const routes: Routes = [
  {
    path: 'reportFour', component: ReportFourComponent
  },
  {
    path: 'reportFive', component: ReportFiveComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
